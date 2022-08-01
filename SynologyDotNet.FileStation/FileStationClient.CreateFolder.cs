using System;
using System.Collections.Generic;
using System.Linq;
using SynologyDotNet.Core.Responses;
using SynologyDotNet.FileStation.Models;
using System.Threading.Tasks;

namespace SynologyDotNet.FileStation
{
    public partial class FileStationClient
    {
        /// <summary>
        /// Create folders on File Station.
        /// </summary>
        /// <param name="folders">One or more shared folder paths, separated by commas and around brackets.If force_parent is "true," and folder_path does not exist, the folder_path will be created.If force_parent is "false," folder_path must exist or a false value will be returned. The number of paths must be the same as the number of names in the name parameter.The first folder_path parameter corresponds to the first name parameter.</param>
        /// <param name="forceParent">Optional. true : no error occurs if a folder exists and create parent folders as needed. false : parent folders are not created..</param>
        /// <param name="additionalFields">The additional fields.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">folders</exception>
        public Task<ApiDataResponse<FolderList>> CreateFolderAsync((string folderPath, string name)[] folders, bool forceParent = false, QueryAdditional additionalFields = QueryAdditional.All)
        {
            if (folders == null || !folders.Any())
                throw new ArgumentNullException(nameof(folders));

            var parameters = new List<(string, object)>
            {
                (CreateFolderQueryParameter.folder_path.ToString(), "[" + string.Join(",", folders.Select(x => $"\"{x.folderPath}\"")) + "]"),
                (CreateFolderQueryParameter.name.ToString(), "[" + string.Join(",", folders.Select(x => $"\"{x.name}\"")) + "]"),
                (CreateFolderQueryParameter.force_parent.ToString(), forceParent.ToString().ToLowerInvariant())
            };

            if (additionalFields != QueryAdditional.None)
            {
                parameters.Add((CreateFolderQueryParameter.additional.ToString(), "[" + string.Join(",", new[] {
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

            return Client.QueryObjectAsync<ApiDataResponse<FolderList>>(SYNO_FileStation_CreateFolder, "create", parameters.ToArray());
        }
    }
}
