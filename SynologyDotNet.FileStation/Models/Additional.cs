using Newtonsoft.Json;

namespace SynologyDotNet.FileStation.Models
{
    public class Additional
    {
        /// <summary>
        /// Type of a virtual file system of a mount point.
        /// </summary>
        /// <value>
        /// The type of the mount point.
        /// </value>
        [JsonProperty("mount_point_type")]
        public string MountPointType { get; set; }

        /// <summary>
        /// Real path of a shared folder in a volume space.
        /// </summary>
        /// <value>
        /// The real path.
        /// </value>
        [JsonProperty("real_path")]
        public string RealPath { get; set; }

        /// <summary>
        /// File size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        [JsonProperty("size")]
        public long Size { get; set; }

        /// <summary>
        /// File owner information including user name, group name, UID and GID.
        /// </summary>
        /// <value>
        /// The owner.
        /// </value>
        [JsonProperty("owner")]
        public Owner Owner { get; set; }

        /// <summary>
        /// File permission information. 
        /// </summary>
        /// <value>
        /// The perm.
        /// </value>
        [JsonProperty("perm")]
        public Perm Perm { get; set; }

        /// <summary>
        /// Time information of file including last access time, last modified time, last change time, and creation time
        /// </summary>
        /// <value>
        /// The time.
        /// </value>
        [JsonProperty("time")]
        public Time Time { get; set; }

        /// <summary>
        /// Volume status including free space, total space and read-only status.
        /// </summary>
        /// <value>
        /// The volume status.
        /// </value>
        [JsonProperty("volume_status")]
        public VolumeStatus VolumeStatus { get; set; }
    }
}
