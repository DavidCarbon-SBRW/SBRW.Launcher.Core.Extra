using SBRW.Launcher.Core.Cache;
using SBRW.Launcher.Core.Extension.Logging_;
using SBRW.Launcher.Core.Required.System.Windows_;
using SBRW.Launcher.Core.Discord.RPC_;
using SBRW.Launcher.Core.Proxy.Nancy_;
using SBRW.Launcher.Core.Extra.Ini_;
using SBRW.Launcher.Core.Extra.Conversion_;

namespace SBRW.Launcher.Core.Extra.File_.Save_
{
    public static partial class Save_Settings
    {
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

                if (Live_Data.Launcher_Proxy == "0")
                {
                    if (!Proxy_Settings.Running())
                    {
                        Proxy_Server.Instance.Start("SBRW.Launcher.Core.Extra [Save]");
                    }
                }
                else if (Live_Data.Launcher_Proxy == "1")
                {
                    if (Proxy_Settings.Running())
                    {
                        Proxy_Server.Instance.Stop("SBRW.Launcher.Core.Extra [Save]");
                    }
                }
            }

            if (SettingFile.Key_Read("ProxyPort") != Live_Data.Launcher_Proxy_Port)
            {
                SettingFile.Key_Write("ProxyPort", Live_Data.Launcher_Proxy_Port);

                Log.Function("Custom Proxy Port:".ToUpper() + " -> " + Proxy_Settings.Custom_Port(Live_Data.Launcher_Proxy_Port) + " has been Set");
            }

            if (SettingFile.Key_Read("ProxyHostDomain") != Live_Data.Launcher_Proxy_Domain)
            {
                SettingFile.Key_Write("ProxyHostDomain", Live_Data.Launcher_Proxy_Domain);

                if (Live_Data.Launcher_Proxy.Equals("0"))
                {
                    if (Proxy_Settings.Running())
                    {
                        Proxy_Server.Instance.Stop("SBRW.Launcher.Core.Extra [Save (Domain)]");
                    }

                    Proxy_Settings.Domain = Live_Data.Launcher_Proxy_Domain.Equals("0") ? "127.0.0.1" : "localhost";
                    Log.Function("Custom Proxy Domain:".ToUpper() + " -> " + Proxy_Settings.Domain + " has been Set");

                    if (!Proxy_Settings.Running())
                    {
                        Proxy_Server.Instance.Start("SBRW.Launcher.Core.Extra [Save (Domain)]");
                    }
                }
            }

            if (SettingFile.Key_Read("DisableRPC") != Live_Data.Launcher_Discord_Presence)
            {
                SettingFile.Key_Write("DisableRPC", Live_Data.Launcher_Discord_Presence);

                if (Live_Data.Launcher_Discord_Presence == "0")
                {
                    if (!Presence_Launcher.Running())
                    {
                        Presence_Settings.Disable_RPC_Startup = false;
                        Presence_Launcher.Start();
                    }
                }
                else if (Live_Data.Launcher_Discord_Presence == "1")
                {
                    if (Presence_Launcher.Running())
                    {
                        /* Now that Settings has been Loaded, Lets Stop RPC */
                        Presence_Launcher.Stop("Close");
                        Presence_Settings.Disable_RPC_Startup = true;
                    }
                }
            }

            if (SettingFile.Key_Read("InstallationDirectory") != Live_Data.Game_Path)
            {
                SettingFile.Key_Write("InstallationDirectory", Live_Data.Game_Path);
            }

            if (!Launcher_Value.System_Unix && SettingFile.Key_Read("OldInstallationDirectory") != Live_Data.Game_Path_Old)
            {
                SettingFile.Key_Write("OldInstallationDirectory", Live_Data.Game_Path_Old);
            }

