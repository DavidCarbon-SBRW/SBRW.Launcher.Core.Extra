﻿using SBRW.Launcher.Core.Classes.Cache;
using SBRW.Launcher.Core.Classes.Extension.Logging_;
using SBRW.Launcher.Core.Classes.Reference.Ini_;
using SBRW.Launcher.Core.Classes.Required.System.Windows_;
using SBRW.Launcher.Core.Discord.RPC_;
using SBRW.Launcher.Core.Extra.Ini_;
using SBRW.Launcher.Core.Proxy.Nancy_;

namespace SBRW.Launcher.Core.Extra.File_
{
    /// <summary>
    /// Global Settings Save System
    /// </summary>
    /// <remarks>Used to set Values and Save them</remarks>
    public class Save_Settings
    {
        /// <summary>Settings Format Information In Live Memory</summary>
        public static Format_Settings Live_Data { get; set; } = new Format_Settings();
        ///<value>Settings File Information on Disk</value>s
        private static Ini_File SettingFile { get; set; }
        ///<summary>Launcher Streaming Support [Saved Live Value]</summary>
        ///<remarks>Allows Video Capture Natively</remarks>
        ///<returns>True or False</returns>
        public static bool LiveStreamingSupport() => Live_Data.Launcher_Streaming_Support == "1";
        /// <summary>Creates all the NullSafe Values for Settings.ini</summary>
        public static void NullSafe()
        {
            SettingFile = new Ini_File(Ini_Location.Launcher_Settings);

            /* Pervent Removal of Login Info Before Main Screen (Temporary Boolean) */
            Save_Account.SaveLoginInformation = true;

            /* Migrate old Key Entries */
            if (SettingFile.Key_Exists("Server"))
            {
                Save_Account.Live_Data.Saved_Server_Address = SettingFile.Key_Read("Server");
                SettingFile.Key_Delete("Server");
                Save_Account.Save();
            }

            if (SettingFile.Key_Exists("AccountEmail"))
            {
                Save_Account.Live_Data.User_Raw_Email = SettingFile.Key_Read("AccountEmail");
                SettingFile.Key_Delete("AccountEmail");
                Save_Account.Save();
            }

            if (SettingFile.Key_Exists("Password"))
            {
                Save_Account.Live_Data.User_Hashed_Password = SettingFile.Key_Read("Password");
                SettingFile.Key_Delete("Password");
                Save_Account.Save();
            }

            /* Reset This Value as its now Safe to Do So */
            Save_Account.SaveLoginInformation = false;

            if (SettingFile.Key_Exists("Firewall"))
            {
                Live_Data.Firewall_Game = Live_Data.Firewall_Launcher = SettingFile.Key_Read("Firewall");
                SettingFile.Key_Delete("Firewall");
            }

            if (SettingFile.Key_Exists("WindowsDefender"))
            {
                Live_Data.Defender_Game = Live_Data.Defender_Launcher = SettingFile.Key_Read("WindowsDefender");
                SettingFile.Key_Delete("WindowsDefender");
            }

            /* Check if any Entries are missing */

            if (Launcher_Value.System_Unix && !SettingFile.Key_Exists("InstallationDirectory"))
            {
                SettingFile.Key_Write("InstallationDirectory", "GameFiles");
            }
            else if (!SettingFile.Key_Exists("InstallationDirectory"))
            {
                SettingFile.Key_Write("InstallationDirectory", Live_Data.Game_Path);
            }
            else
            {
                Live_Data.Game_Path = SettingFile.Key_Read("InstallationDirectory");
            }

            if (Launcher_Value.System_Unix && SettingFile.Key_Exists("OldInstallationDirectory"))
            {
                SettingFile.Key_Delete("OldInstallationDirectory");
            }
            else if (!Launcher_Value.System_Unix && !SettingFile.Key_Exists("OldInstallationDirectory"))
            {
                SettingFile.Key_Write("OldInstallationDirectory", Live_Data.Game_Path_Old);
            }
            else
            {
                Live_Data.Game_Path_Old = SettingFile.Key_Read("OldInstallationDirectory");
            }

            if (!SettingFile.Key_Exists("CDN") || string.IsNullOrWhiteSpace(SettingFile.Key_Read("CDN")))
            {
                SettingFile.Key_Write("CDN", Live_Data.Launcher_CDN = "http://localhost");
            }
            else
            {
                if (SettingFile.Key_Read("CDN").EndsWith("/"))
                {
                    SettingFile.Key_Write("CDN", Live_Data.Launcher_CDN = SettingFile.Key_Read("CDN").TrimEnd('/'));
                }
                else
                {
                    Live_Data.Launcher_CDN = SettingFile.Key_Read("CDN");
                }
            }

            if (!SettingFile.Key_Exists("Language") || string.IsNullOrWhiteSpace(SettingFile.Key_Read("Language")))
            {
                SettingFile.Key_Write("Language", Live_Data.Launcher_Language = "EN");
            }
            else
            {
                Live_Data.Launcher_Language = SettingFile.Key_Read("Language");
            }

            if (!SettingFile.Key_Exists("DisableProxy") || string.IsNullOrWhiteSpace(SettingFile.Key_Read("DisableProxy")))
            {
                SettingFile.Key_Write("DisableProxy", Live_Data.Launcher_Proxy = "0");
            }
            else if ((SettingFile.Key_Read("DisableProxy") == "0") || (SettingFile.Key_Read("DisableProxy") == "1"))
            {
                Live_Data.Launcher_Proxy = SettingFile.Key_Read("DisableProxy");
            }
            else
            {
                SettingFile.Key_Write("DisableProxy", Live_Data.Launcher_Proxy = "0");
            }

            if (!SettingFile.Key_Exists("DisableRPC") || string.IsNullOrWhiteSpace(SettingFile.Key_Read("DisableRPC")))
            {
                SettingFile.Key_Write("DisableRPC", Live_Data.Launcher_Discord_Presence = "0");
            }
            else if ((SettingFile.Key_Read("DisableRPC") == "0") || (SettingFile.Key_Read("DisableRPC") == "1"))
            {
                Live_Data.Launcher_Discord_Presence = SettingFile.Key_Read("DisableRPC");
                if (Live_Data.Launcher_Discord_Presence == "1")
                {
                    /* Now that Settings has been Loaded, Lets Stop RPC */
                    Presence_Launcher.Stop("Close");
                }
            }
            else
            {
                SettingFile.Key_Write("DisableRPC", Live_Data.Launcher_Discord_Presence = "0");
            }

            if (!SettingFile.Key_Exists("IgnoreUpdateVersion") || string.IsNullOrWhiteSpace(SettingFile.Key_Read("IgnoreUpdateVersion")))
            {
                SettingFile.Key_Write("IgnoreUpdateVersion", Live_Data.Update_Version_Skip);
            }
            else
            {
                Live_Data.Update_Version_Skip = SettingFile.Key_Read("IgnoreUpdateVersion");
            }

            if (Launcher_Value.System_Unix && SettingFile.Key_Exists("FilePermission"))
            {
                SettingFile.Key_Delete("FilePermission");
            }
            else if (!Launcher_Value.System_Unix && (!SettingFile.Key_Exists("FilePermission") || string.IsNullOrWhiteSpace(SettingFile.Key_Read("FilePermission"))))
            {
                SettingFile.Key_Write("FilePermission", Live_Data.Write_Permissions = "Unknown");
            }
            else
            {
                Live_Data.Write_Permissions = SettingFile.Key_Read("FilePermission");
            }

            if (!SettingFile.Key_Exists("GameIntegrity") || string.IsNullOrWhiteSpace(SettingFile.Key_Read("FilePermission")))
            {
                SettingFile.Key_Write("GameIntegrity", Live_Data.Game_Integrity = "Unknown");
            }
            else
            {
                Live_Data.Game_Integrity = SettingFile.Key_Read("GameIntegrity");
            }

            if (!SettingFile.Key_Exists("ProxyPort"))
            {
                SettingFile.Key_Write("ProxyPort", Live_Data.Launcher_Proxy_Port);
            }
            else
            {
                Live_Data.Launcher_Proxy_Port = SettingFile.Key_Read("ProxyPort");
            }

            if (!SettingFile.Key_Exists("WebCallMethod") || string.IsNullOrWhiteSpace(SettingFile.Key_Read("WebCallMethod")))
            {
                SettingFile.Key_Write("WebCallMethod", Live_Data.Launcher_WebClient_Method = "WebClient");
            }
            else if (SettingFile.Key_Read("WebCallMethod") == "WebClient" || SettingFile.Key_Read("WebCallMethod") == "WebClientWithTimeout")
            {
                Live_Data.Launcher_WebClient_Method = SettingFile.Key_Read("WebCallMethod");
            }
            else
            {
                Live_Data.Launcher_WebClient_Method = "WebClient";
            }

            if (!SettingFile.Key_Exists("ThemeSupport") || string.IsNullOrWhiteSpace(SettingFile.Key_Read("ThemeSupport")))
            {
                SettingFile.Key_Write("ThemeSupport", Live_Data.Launcher_Theme_Support = "0");
            }
            else if ((SettingFile.Key_Read("ThemeSupport") == "0") || (SettingFile.Key_Read("ThemeSupport") == "1"))
            {
                Live_Data.Launcher_Theme_Support = SettingFile.Key_Read("ThemeSupport");
            }
            else
            {
                SettingFile.Key_Write("ThemeSupport", Live_Data.Launcher_Theme_Support = "0");
            }

            if (!SettingFile.Key_Exists("StreamingSupport") || string.IsNullOrWhiteSpace(SettingFile.Key_Read("StreamingSupport")))
            {
                SettingFile.Key_Write("StreamingSupport", Live_Data.Launcher_Streaming_Support = "0");
            }
            else if ((SettingFile.Key_Read("StreamingSupport") == "0") || (SettingFile.Key_Read("StreamingSupport") == "1"))
            {
                Live_Data.Launcher_Streaming_Support = SettingFile.Key_Read("StreamingSupport");
            }
            else
            {
                SettingFile.Key_Write("StreamingSupport", Live_Data.Launcher_Streaming_Support = "0");
            }
            
            if (!SettingFile.Key_Exists("Insider") || string.IsNullOrWhiteSpace(SettingFile.Key_Read("Insider")))
            {
                SettingFile.Key_Write("Insider", Live_Data.Launcher_Insider = "0");
            }
            else if (!Launcher_Value.Launcher_Insider_Beta && (SettingFile.Key_Read("Insider") == "0") || (SettingFile.Key_Read("Insider") == "1"))
            {
                Live_Data.Launcher_Insider = SettingFile.Key_Read("Insider");
                Log.Core("Insider Status: ".ToUpper() + "Opted Into the Beta Preview -> " + 
                    (Launcher_Value.Launcher_Insider_Beta = Live_Data.Launcher_Insider == "1"));
            }
            else
            {
                SettingFile.Key_Write("Insider", Live_Data.Launcher_Insider = "0");
            }

            if (!Launcher_Value.System_Unix)
            {
                if (!SettingFile.Key_Exists("FirewallLauncher") || string.IsNullOrWhiteSpace(SettingFile.Key_Read("FirewallLauncher")))
                {
                    SettingFile.Key_Write("FirewallLauncher", Live_Data.Firewall_Launcher = "Unknown");
                }
                else
                {
                    Live_Data.Firewall_Launcher = SettingFile.Key_Read("FirewallLauncher");
                }

                if (!SettingFile.Key_Exists("FirewallGame") || string.IsNullOrWhiteSpace(SettingFile.Key_Read("FirewallGame")))
                {
                    SettingFile.Key_Write("FirewallGame", Live_Data.Firewall_Game = "Unknown");
                }
                else
                {
                    Live_Data.Firewall_Game = SettingFile.Key_Read("FirewallGame");
                }

                if (Product_Version.GetWindowsNumber() >= 10.0)
                {
                    if (!SettingFile.Key_Exists("DefenderLauncher") || string.IsNullOrWhiteSpace(SettingFile.Key_Read("DefenderLauncher")))
                    {
                        SettingFile.Key_Write("DefenderLauncher", Live_Data.Defender_Launcher = "Unknown");
                    }
                    else
                    {
                        Live_Data.Defender_Launcher = SettingFile.Key_Read("DefenderLauncher");
                    }

                    if (!SettingFile.Key_Exists("DefenderGame") || string.IsNullOrWhiteSpace(SettingFile.Key_Read("DefenderGame")))
                    {
                        SettingFile.Key_Write("DefenderGame", Live_Data.Defender_Game = "Unknown");
                    }
                    else
                    {
                        Live_Data.Defender_Game = SettingFile.Key_Read("DefenderGame");
                    }
                }
                else if (Product_Version.GetWindowsNumber() < 10.0)
                {
                    if (SettingFile.Key_Exists("DefenderLauncher") || !string.IsNullOrWhiteSpace(SettingFile.Key_Read("DefenderLauncher")))
                    {
                        SettingFile.Key_Delete("DefenderLauncher");
                    }

                    if (SettingFile.Key_Exists("DefenderGame") || !string.IsNullOrWhiteSpace(SettingFile.Key_Read("DefenderGame")))
                    {
                        SettingFile.Key_Delete("DefenderGame");
                    }
                }

                if (Product_Version.GetWindowsNumber() == 6.1 && !SettingFile.Key_Exists("PatchesApplied"))
                {
                    SettingFile.Key_Write("PatchesApplied", Live_Data.Win_7_Patches);
                }
                else if (Product_Version.GetWindowsNumber() == 6.1 && SettingFile.Key_Exists("PatchesApplied"))
                {
                    Live_Data.Win_7_Patches = SettingFile.Key_Read("PatchesApplied");
                }
                else if ((Launcher_Value.System_Unix || Product_Version.GetWindowsNumber() != 6.1) && SettingFile.Key_Exists("PatchesApplied"))
                {
                    SettingFile.Key_Delete("PatchesApplied");
                }
            }

            /* Key Entries to Convert into Boolens */

            Log.Function("Custom Proxy Port:".ToUpper() + " -> " + Proxy_Settings.Custom_Port(Live_Data.Launcher_Proxy_Port + " has been Set"));
            Launcher_Value.Launcher_Alternative_Webcalls(Live_Data.Launcher_WebClient_Method == "WebClient");

            /* Key Entries to Remove (No Longer Needed) */

            if (SettingFile.Key_Exists("LauncherPosX"))
            {
                SettingFile.Key_Delete("LauncherPosX");
            }

            if (SettingFile.Key_Exists("LauncherPosY"))
            {
                SettingFile.Key_Delete("LauncherPosY");
            }

            if (SettingFile.Key_Exists("DisableVerifyHash"))
            {
                SettingFile.Key_Delete("DisableVerifyHash");
            }

            if (SettingFile.Key_Exists("TracksHigh"))
            {
                SettingFile.Key_Delete("TracksHigh");
            }

            if (SettingFile.Key_Exists("ModNetDisabled"))
            {
                SettingFile.Key_Delete("ModNetDisabled");
            }

            if (SettingFile.Key_Exists("ModNetZip"))
            {
                SettingFile.Key_Delete("ModNetZip");
            }

            SettingFile = new Ini_File(Ini_Location.Launcher_Settings);
        }
        /// <summary>Saves all Current Values</summary>
        public static void Save()
        {
            SettingFile = new Ini_File(Ini_Location.Launcher_Settings);

            if (SettingFile.Key_Read("CDN") != Live_Data.Launcher_CDN)
            {
                if (Live_Data.Launcher_CDN.EndsWith("/"))
                {
                    SettingFile.Key_Write("CDN", Live_Data.Launcher_CDN.TrimEnd('/'));
                }
                else
                {
                    SettingFile.Key_Write("CDN", Live_Data.Launcher_CDN);
                }
            }

            if (SettingFile.Key_Read("Language") != Live_Data.Launcher_Language)
            {
                SettingFile.Key_Write("Language", Live_Data.Launcher_Language);
            }

            if (SettingFile.Key_Read("DisableProxy") != Live_Data.Launcher_Proxy)
            {
                SettingFile.Key_Write("DisableProxy", Live_Data.Launcher_Proxy);
            }

            if (SettingFile.Key_Read("DisableRPC") != Live_Data.Launcher_Discord_Presence)
            {
                SettingFile.Key_Write("DisableRPC", Live_Data.Launcher_Discord_Presence);
            }

            if (SettingFile.Key_Read("InstallationDirectory") != Live_Data.Game_Path)
            {
                SettingFile.Key_Write("InstallationDirectory", Live_Data.Game_Path);
            }

            if (!Launcher_Value.System_Unix && SettingFile.Key_Read("OldInstallationDirectory") != Live_Data.Game_Path_Old)
            {
                SettingFile.Key_Write("OldInstallationDirectory", Live_Data.Game_Path_Old);
            }

            if (SettingFile.Key_Read("IgnoreUpdateVersion") != Live_Data.Update_Version_Skip)
            {
                SettingFile.Key_Write("IgnoreUpdateVersion", Live_Data.Update_Version_Skip);
            }

            if (SettingFile.Key_Read("GameIntegrity") != Live_Data.Game_Integrity)
            {
                SettingFile.Key_Write("GameIntegrity", Live_Data.Game_Integrity);
            }

            if (SettingFile.Key_Read("WebCallMethod") != Live_Data.Launcher_WebClient_Method)
            {
                SettingFile.Key_Write("WebCallMethod", Live_Data.Launcher_WebClient_Method);
            }

            if (SettingFile.Key_Read("ThemeSupport") != Live_Data.Launcher_Theme_Support)
            {
                SettingFile.Key_Write("ThemeSupport", Live_Data.Launcher_Theme_Support);
            }

            if (SettingFile.Key_Read("StreamingSupport") != Live_Data.Launcher_Streaming_Support)
            {
                SettingFile.Key_Write("StreamingSupport", Live_Data.Launcher_Streaming_Support);
            }

            if (SettingFile.Key_Read("Insider") != Live_Data.Launcher_Insider)
            {
                SettingFile.Key_Write("Insider", Live_Data.Launcher_Insider);
            }

            if (!Launcher_Value.System_Unix)
            {
                if (SettingFile.Key_Read("FilePermission") != Live_Data.Write_Permissions)
                {
                    SettingFile.Key_Write("FilePermission", Live_Data.Write_Permissions);
                }

                if (SettingFile.Key_Read("FirewallLauncher") != Live_Data.Firewall_Launcher)
                {
                    SettingFile.Key_Write("FirewallLauncher", Live_Data.Firewall_Launcher);
                }

                if (SettingFile.Key_Read("FirewallGame") != Live_Data.Firewall_Game)
                {
                    SettingFile.Key_Write("FirewallGame", Live_Data.Firewall_Game);
                }

                if (Product_Version.GetWindowsNumber() >= 10.0)
                {
                    if (SettingFile.Key_Read("DefenderLauncher") != Live_Data.Defender_Launcher)
                    {
                        SettingFile.Key_Write("DefenderLauncher", Live_Data.Defender_Launcher);
                    }

                    if (SettingFile.Key_Read("DefenderGame") != Live_Data.Defender_Game)
                    {
                        SettingFile.Key_Write("DefenderGame", Live_Data.Defender_Game);
                    }
                }

                if ((SettingFile.Key_Read("PatchesApplied") != Live_Data.Win_7_Patches) && Product_Version.GetWindowsNumber() == 6.1)
                {
                    SettingFile.Key_Write("PatchesApplied", Live_Data.Win_7_Patches);
                }
            }

            SettingFile = new Ini_File(Ini_Location.Launcher_Settings);
        }
    }
}
