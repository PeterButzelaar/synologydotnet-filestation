using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace SynologyDotNet.FileStation.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ShareRight
    {
        [EnumMember(Value = "RW")]
        Writable,
        [EnumMember(Value = "RO")]
        ReadOnly
    }
}
