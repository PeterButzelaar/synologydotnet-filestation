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
        /// <returns></returns>
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
