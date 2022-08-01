using SynologyDotNet.Core.Responses;
using SynologyDotNet.FileStation.Models;
using System.Threading.Tasks;

namespace SynologyDotNet.FileStation
{
    public partial class FileStationClient
    {
        /// <summary>
        /// Provide File Station info.
        /// </summary>
        /// <returns></returns>
        public Task<ApiDataResponse<Info>> InfoAsync()
        {
            return Client.QueryObjectAsync<ApiDataResponse<Info>>(SYNO_FileStation_Info, "get");
        }
    }
}
