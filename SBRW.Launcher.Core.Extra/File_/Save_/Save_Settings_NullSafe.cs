using SBRW.Launcher.Core.Cache;
using SBRW.Launcher.Core.Extension.Numbers_;
using SBRW.Launcher.Core.Extra.Ini_;
using SBRW.Launcher.Core.Required.System.Windows_;
using System.IO;

namespace SBRW.Launcher.Core.Extra.File_.Save_
{
    public static partial class Save_Settings
    {
        /// <summary>
        /// Loads all settings from the INI file into Live_Data.
        /// Applies defaults for any missing values.
        /// </summary>
        public static void NullSafe()
        {
            SettingFile = new Ini_File(Ini_Location.Launcher_Settings);

            #region Migration
            /* Pervent Removal of Login Info Before Main Screen (Temporary Boolean) */
            Save_Account.SaveLoginInformation = true;

            /* Migrate old Key Entries */
            MigrateAccountsToSeperateFile("Server", value => Save_Account.Live_Data.Saved_Server_Address = value);
            MigrateAccountsToSeperateFile("AccountEmail", value => Save_Account.Live_Data.User_Raw_Email = value);
            MigrateAccountsToSeperateFile("Password", value => Save_Account.Live_Data.User_Hashed_Password = value);

            /* Reset This Value as its now Safe to Do So */
            Save_Account.SaveLoginInformation = false;

            /* Migrate combined key(s) */
            if (SettingFile.Key_Exists("Firewall"))
            {
                string firewallStatus = SettingFile.Key_Read("Firewall");
                Live_Data.Firewall_Game = firewallStatus;
                Live_Data.Firewall_Launcher = firewallStatus;
                SettingFile.Key_Delete("Firewall");
            }

            if (SettingFile.Key_Exists("WindowsDefender"))
            {
                string windowsdefenderStatus = SettingFile.Key_Read("WindowsDefender");
                Live_Data.Defender_Game = windowsdefenderStatus;
                Live_Data.Defender_Launcher = windowsdefenderStatus;
                SettingFile.Key_Delete("WindowsDefender");
            }

            if (SettingFile.Key_Exists("LegacyTimer"))
            {
                Live_Data.Launcher_Display_Timer = SettingFile.Key_Read("LegacyTimer", Live_Data.Launcher_Display_Timer).Clamp(0, 2);
                SettingFile.Key_Delete("LegacyTimer");
            }

            if (SettingFile.Key_Exists("DisableProxy"))
            {
                Live_Data.Launcher_Proxy = SettingFile.Key_Read("DisableProxy", Live_Data.Launcher_Proxy);
                SettingFile.Key_Delete("DisableProxy");
            }

            if (SettingFile.Key_Exists("DisableRPC"))
            {
                Live_Data.Launcher_Discord_Presence = SettingFile.Key_Read("DisableRPC", Live_Data.Launcher_Discord_Presence);
                SettingFile.Key_Delete("DisableRPC");
            }
            #endregion
            #region File/Folder Paths
            Live_Data.Game_Path = SettingFile.Key_Read("InstallationDirectory", Live_Data.Game_Path);
            Live_Data.Game_Path_Old = SettingFile.Key_Read("OldInstallationDirectory", Live_Data.Game_Path_Old);
            /* SBRW Pack File Path */
            Live_Data.Game_Archive_Location = SettingFile.Key_Read("GameArchivePath", Live_Data.Game_Archive_Location);
            if (!File.Exists(Live_Data.Game_Archive_Location))
            {
                Live_Data.Game_Archive_Location = string.Empty;
            }
            if (Launcher_Value.System_Unix && string.IsNullOrWhiteSpace(Live_Data.Game_Path))
            {
                /* Unix Builds is unable to choose the folder path correctly
                * Use known good failsafe folder path */
                Live_Data.Game_Path = "GameFiles";
            }
            #endregion
            #region Launcher
            Live_Data.Launcher_CDN = SettingFile.Key_Read("CDN", Live_Data.Launcher_CDN);
            Live_Data.Launcher_Language = SettingFile.Key_Read("Language", Live_Data.Launcher_Language);
            Live_Data.Launcher_Proxy = SettingFile.Key_Read("LauncherProxy", Live_Data.Launcher_Proxy);
            Live_Data.Launcher_Discord_Presence = SettingFile.Key_Read("LauncherDRPC", Live_Data.Launcher_Discord_Presence);
            Live_Data.Update_Version_Skip = SettingFile.Key_Read("IgnoreUpdateVersion", Live_Data.Update_Version_Skip);

            if (!Launcher_Value.System_Unix)
            {
                Live_Data.Write_Permissions = SettingFile.Key_Read("FilePermission", Live_Data.Write_Permissions);
            }
            else
            {
                RemoveSetting("FilePermission");
            }

            Live_Data.Game_Integrity = SettingFile.Key_Read("GameIntegrity", Live_Data.Game_Integrity);
            Live_Data.Launcher_Proxy_Port = SettingFile.Key_Read("ProxyPort", Live_Data.Launcher_Proxy_Port);
            Live_Data.Launcher_WebClient_Method = SettingFile.Key_Read("WebCallMethod", Live_Data.Launcher_WebClient_Method);
            Live_Data.Launcher_Theme_Support = SettingFile.Key_Read("ThemeSupport", Live_Data.Launcher_Theme_Support);
            Live_Data.Launcher_Insider = SettingFile.Key_Read("Insider", Live_Data.Launcher_Insider).Clamp(0, 2);
            Live_Data.Launcher_Display_Timer = SettingFile.Key_Read("DisplayTimer", Live_Data.Launcher_Display_Timer).Clamp(0, 2);
            Live_Data.Launcher_Game_Downloader = SettingFile.Key_Read("DownloaderGame", Live_Data.Launcher_Game_Downloader).Clamp(0,2);
            Live_Data.Launcher_JSON_Frequency_Update_Cache = SettingFile.Key_Read("JSONFrequencyUpdateCache", Live_Data.Launcher_JSON_Frequency_Update_Cache);
            Live_Data.Launcher_WebCall_TimeOut_Time = SettingFile.Key_Read("WebCallTimeOut", Live_Data.Launcher_WebCall_TimeOut_Time);

            if (!Launcher_Value.System_Unix)
            {
                Live_Data.Firewall_Launcher = SettingFile.Key_Read("FirewallLauncher", Live_Data.Firewall_Launcher);
                Live_Data.Firewall_Game = SettingFile.Key_Read("FirewallGame", Live_Data.Firewall_Game);

                if (Product_Version.GetWindowsNumber() >= 10.0)
                {
                    Live_Data.Defender_Launcher = SettingFile.Key_Read("DefenderLauncher", Live_Data.Defender_Launcher);
                    Live_Data.Defender_Game = SettingFile.Key_Read("DefenderGame", Live_Data.Defender_Game);
                }
                else
                {
                    RemoveSetting("DefenderLauncher");
                    RemoveSetting("DefenderGame");
                }

                if (Product_Version.GetWindowsNumber() == 6.1)
                {
                    Live_Data.Win_7_Patches = SettingFile.Key_Read("PatchesApplied", Live_Data.Win_7_Patches);
                }
                else
                {
                    RemoveSetting("PatchesApplied");
                }
            }
            else
            {
                Live_Data.Alert_Storage_Space = SettingFile.Key_Read("AlertStorage", Live_Data.Alert_Storage_Space);
            }

            Live_Data.Launcher_RunTime_Environment = SettingFile.Key_Read("LauncherEnvironment", Live_Data.Launcher_RunTime_Environment).Clamp(0,3);
            Live_Data.Launcher_Legacy_Host_To_IP = SettingFile.Key_Read("LegacyHost2IP", Live_Data.Launcher_Legacy_Host_To_IP);
            Live_Data.Launcher_Proxy_Domain = SettingFile.Key_Read("ProxyHostDomain", Live_Data.Launcher_Proxy_Domain);
            Live_Data.Launcher_Proxy_Log_Mode = SettingFile.Key_Read("ProxyLogMode", Live_Data.Launcher_Proxy_Log_Mode).Clamp(0,4);
            Live_Data.Launcher_Game_Affinity_Range_Mode = SettingFile.Key_Read("GameAffinityRangeMode", Live_Data.Launcher_Game_Affinity_Range_Mode);
            Live_Data.Game_Affinity_Range = SettingFile.Key_Read("GameAffinityRange", Live_Data.Game_Affinity_Range);
            Live_Data.Launcher_Account_Manager = SettingFile.Key_Read("AccountManager", Live_Data.Launcher_Account_Manager);
            Live_Data.Launcher_Proxy_GZip_Version = SettingFile.Key_Read("ProxyGZipVersion", Live_Data.Launcher_Proxy_GZip_Version).Clamp(0, 4);
            Live_Data.Launcher_Log_Mode = SettingFile.Key_Read("LogMode", Live_Data.Launcher_Log_Mode).Clamp(0, 4);
            Live_Data.Launcher_Verify_Log_Mode = SettingFile.Key_Read("VerifyLogMode", Live_Data.Launcher_Verify_Log_Mode).Clamp(0, 6);
            Live_Data.Launcher_Verify_Script_Removal = SettingFile.Key_Read("VerifyScriptRemoval", Live_Data.Launcher_Verify_Script_Removal);
            Live_Data.Launcher_Certificate_Mode = SettingFile.Key_Read("Certificate", Live_Data.Launcher_Certificate_Mode);
            Live_Data.Launcher_Log_Schedule_Mode = SettingFile.Key_Read("LogCleanup", Live_Data.Launcher_Log_Schedule_Mode).Clamp(0, 3);
            Live_Data.Launcher_Log_Schedule = SettingFile.Key_Read("LogCleanupSchedule", Live_Data.Launcher_Log_Schedule);
            Live_Data.Launcher_Time_Server_URL = SettingFile.Key_Read("TimeServerURL", Live_Data.Launcher_Time_Server_URL);
            #endregion
            #region Legacy Entries
            RemoveSetting("LauncherPosX");
            RemoveSetting("LauncherPosY");
            RemoveSetting("DisableVerifyHash");
            RemoveSetting("TracksHigh");
            RemoveSetting("ModNetDisabled");
            RemoveSetting("ModNetZip");
            RemoveSetting("StreamingSupport");
            /* Since we are having LZMA being the default downloader 
            * its safe to remove it with the new entry (which defaults to LZMA already) */
            RemoveSetting("LzmaDownloader");
            #endregion
            /* Flush Changes to Disk */
            SettingFile = new Ini_File(Ini_Location.Launcher_Settings);
            /* Invoke Save Function to Save and Activate new Settings */
            Save();
        }
    }
}