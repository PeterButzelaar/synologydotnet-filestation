using Newtonsoft.Json;
using SynologyDotNet.Core.Responses;
using System;

namespace SynologyDotNet.FileStation.Models
{
    public class ShareList : ListResponseBase
    {
        [JsonProperty("shares")]
        public File[] Shares { get; set; } = Array.Empty<File>();
    }
}
