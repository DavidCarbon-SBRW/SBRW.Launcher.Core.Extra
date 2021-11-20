using SBRW.Launcher.Core.Classes.Cache;
using SBRW.Launcher.Core.Classes.Extension.Logging_;
using System;
using System.IO;

namespace SBRW.Launcher.Core.Extra.Ini_
{
    /// <summary>
    /// Ini Location and Name Class
    /// </summary>
    public class Ini_Location
    {
        /// <summary>
        /// Name of the Settings File (Ini)
        /// </summary>
        public static string Name_Settings_Ini { get; set; } = "Settings.ini";
        /// <summary>
        /// Name of the Account File (Ini)
        /// </summary>
        public static string Name_Account_Ini { get; set; } = "Account.ini";
        /// <summary>
        /// Launcher Settings (Ini) Full File Path
        /// </summary>
        public static string Launcher_Settings { get; set; } = Launcher_Value.System_Unix ? Name_Settings_Ini : Path.Combine(Log_Location.LauncherFolder, Name_Settings_Ini);
        /// <summary>
        /// Roaming App Data Folder Location
        /// </summary>
        public static string RoamingAppDataFolder { get; set; } = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        /// <summary>
        /// Roaming App Data Launcher Folder Location
        /// </summary>
        public static string RoamingAppDataFolder_Launcher { get; set; } = Path.Combine(RoamingAppDataFolder, "Soapbox Race World", "Launcher");
        /// <summary>
        /// Launcher Account (Ini) Full File Path
        /// </summary>
        public static string Launcher_Account { get; set; } = Launcher_Value.System_Unix ? Name_Account_Ini : Path.Combine(RoamingAppDataFolder_Launcher, Name_Account_Ini);
    }
}
