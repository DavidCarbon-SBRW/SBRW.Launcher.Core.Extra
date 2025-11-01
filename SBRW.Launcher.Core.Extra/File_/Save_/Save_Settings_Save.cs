using SBRW.Launcher.Core.Cache;
using SBRW.Launcher.Core.Discord.RPC_;
using SBRW.Launcher.Core.Downloader;
using SBRW.Launcher.Core.Extension.Logging_;
using SBRW.Launcher.Core.Extra.Conversion_;
using SBRW.Launcher.Core.Extra.Ini_;
using SBRW.Launcher.Core.Proxy.Nancy_;
using SBRW.Launcher.Core.Recommended.Time_;
using SBRW.Launcher.Core.Required.System.Windows_;

namespace SBRW.Launcher.Core.Extra.File_.Save_
{
    public static partial class Save_Settings
    {
        /// <summary>
        /// Saves all Current Values from Live_Data to the settings file.
        /// </summary>
        public static void Save()
        {
            SettingFile = new Ini_File(Ini_Location.Launcher_Settings);

            WriteSetting("InstallationDirectory", Live_Data.Game_Path);
            if (!Launcher_Value.System_Unix)
            {
                WriteSetting("OldInstallationDirectory", Live_Data.Game_Path_Old);
            }
            WriteSetting("GameArchivePath", Live_Data.Game_Archive_Location);
            WriteSetting("CDN", Live_Data.Launcher_CDN?.TrimEnd('/'));
            WriteSetting("Language", Live_Data.Launcher_Language);
            WriteSetting("DisableProxy", Live_Data.Launcher_Proxy, HandleProxyChange);
            WriteSetting("DisableRPC", Live_Data.Launcher_Discord_Presence, HandleRpcChange);
            WriteSetting("IgnoreUpdateVersion", Live_Data.Update_Version_Skip);
            WriteSetting("FilePermission", Live_Data.Write_Permissions);
            WriteSetting("GameIntegrity", Live_Data.Game_Integrity);
            WriteSetting("ProxyPort", Live_Data.Launcher_Proxy_Port, (key, value) => Log.Function($"Custom Proxy Port: -> {Proxy_Settings.Custom_Port(value)} has been Set"));
            WriteSetting("WebCallMethod", Live_Data.Launcher_WebClient_Method, HandleWebCallMethodChange);
            WriteSetting("ThemeSupport", Live_Data.Launcher_Theme_Support);
            WriteSetting("Insider", Live_Data.Launcher_Insider, HandleInsiderChange);
            WriteSetting("DisplayTimer", Live_Data.Launcher_Display_Timer, HandleDisplayTimerChange);
            WriteSetting("DownloaderGame", Live_Data.Launcher_Game_Downloader);
            WriteSetting("JSONFrequencyUpdateCache", Live_Data.Launcher_JSON_Frequency_Update_Cache);
            WriteSetting("WebCallTimeOut", Live_Data.Launcher_WebCall_TimeOut_Time, HandleWebCallTimeOutChange);

            if (!Launcher_Value.System_Unix)
            {
                WriteSetting("FirewallLauncher", Live_Data.Firewall_Launcher);
                WriteSetting("FirewallGame", Live_Data.Firewall_Game);

                if (Product_Version.GetWindowsBuildNumber() >= 10.0)
                {
                    WriteSetting("DefenderLauncher", Live_Data.Defender_Launcher);
                    WriteSetting("DefenderGame", Live_Data.Defender_Game);
                }

                if (Product_Version.GetWindowsBuildNumber() == 6.1)
                {
                    WriteSetting("PatchesApplied", Live_Data.Win_7_Patches);
                }
            }
            else
            {
                WriteSetting("AlertStorage", Live_Data.Alert_Storage_Space);
            }

            WriteSetting("LauncherEnvironment", Live_Data.Launcher_RunTime_Environment);
            WriteSetting("LegacyHost2IP", Live_Data.Launcher_Legacy_Host_To_IP);
            WriteSetting("ProxyHostDomain", Live_Data.Launcher_Proxy_Domain, HandleProxyDomainChange);
            WriteSetting("ProxyLogMode", Live_Data.Launcher_Proxy_Log_Mode, HandleProxyLogModeChange);
            WriteSetting("GameAffinityRangeMode", Live_Data.Launcher_Game_Affinity_Range_Mode);
            WriteSetting("GameAffinityRange", Live_Data.Game_Affinity_Range.ArrayToString());
            WriteSetting("AccountManager", Live_Data.Launcher_Account_Manager);
            WriteSetting("ProxyGZipVersion", Live_Data.Launcher_Proxy_GZip_Version, HandleProxyGZipVersionChange);
            WriteSetting("LogMode", Live_Data.Launcher_Log_Mode, HandleLogModeChange);
            WriteSetting("VerifyLogMode", Live_Data.Launcher_Verify_Log_Mode, HandleVerifyLogModeChange);
            WriteSetting("VerifyScriptRemoval", Live_Data.Launcher_Verify_Script_Removal);
            WriteSetting("Certificate", Live_Data.Launcher_Certificate_Mode);
            WriteSetting("LogCleanup", Live_Data.Launcher_Log_Schedule_Mode);
            WriteSetting("LogCleanupSchedule", Live_Data.Launcher_Log_Schedule);
            WriteSetting("TimeServerURL", Live_Data.Launcher_Time_Server_URL);
            /* Flush Changes to Disk */
            SettingFile = new Ini_File(Ini_Location.Launcher_Settings);
        }

