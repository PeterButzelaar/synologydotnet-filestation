using Newtonsoft.Json;

namespace SynologyDotNet.FileStation.Models
{
    public class VolumeStatus
    {
        /// <summary>
        /// Byte size of free space of a volume where a shared folder is located.
        /// </summary>
        /// <value>
        /// The free space.
        /// </value>
        [JsonProperty("freespace")]
        public long FreeSpace { get; set; }

        /// <summary>
        /// A volume where a shared folder is located is readonly
        /// </summary>
        /// <value>
        ///   <c>true</c> if [read only]; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("readonly")]
        public bool ReadOnly { get; set; }

        /// <summary>
        /// Byte size of total space of a volume where a shared folder is located.
        /// </summary>
        /// <value>
        /// The total space.
        /// </value>
        [JsonProperty("totalspace")]
        public long TotalSpace { get; set; }
    }
}
