using Newtonsoft.Json;

namespace SynologyDotNet.FileStation.Models
{
    public class Owner
    {
        /// <summary>
        /// File GID.
        /// </summary>
        /// <value>
        /// The gid.
        /// </value>
        [JsonProperty("gid")]
        public int Gid { get; set; }

        /// <summary>
        /// Group name of file group.
        /// </summary>
        /// <value>
        /// The group.
        /// </value>
        [JsonProperty("group")]
        public string Group { get; set; }

        /// <summary>
        /// File UID.
        /// </summary>
        /// <value>
        /// The uid.
        /// </value>
        [JsonProperty("uid")]
        public int Uid { get; set; }

        /// <summary>
        /// User name of file owner.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        [JsonProperty("user")]
        public string User { get; set; }
    }
}
