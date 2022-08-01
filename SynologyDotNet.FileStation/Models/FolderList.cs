using Newtonsoft.Json;
using System;

namespace SynologyDotNet.FileStation.Models
{
    public class FolderList
    {
        [JsonProperty("folders")]
        public File[] Folders { get; set; } = Array.Empty<File>();
    }
}
