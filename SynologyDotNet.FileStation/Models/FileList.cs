using Newtonsoft.Json;
using SynologyDotNet.Core.Responses;
using System;

namespace SynologyDotNet.FileStation.Models
{
    public class FileList : ListResponseBase
    {
        [JsonProperty("files")]
        public File[] Files { get; set; } = Array.Empty<File>();
    }
}
