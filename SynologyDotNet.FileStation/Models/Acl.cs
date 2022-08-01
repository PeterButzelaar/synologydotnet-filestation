using Newtonsoft.Json;

namespace SynologyDotNet.FileStation.Models
{
    public class Acl
    {
        /// <summary>
        /// If a logged-in user has a privilege to append data or create folders within this folder or not.
        /// </summary>
        /// <value>
        ///   <c>true</c> if append; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("append")]
        public bool Append { get; set; }

        /// <summary>
        /// If a logged-in user has a privilege to delete a file/a folder within this folder or not.
        /// </summary>
        /// <value>
        ///   <c>true</c> if delete; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("del")]
        public bool Del { get; set; }

        /// <summary>
        /// If a logged-in user has a privilege to execute files/traverse folders within this folder or not.
        /// </summary>
        /// <value>
        ///   <c>true</c> if execute; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("exec")]
        public bool Exec { get; set; }

        /// <summary>
        /// If a logged-in user has a privilege to read data or list folder within this folder or not.
        /// </summary>
        /// <value>
        ///   <c>true</c> if read; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("read")]
        public bool Read { get; set; }

        /// <summary>
        /// If a logged-in user has a privilege to write data or create files within this folder or not.
        /// </summary>
        /// <value>
        ///   <c>true</c> if write; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("write")]
        public bool Write { get; set; }
    }
}
