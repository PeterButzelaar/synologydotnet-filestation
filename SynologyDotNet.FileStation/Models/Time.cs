using Newtonsoft.Json;
using System;
using SynologyDotNet.Core.Extensions;

namespace SynologyDotNet.FileStation.Models
{
    public class Time
    {
        /// <summary>
        /// Linux timestamp of last access in second.
        /// </summary>
        /// <value>
        /// The access time.
        /// </value>
        [JsonProperty("atime")]
        public long AccessTimeUnix { get; set; }

        /// <summary>
        /// Linux timestamp of create time in second. 
        /// </summary>
        /// <value>
        /// The create time.
        /// </value>
        [JsonProperty("crtime")]
        public long CreateTimeUnix { get; set; }

        /// <summary>
        /// Linux timestamp of last change in second. 
        /// </summary>
        /// <value>
        /// The change time.
        /// </value>
        [JsonProperty("ctime")]
        public long ChangeTimeUnix { get; set; }

        /// <summary>
        /// Linux timestamp of last modification in second.
        /// </summary>
        /// <value>
        /// The modification time.
        /// </value>
        [JsonProperty("mtime")]
        public long ModificationTimeUnix { get; set; }

        [JsonIgnore] public DateTime AccessTime => AccessTimeUnix.FromUnixSecondsToDateTimeUtc();
        [JsonIgnore] public DateTime CreateTime => CreateTimeUnix.FromUnixSecondsToDateTimeUtc();
        [JsonIgnore] public DateTime ChangeTime => ChangeTimeUnix.FromUnixSecondsToDateTimeUtc();
        [JsonIgnore] public DateTime ModificationTime => ModificationTimeUnix.FromUnixSecondsToDateTimeUtc();
    }
}
