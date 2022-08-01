namespace SynologyDotNet.FileStation.Models
{
    public enum SortBy
    {
        /// <summary>
        /// file name
        /// </summary>
        name,
        /// <summary>
        /// file owner
        /// </summary>
        user,
        /// <summary>
        /// file group
        /// </summary>
        group,
        /// <summary>
        /// last modified time
        /// </summary>
        mtime,
        /// <summary>
        /// last access time
        /// </summary>
        atime,
        /// <summary>
        /// last change time
        /// </summary>
        ctime,
        /// <summary>
        /// create time
        /// </summary>
        crtime,
        /// <summary>
        /// POSIX permission
        /// </summary>
        posix
    }
}
