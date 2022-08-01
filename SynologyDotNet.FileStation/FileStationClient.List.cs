using System;
using SynologyDotNet.Core.Responses;
using SynologyDotNet.FileStation.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynologyDotNet.FileStation
{
    public partial class FileStationClient
    {
        /// <summary>
        /// List all shared folders, enumerate files in a shared folder, and get detailed file information.
        /// </summary>
        /// <param name="limit">Specify how many shared folders are skipped before beginning to return listed shared folders.</param>
        /// <param name="offset">Number of shared folders requested. 0 lists all shared folders.</param>
        /// <param name="sortBy">Specify which file information to sort on.</param>
        /// <param name="sortDirection">Specify to sort ascending or to sort descending.</param>
        /// <param name="onlyWritable">If set to <c>true</c>, list writable shared folders. Else, list writable and read-only shared folders.</param>
        /// <param name="additionalFields">Additional requested file information.</param>
        /// <returns></returns>
        public Task<ApiListResponse<ShareList>> ListSharedFoldersAsync(int limit = 1000, int offset = 0, SortBy sortBy = SortBy.name, SortDirection sortDirection = SortDirection.asc, bool onlyWritable = false, QueryAdditional additionalFields = QueryAdditional.All)
        {
            var parameters = new List<(string, object)>
            {
                (ShareListQueryParameter.sort_by.ToString(), sortBy.ToString()),
                (ShareListQueryParameter.sort_direction.ToString(), sortDirection.ToString()),
                (ShareListQueryParameter.onlywritable.ToString(), onlyWritable.ToString().ToLowerInvariant())
            };
            if (additionalFields != QueryAdditional.None)
            {
                parameters.Add((ShareListQueryParameter.additional.ToString(), "[" + string.Join(",", new[] {
                        QueryAdditional.real_path,
                        QueryAdditional.owner,
                        QueryAdditional.time,
                        QueryAdditional.perm,
                        QueryAdditional.mount_point_type,
                        QueryAdditional.volume_status
                    }
                    .Where(x => additionalFields.HasFlag(x))
                    .Select(x => $"\"{x}\"")) + "]"));
            }
            return Client.QueryListAsync<ApiListResponse<ShareList>>(SYNO_FileStation_List, "list_share", limit, offset, parameters.ToArray());
        }

        /// <summary>
        /// Enumerate files in a given folder.
        /// </summary>
        /// <param name="folderPath">A listed folder path starting with a shared folder</param>
        /// <param name="limit">Specify how many files are skipped before beginning to return listed files.</param>
        /// <param name="offset">Number of files requested. 0 indicates to list all files with a given folder.</param>
        /// <param name="sortBy">Specify which file information to sort on.</param>
        /// <param name="sortDirection">Specify to sort ascending or to sort descending.</param>
        /// <param name="pattern"> Given glob pattern(s) to find files whose names and extensions match a case-insensitive glob pattern.</param>
        /// <param name="filetype">"file": only enumerate regular files; "dir": only enumerate folders; "all" enumerate regular files and folders.</param>
        /// <param name="gotoPath"> Folder path starting with a shared folder. Return all files and sub-folders within folder_path path until goto_path path recursively.</param>
        /// <param name="additionalFields">Additional requested file information.</param>
        /// <returns></returns>
        public Task<ApiListResponse<FileList>> ListFilesAsync(string folderPath, int limit = 1000, int offset = 0, SortBy sortBy = SortBy.name, SortDirection sortDirection = SortDirection.asc, string pattern = null, Filetype filetype = Filetype.all, string gotoPath = null, QueryAdditional additionalFields = QueryAdditional.All)
        {
            if (string.IsNullOrWhiteSpace(folderPath))
                throw new ArgumentNullException(nameof(folderPath));

            var parameters = new List<(string, object)>
            {
                (FolderListQueryParameter.folder_path.ToString(), folderPath),
                (FolderListQueryParameter.sort_by.ToString(), sortBy.ToString()),
                (FolderListQueryParameter.sort_direction.ToString(), sortDirection.ToString()),
                (FolderListQueryParameter.pattern.ToString(), pattern),
                (FolderListQueryParameter.filetype.ToString(), filetype.ToString()),
                (FolderListQueryParameter.goto_path.ToString(), gotoPath)
            };
            if (additionalFields != QueryAdditional.None)
            {
                parameters.Add((FolderListQueryParameter.additional.ToString(), "[" + string.Join(",", new[] {
                        QueryAdditional.real_path,
                        QueryAdditional.owner,
                        QueryAdditional.time,
                        QueryAdditional.perm,
                        QueryAdditional.mount_point_type,
                        QueryAdditional.volume_status,
                        QueryAdditional.size
                    }
                    .Where(x => additionalFields.HasFlag(x))
                    .Select(x => $"\"{x}\"")) + "]"));
            }

            return Client.QueryListAsync<ApiListResponse<FileList>>(SYNO_FileStation_List, "list", limit, offset, parameters.ToArray());
        }
    }
}
