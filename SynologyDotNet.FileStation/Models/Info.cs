using System.Collections.Generic;
using Newtonsoft.Json;

namespace SynologyDotNet.FileStation.Models
{
    public class Info
    {
        [JsonProperty("enable_list_usergrp")]
        public bool EnableListUsergrp { get; set; }

        [JsonProperty("enable_send_email_attachment")]
        public bool EnableSendEmailAttachment { get; set; }

        [JsonProperty("enable_view_google")]
        public bool EnableViewGoogle { get; set; }

        [JsonProperty("enable_view_microsoft")]
        public bool EnableViewMicrosoft { get; set; }

        /// <summary>
        /// DSM host name.
        /// </summary>
        [JsonProperty("hostname")]
        public string Hostname { get; set; }

        /// <summary>
        /// If the logged-in user is an administrator
        /// </summary>
        [JsonProperty("is_manager")]
        public bool IsManager { get; set; }

        public IEnumerable<Item> Items { get; set; }

        [JsonProperty("support_file_request")]
        public bool SupportFileRequest { get; set; }

        /// <summary>
        /// If the logged-in user can sharing file(s) / folder(s) or not. 
        /// </summary>
        [JsonProperty("support_sharing")]
        public bool SupportSharing { get; set; }

        [JsonProperty("support_vfs")]
        public bool SupportVfs { get; set; }

        [JsonProperty("support_virtual")]
        public SupportVirtual SupportVirtual { get; set; }

        /// <summary>
        /// Types of virtual file system which the logged user is able to mount on.
        /// DSM 6.0 supports CIFS, NFS and ISO of virtual file system.
        /// Different types are separated with a comma, for example:
        /// cifs,nfs,iso
        /// </summary>
        [JsonProperty("support_virtual_protocol")]
        public IEnumerable<string> SupportVirtualProtocol { get; set; }

        [JsonProperty("system_codepage")]
        public string SystemodePage { get; set; }

        [JsonProperty("uid")]
        public int Uid { get; set; }
        
    }

    public struct Item
    {
        [JsonProperty("gid")]
        public int Gid { get; set; }
    }
}
