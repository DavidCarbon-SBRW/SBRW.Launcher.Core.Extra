using SBRW.Launcher.Core.Extra.Ini_;
using SBRW.Launcher.Core.Extra.Reference.Ini_;


namespace SBRW.Launcher.Core.Extra.File_.Save_
{
    /// <summary>
    /// Global Settings Save System
    /// </summary>
    /// <remarks>Used to set Values and Save them</remarks>
    public static partial class Save_Settings
    {
        /// <summary>Settings Format Information In Live Memory</summary>
        public static Format_Settings Live_Data { get; set; } = new Format_Settings();
        ///<value>Settings File Information on Disk</value>s
        private static Ini_File SettingFile { get; set; }
    }
}
