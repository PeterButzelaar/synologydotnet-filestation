using Newtonsoft.Json;

namespace SynologyDotNet.FileStation.Models
{
    public class AdvRight
    {
        /// <summary>
        /// If a non-administrator user can download files in this shared folder through SYNO.FileStation.Download API or not.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [disable download]; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("disable_download")]
        public bool DisableDownload { get; set; }

        /// <summary>
        /// If a non-administrator user can enumerate files in this shared folder though SYNO.FileStation.List API with list method or not.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [disable list]; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("disable_list")]
        public bool DisableList { get; set; }

        /// <summary>
        /// If a non-administrator user can modify or overwrite files in this shared folder or not.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [disable modify]; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("disable_modify")]
        public bool DisableModify { get; set; }
    }
}
