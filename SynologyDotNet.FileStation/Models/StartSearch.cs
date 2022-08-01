using Newtonsoft.Json;

namespace SynologyDotNet.FileStation.Models
{
    public class StartSearch
    {
        [JsonProperty("taskid")]
        public string TaskId { get; set; }
    }
}
