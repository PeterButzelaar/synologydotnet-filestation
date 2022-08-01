using Newtonsoft.Json;

namespace SynologyDotNet.FileStation.Models
{
    public class File
    {
        [JsonProperty("isdir")]
        public bool IsDirectory { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("additional")]
        public Additional Additional { get; set; }
    }
}
