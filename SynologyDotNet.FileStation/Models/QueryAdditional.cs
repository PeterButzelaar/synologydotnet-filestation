using System;

namespace SynologyDotNet.FileStation.Models
{
    [Flags]
    public enum QueryAdditional
    {
        None = 0,

        real_path = 1,
        owner = 2,
        time = 4,
        perm = 8,
        mount_point_type = 16,
        volume_status = 32,
        size = 64,
        type = 128,

        All = ~None,
        
    }
}