        private static void HandleWebCallTimeOutChange(this string key, int webCallTimeOut)
        {
            if (webCallTimeOut > 0)
            {
                Download_Settings.Launcher_WebCall_Timeout(Launcher_Value.Launcher_WebCall_Timeout(webCallTimeOut));
                Download_Settings.Launcher_WebCall_Timeout_Enable = Launcher_Value.Launcher_WebCall_Timeout_Enable = true;
            }
            else
            {
                Download_Settings.Launcher_WebCall_Timeout_Enable = Launcher_Value.Launcher_WebCall_Timeout_Enable = false;
            }
        }

        private static void HandleVerifyLogModeChange(this string key, long verifyLogMode)
        {
            Log_Verify.Mode = verifyLogMode switch
            {
                0 => Log_Enum_Verify.None,
                2 => Log_Enum_Verify.Error,
                3 => Log_Enum_Verify.Information,
                4 => Log_Enum_Verify.Replaced,
                5 => Log_Enum_Verify.Hashes,
                6 => Log_Enum_Verify.Validation,
                _ => Log_Enum_Verify.All
            };
        }

        private static void HandleLogModeChange(this string key, long logMode)
        {
            Log.Mode = logMode switch
            {
                0 => Log_Enum.None,
                2 => Log_Enum.Error,
                3 => Log_Enum.Information,
                4 => Log_Enum.Debug,
                _ => Log_Enum.All
            };
        }

        private static void HandleWebCallMethodChange(this string key, string webCallMethod)
        {
            Launcher_Value.Launcher_Alternative_Webcalls(webCallMethod == "WebClient");
        }

        private static void HandleProxyLogModeChange(this string key, long proxyLogMode)
        {
            Proxy_Settings.Log_Mode = proxyLogMode switch
            {
                0 => Proxy.Log_.CommunicationLogRecord.None,
                2 => Proxy.Log_.CommunicationLogRecord.Errors,
                3 => Proxy.Log_.CommunicationLogRecord.Responses,
                4 => Proxy.Log_.CommunicationLogRecord.Requests,
                _ => Proxy.Log_.CommunicationLogRecord.All
            };
        }

        private static void HandleProxyGZipVersionChange(this string key, long proxyGZipVersion)
        {
            Proxy_Settings.Gzip_Version = proxyGZipVersion switch
            {
                1 => GzipVersion.One,
                2 => GzipVersion.Two,
                3 => GzipVersion.OneV2,
                4 => GzipVersion.Four,
                _ => GzipVersion.Three
            };
        }

        // --- Handlers for settings changes ---

        private static void HandleDisplayTimerChange(this string key, long displayTimer)
        {
            /* 0 = Static Timer, 1 = Dynamic Timer, 2 = No Timer */
            if (displayTimer == 1)
            {
                Time_Window.Timer_Dynamic = true;
                Time_Window.Timer_None = false;
            }
            else if (displayTimer == 2)
            {
                /* Notes: This actually does not Display Timers on the Title Window and 'Time_Window.Live_Stream' will be renamed in the future */
                Time_Window.Timer_Dynamic = false;
                Time_Window.Timer_None = true;
            }
            else
            {
                Time_Window.Timer_Dynamic = false;
                Time_Window.Timer_None = false;
            }
        }

        private static void HandleProxyChange(this string key, bool isDisabled)
        {
            if (!isDisabled && !Proxy_Settings.Running())
            {
                Proxy_Server.Instance.Start("SBRW.Launcher.Core.Extra [Save]");
            }
            else if (isDisabled && Proxy_Settings.Running())
            {
                Proxy_Server.Instance.Stop("SBRW.Launcher.Core.Extra [Save]");
            }
        }

        private static void HandleProxyDomainChange(this string key, bool value)
        {
            if (!Live_Data.Launcher_Proxy)
            {
                if (Proxy_Settings.Running())
                {
                    Proxy_Server.Instance.Stop("SBRW.Launcher.Core.Extra [Save (Domain)]");
                }
                Proxy_Settings.Domain = (value == false ? "127.0.0.1" : "localhost");
                Log.Function($"Custom Proxy Domain: -> {Proxy_Settings.Domain} has been Set");
                if (!Proxy_Settings.Running())
                {
                    Proxy_Server.Instance.Start("SBRW.Launcher.Core.Extra [Save (Domain)]");
                }
            }
        }

        private static void HandleRpcChange(this string key, bool isDisabled)
        {
            if (!isDisabled && !Presence_Launcher.Running())
            {
                Presence_Settings.Disable_RPC_Startup = false;
                Presence_Launcher.Start();
            }
            else if (isDisabled && Presence_Launcher.Running())
            {
                Presence_Launcher.Stop("Close");
                Presence_Settings.Disable_RPC_Startup = true;
            }
        }

        private static void HandleInsiderChange(this string key, long insiderValue)
        {
            if (insiderValue >= 0 && insiderValue <= 2)
            {
                Launcher_Value.Launcher_Insider_Dev = insiderValue == 2;
                Launcher_Value.Launcher_Insider_Beta = insiderValue == 1;

                if (insiderValue > 0)
                {
                    var status = insiderValue == 1 ? "Opted Into the Beta Preview" : "Opted Into the Development Preview";
                    Log.Core($"Insider Status: {status.ToUpperInvariant()}");
                }
            }
        }
    }
}