            if (SettingFile.Key_Read("GameArchivePath") != Live_Data.Game_Archive_Location)
            {
                SettingFile.Key_Write("GameArchivePath", Live_Data.Game_Archive_Location);
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

            if (SettingFile.Key_Read("Insider") != Live_Data.Launcher_Insider)
            {
                SettingFile.Key_Write("Insider", Live_Data.Launcher_Insider);

                if ((SettingFile.Key_Read_Int("Insider") >= 0) && (SettingFile.Key_Read_Int("Insider") <= 2))
                {
                    if (SettingFile.Key_Read_Int("Insider") == 1)
                    {
                        Launcher_Value.Launcher_Insider_Dev = false;
                        Launcher_Value.Launcher_Insider_Beta = true;
                        Log.Core("Insider Status: ".ToUpper() + "Opted Into the Beta Preview");
                    }
                    else if (SettingFile.Key_Read_Int("Insider") == 2)
                    {
                        Launcher_Value.Launcher_Insider_Dev = true;
                        Launcher_Value.Launcher_Insider_Beta = false;
                        Log.Core("Insider Status: ".ToUpper() + "Opted Into the Development Preview");
                    }
                    else
                    {
                        Launcher_Value.Launcher_Insider_Dev = Launcher_Value.Launcher_Insider_Beta = false;
                    }
                }
            }

            if (SettingFile.Key_Read("DisplayTimer") != Live_Data.Launcher_Display_Timer)
            {
                SettingFile.Key_Write("DisplayTimer", Live_Data.Launcher_Display_Timer);
            }

            if (SettingFile.Key_Read("DownloaderGame") != Live_Data.Launcher_Game_Downloader)
            {
                SettingFile.Key_Write("DownloaderGame", Live_Data.Launcher_Game_Downloader);
            }

            if (SettingFile.Key_Read("JSONFrequencyUpdateCache") != Live_Data.Launcher_JSON_Frequency_Update_Cache)
            {
                SettingFile.Key_Write("JSONFrequencyUpdateCache", Live_Data.Launcher_JSON_Frequency_Update_Cache);
            }

            if (SettingFile.Key_Read("WebCallTimeOut") != Live_Data.Launcher_WebCall_TimeOut_Time)
            {
                SettingFile.Key_Write("WebCallTimeOut", Live_Data.Launcher_WebCall_TimeOut_Time);
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
            else if (SettingFile.Key_Read("AlertStorageSpace") != Live_Data.Alert_Storage_Space)
            {
                SettingFile.Key_Write("AlertStorageSpace", Live_Data.Alert_Storage_Space);
            }

            if (SettingFile.Key_Read("LauncherEnvironment") != Live_Data.Launcher_RunTime_Environment)
            {
                SettingFile.Key_Write("LauncherEnvironment", Live_Data.Launcher_RunTime_Environment);
            }

            if (SettingFile.Key_Read("LegacyHost2IP") != Live_Data.Launcher_Legacy_Host_To_IP)
            {
                SettingFile.Key_Write("LegacyHost2IP", Live_Data.Launcher_Legacy_Host_To_IP);
            }

            if (SettingFile.Key_Read("ProxyHostDomain") != Live_Data.Launcher_Proxy_Domain)
            {
                SettingFile.Key_Write("ProxyHostDomain", Live_Data.Launcher_Proxy_Domain);
                Proxy_Settings.Domain = (Live_Data.Launcher_Proxy_Domain == "0") ? "127.0.0.1" : "localhost";
            }

            if (SettingFile.Key_Read("ProxyLogMode") != Live_Data.Launcher_Proxy_Log_Mode)
            {
                SettingFile.Key_Write("ProxyLogMode", Live_Data.Launcher_Proxy_Log_Mode);
                Proxy_Settings.Log_Mode = Live_Data.Launcher_Proxy_Log_Mode switch
                {
                    "0" => Proxy.Log_.CommunicationLogRecord.None,
                    "2" => Proxy.Log_.CommunicationLogRecord.Errors,
                    "3" => Proxy.Log_.CommunicationLogRecord.Responses,
                    "4" => Proxy.Log_.CommunicationLogRecord.Requests,
                    _ => Proxy.Log_.CommunicationLogRecord.All,
                };
            }

            if (SettingFile.Key_Read("ProxyGZipVersion") != Live_Data.Launcher_Proxy_GZip_Version)
            {
                SettingFile.Key_Write("ProxyGZipVersion", Live_Data.Launcher_Proxy_GZip_Version);
                Proxy_Settings.Gzip_Version = Live_Data.Launcher_Proxy_GZip_Version switch
                {
                    "1" => GzipVersion.One,
                    "2" => GzipVersion.Two,
                    "3" => GzipVersion.OneV2,
                    "4" => GzipVersion.Four,
                    _ => GzipVersion.Three,
                };
            }

            if (SettingFile.Key_Read("AccountManager") != Live_Data.Launcher_Account_Manager)
            {
                SettingFile.Key_Write("AccountManager", Live_Data.Launcher_Account_Manager);
            }

            if (SettingFile.Key_Read("GameAffinityRange").Split('-').ToIntArray() != Live_Data.Game_Affinity_Range)
            {
                SettingFile.Key_Write("GameAffinityRange", Live_Data.Game_Affinity_Range.ArrayToString());
            }

            SettingFile = new Ini_File(Ini_Location.Launcher_Settings);
        }
    }
}
