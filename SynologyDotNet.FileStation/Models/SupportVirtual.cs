using Newtonsoft.Json;

namespace SynologyDotNet.FileStation.Models
{
    public class SupportVirtual
    {
        [JsonProperty("enable_iso_mount")]
        public bool EnableIsoMount { get; set; }

        [JsonProperty("enable_remote_mount")]
        public bool EnableRemoteMount { get; set; }
    }
}
