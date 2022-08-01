using System;
using Newtonsoft.Json;
using SynologyDotNet.Core.Responses;

namespace SynologyDotNet.FileStation.Models
{
    public class SearchList : ListResponseBase
    {
        [JsonProperty("finished")]
        public bool Finished { get; set; }

        [JsonProperty("files")] public File[] Files { get; set; } = Array.Empty<File>();
    }
}
