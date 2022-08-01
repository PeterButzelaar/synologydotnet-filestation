using SynologyDotNet.Core.Model;
using SynologyDotNet.FileStation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynologyDotNet.FileStation
{
    public partial class FileStationClient
    {
        /// <summary>
        /// Download files/folders. If only one file is specified, the file content is responded. If more than one file/folder is given, binary content in ZIP format which they are compressed to is responded.
        /// </summary>
        /// <param name="paths">One or more file/folder paths starting with a shared folder to be downloaded, separated by a comma "," and around the brackets.When more than one file is to be downloaded, files/folders will be compressed as a zip file.</param>
        /// <returns></returns>
        public Task<ByteArrayData> DownloadAsync(string[] paths)
        {
            if (paths == null || !paths.Any())
                throw new ArgumentNullException(nameof(paths));

            var parameters = new List<(string, object)>
            {
                (DownloadQueryParameter.path.ToString(), "[" + string.Join(",", paths.Select(x => $"\"{x}\"")) + "]"),
                (DownloadQueryParameter.mode.ToString(), "download") // "open" is also an option, but used so the response header Content-Type is set to MIME to try to open in the browser. Not applicable in this package
            };

            return Client.QueryByteArrayAsync(SYNO_FileStation_Download, "download", parameters.ToArray());
        }
    }
}
