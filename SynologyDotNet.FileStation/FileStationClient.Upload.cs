using SynologyDotNet.Core.Extensions;
using SynologyDotNet.Core.Responses;
using SynologyDotNet.FileStation.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SynologyDotNet.FileStation
{
    public partial class FileStationClient
    {
        /// <summary>
        /// Upload a file by RFC 1867, http://tools.ietf.org/html/rfc1867.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="createParents">Create parent folder(s) if none exist.</param>
        /// <param name="data">The file content.</param>
        /// <param name="filename">The filename.</param>
        /// <param name="overwrite">if set to <c>true</c> [overwrite].</param>
        /// <param name="modifiedTime">The modified time.</param>
        /// <param name="createTime">The create.</param>
        /// <param name="accessTime">The access time.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">path or data</exception>
        public Task<ApiResponse> UploadAsync(string path, bool createParents, Stream data, string filename, bool overwrite = false, DateTime? modifiedTime = null, DateTime? createTime = null, DateTime? accessTime = null)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            var parameters = new List<(string, object)>
            {
                (UploadQueryParameter.path.ToString(), path),
                (UploadQueryParameter.create_parents.ToString(), createParents.ToString().ToLowerInvariant()),
                (UploadQueryParameter.mtime.ToString(), modifiedTime.FromDateTimeUtcToUnix()),
                (UploadQueryParameter.overwrite.ToString(), overwrite? "overwrite" : null),
                (UploadQueryParameter.crtime.ToString(), createTime.FromDateTimeUtcToUnix()),
                (UploadQueryParameter.atime.ToString(), accessTime.FromDateTimeUtcToUnix())
            };
            return Client.QueryObjectAsync<ApiResponse>(SYNO_FileStation_Upload, "upload", data, filename, parameters.ToArray());
        }
    }
}
