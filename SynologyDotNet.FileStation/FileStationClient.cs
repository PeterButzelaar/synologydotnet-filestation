using System;

namespace SynologyDotNet.FileStation
{
    /// <summary>
    /// Connects to FileStation APIs
    /// </summary>
    /// <seealso cref="SynologyDotNet.StationConnectorBase" />
    public partial class FileStationClient : StationConnectorBase
    {
        #region Apis

        const string SYNO_FileStation_Info = "SYNO.FileStation.Info";
        const string SYNO_FileStation_List = "SYNO.FileStation.List";
        const string SYNO_FileStation_Search = "SYNO.FileStation.Search";
        //const string SYNO_FileStation_VirtualFolder = "SYNO.FileStation.VirtualFolder";
        //const string SYNO_FileStation_Favorite = "SYNO.FileStation.Favorite";
        //const string SYNO_FileStation_Thumb = "SYNO.FileStation.Thumb";
        //const string SYNO_FileStation_DirSize = "SYNO.FileStation.DirSize";
        //const string SYNO_FileStation_MD5 = "SYNO.FileStation.MD5";
        //const string SYNO_FileStation_CheckPermission = "SYNO.FileStation.CheckPermission";
        const string SYNO_FileStation_Upload = "SYNO.FileStation.Upload";
        const string SYNO_FileStation_Download = "SYNO.FileStation.Download";
        //const string SYNO_FileStation_Sharing = "SYNO.FileStation.Sharing";
        const string SYNO_FileStation_CreateFolder = "SYNO.FileStation.CreateFolder";
        //const string SYNO_FileStation_Rename = "SYNO.FileStation.Rename";
        //const string SYNO_FileStation_CopyMove = "SYNO.FileStation.CopyMove";
        //const string SYNO_FileStation_Delete = "SYNO.FileStation.Delete";
        //const string SYNO_FileStation_Extract = "SYNO.FileStation.Extract";
        //const string SYNO_FileStation_Compress = "SYNO.FileStation.Compress";
        //const string SYNO_FileStation_BackgroundTask = "SYNO.FileStation.BackgroundTask";

        protected override string[] GetImplementedApiNames() => new string[]
        {
            SYNO_FileStation_Info,
            SYNO_FileStation_List,
            SYNO_FileStation_Search,
            //SYNO_FileStation_VirtualFolder,
            //SYNO_FileStation_Favorite,
            //SYNO_FileStation_Thumb,
            //SYNO_FileStation_DirSize,
            //SYNO_FileStation_MD5,
            //SYNO_FileStation_CheckPermission,
            SYNO_FileStation_Upload,
            SYNO_FileStation_Download,
            SYNO_FileStation_CreateFolder,
            //SYNO_FileStation_Sharing,
            //SYNO_FileStation_Rename,
            //SYNO_FileStation_CopyMove,
            //SYNO_FileStation_Delete,
            //SYNO_FileStation_Extract,
            //SYNO_FileStation_Compress,
            //SYNO_FileStation_BackgroundTask
        };

        #endregion

        public FileStationClient() : base()
        {
        }
    }
}
