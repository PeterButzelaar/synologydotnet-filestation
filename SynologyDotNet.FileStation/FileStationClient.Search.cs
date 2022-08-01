using SynologyDotNet.Core.Responses;
using SynologyDotNet.FileStation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SynologyDotNet.Core.Extensions;

namespace SynologyDotNet.FileStation
{
    public partial class FileStationClient
    {
        /// <summary>
        /// Search files according to given criteria.  If more than one criterion is given in different parameters, searched files match all these criteria.
        /// This is a non-blocking API. You need to start to search files with the start method. Then, you should poll requests with list method to get more information, or make a request with the stop method to cancel the operation.Otherwise, search results are stored in a search temporary database so you need to call clean method to delete it at the end of operation
        /// Note: the indexing service should be configured in order to retrieve results
        /// </summary>
        /// <param name="folderPaths">A searched folder path starting with a shared folder.One or more folder paths to be searched, separated by commas "," and around brackets</param>
        /// <param name="recursive">If searching files within a folder and subfolders recursively or not.</param>
        /// <param name="patterns">Search for files whose names and extensions match a case-insensitive glob pattern</param>
        /// <param name="extensions">Search for files whose extensions match a file type pattern in a case-insensitive glob pattern.If you give this criterion, folders aren't matched. Note: You can use commas "," to separate multiple glob patterns.</param>
        /// <param name="filetype">"file": enumerate regular files; "dir": enumerate folders; "all" enumerate regular files and folders.</param>
        /// <param name="sizeFrom"> Search for files whose sizes are greater than the given byte size.</param>
        /// <param name="sizeTo">Search for files whose sizes are less than the given byte size.</param>
        /// <param name="modifiedFrom">Search for files whose last modified time after the given timestamp.</param>
        /// <param name="modifiedTo">Search for files whose last modified time before the given timestamp.</param>
        /// <param name="createFrom">Search for files whose last create time after the given timestamp.</param>
        /// <param name="createTo">Search for files whose last create time before the given timestamp.</param>
        /// <param name="accessFrom">Search for files whose last access time after the given timestamp.</param>
        /// <param name="accessTo">Search for files whose last access time before the given timestamp.</param>
        /// <param name="owner">Search for files whose user name matches this criterion. This criterion is case-insensitive.</param>
        /// <param name="group">Search for files whose group name matches this criterion. This criterion is case-insensitive.</param>
        /// <returns></returns>
        public Task<ApiDataResponse<StartSearch>> StartSearchAsync(string[] folderPaths, bool recursive = true, string[] patterns = null, string[] extensions = null, Filetype filetype = Filetype.all, long? sizeFrom = null, long? sizeTo = null, DateTime? modifiedFrom = null, DateTime? modifiedTo = null, DateTime? createFrom = null, DateTime? createTo = null, DateTime? accessFrom = null, DateTime? accessTo = null, string owner = null, string group = null)
        {
            if (folderPaths == null || !folderPaths.Any())
                throw new ArgumentNullException(nameof(folderPaths));

            var parameters = new List<(string, object)>
            {
                (SearchQueryParameter.folder_path.ToString(), "[" + string.Join(",", folderPaths.Select(x => $"\"{x}\"")) + "]"),
                (SearchQueryParameter.recursive.ToString(), recursive.ToString().ToLowerInvariant()),
                (SearchQueryParameter.pattern.ToString(), patterns == null ? null : string.Join(" ", patterns.Select(p => $"\"{p}\""))),
                (SearchQueryParameter.extension.ToString(), extensions == null ? null : string.Join(",", extensions)),
                (SearchQueryParameter.filetype.ToString(), filetype == Filetype.all ? null : filetype.ToString()),
                (SearchQueryParameter.size_from.ToString(), sizeFrom),
                (SearchQueryParameter.size_to.ToString(), sizeTo),
                (SearchQueryParameter.mtime_from.ToString(), modifiedFrom.FromDateTimeUtcToUnix()),
                (SearchQueryParameter.mtime_to.ToString(), modifiedTo.FromDateTimeUtcToUnix()),
                (SearchQueryParameter.crtime_from.ToString(), createFrom.FromDateTimeUtcToUnix()),
                (SearchQueryParameter.crtime_to.ToString(), createTo.FromDateTimeUtcToUnix()),
                (SearchQueryParameter.atime_from.ToString(), accessFrom.FromDateTimeUtcToUnix()),
                (SearchQueryParameter.atime_to.ToString(), accessTo.FromDateTimeUtcToUnix()),
                (SearchQueryParameter.owner.ToString(), owner),
                (SearchQueryParameter.group.ToString(), group)
            };

            return Client.QueryObjectAsync<ApiDataResponse<StartSearch>>(SYNO_FileStation_Search, "start", parameters.ToArray());
        }

        /// <summary>
        /// List matched files in a search temporary database. You can check the finished value in response to know if the search operation is processing or has been finished.
        /// </summary>
        /// <param name="taskId">The task identifier.</param>
        /// <param name="limit">The limit.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="sortBy">The sort by.</param>
        /// <param name="sortDirection">The sort direction.</param>
        /// <param name="additionalFields">The additional fields.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">taskId</exception>
        public Task<ApiListResponse<SearchList>> ListSearchResultsAsync(string taskId, int limit = 1000, int offset = 0, SortBy sortBy = SortBy.name, SortDirection sortDirection = SortDirection.asc, QueryAdditional additionalFields = QueryAdditional.All)
        {
            if (string.IsNullOrWhiteSpace(taskId))
                throw new ArgumentNullException(nameof(taskId));

            var parameters = new List<(string, object)>
            {
                (SearchListQueryParameter.taskid.ToString(), $"\"{taskId}\""),
                (SearchListQueryParameter.sort_by.ToString(), sortBy.ToString()),
                (SearchListQueryParameter.sort_direction.ToString(), sortDirection.ToString())
            };
            if (additionalFields != QueryAdditional.None)
            {
                parameters.Add((SearchListQueryParameter.additional.ToString(), "[" + string.Join(",", new[] {
                        QueryAdditional.real_path,
                        QueryAdditional.owner,
                        QueryAdditional.time,
                        QueryAdditional.perm,
                        QueryAdditional.mount_point_type,
                        QueryAdditional.volume_status,
                        QueryAdditional.size,
                        QueryAdditional.type
                    }
                    .Where(x => additionalFields.HasFlag(x))
                    .Select(x => $"\"{x}\"")) + "]"));
            }

            return Client.QueryListAsync<ApiListResponse<SearchList>>(SYNO_FileStation_Search, "list", limit, offset, parameters.ToArray());
        }

        /// <summary>
        /// Stop the searching task(s). The search temporary database won't be deleted, so it's possible to list the search result using list method after stopping it.
        /// </summary>
        /// <param name="taskId">The task identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">taskId</exception>
        public Task<ApiResponse> StopSearchAsync(string taskId)
        {
            if (string.IsNullOrWhiteSpace(taskId))
                throw new ArgumentNullException(nameof(taskId));

            var parameters = new List<(string, object)>
            {
                (SearchListQueryParameter.taskid.ToString(), $"\"{taskId}\""),
            };

            return Client.QueryObjectAsync<ApiResponse>(SYNO_FileStation_Search, "stop", parameters.ToArray());
        }
    }
}
