using Newtonsoft.Json;

namespace SynologyDotNet.FileStation.Models
{
    public class Perm
    {
        /// <summary>
        /// Windows ACL privilege. If a shared folder is set to be POSIX-mode, these values of Windows ACL privileges are derived from the POSIX privilege.
        /// </summary>
        /// <value>
        /// The acl.
        /// </value>
        [JsonProperty("acl")]
        public Acl Acl { get; set; }

        /// <summary>
        /// Special privilege of the shared folder. 
        /// </summary>
        /// <value>
        /// The adv right.
        /// </value>
        [JsonProperty("adv_right")]
        public AdvRight AdvRight { get; set; }

        /// <summary>
        /// If Windows ACL privilege of the shared folder is enabled or not.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [acl enable]; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("acl_enable")]
        public bool AclEnable { get; set; }

        /// <summary>
        /// The privilege of the shared folder is set to be ACL-mode. false : The privilege of the shared folder is set to be POSIX-mode
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is acl mode; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("is_acl_mode")]
        public bool IsAclMode { get; set; }

        /// <summary>
        /// Is the share read-only
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is share readonly; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("is_share_readonly")]
        public bool IsShareReadonly { get; set; }

        /// <summary>
        /// POSIX file permission, For example, 777 means owner, group or other has all permission; 764 means owner has all permission, group has read/write permission, other has read permission.
        /// </summary>
        /// <value>
        /// The posix.
        /// </value>
        [JsonProperty("posix")]
        public int Posix { get; set; }

        /// <summary>
        /// "RW": The shared folder is writable; "RO": the shared folder is read-only.
        /// </summary>
        /// <value>
        /// The share right.
        /// </value>
        [JsonProperty("share_right")]
        public ShareRight ShareRight { get; set; }
    }
}
