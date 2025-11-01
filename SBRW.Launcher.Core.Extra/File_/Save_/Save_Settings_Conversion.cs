using Flurl;
using SBRW.Launcher.Core.Extension.Logging_;
using SBRW.Launcher.Core.Extension.Time_;
using SBRW.Launcher.Core.Proxy.Nancy_;
using System;
using System.IO;

namespace SBRW.Launcher.Core.Extra.File_.Save_
{
    public static partial class Save_Settings
    {
        /// <summary>
        /// User's Desired Host to IP conversion
        /// </summary>
        /// <returns></returns>
        public static bool Legacy_Host_To_IP()
        {
            if (Live_Data != default)
            {
                return Live_Data.Launcher_Legacy_Host_To_IP == false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// Game's File Path
        /// </summary>
        /// <returns></returns>
        public static string Game_Files_Path()
        {
            if (Live_Data != null)
            {
                return Live_Data.Game_Path;
            }
            else
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// Game's Old File Path
        /// </summary>
        /// <returns></returns>
        public static string Game_Files_Path_Old()
        {
            if (Live_Data != null)
            {
                return Live_Data.Game_Path_Old;
            }
            else
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// Users's Choice to Disable Launcher Proxy
        /// </summary>
        /// <returns></returns>
        public static bool Proxy_RunTime()
        {
            if (Live_Data != null)
            {
                return Live_Data.Launcher_Proxy == false;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Users's Choice to Disable Discord Rich Presence
        /// </summary>
        /// <returns></returns>
        public static bool RPC_Discord()
        {
            if (Live_Data != null)
            {
                return Live_Data.Launcher_Discord_Presence == false;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// User's Choice to Disable the Update Cache Frequency for Launcher Related JSON Files
        /// </summary>
        /// <returns></returns>
        public static bool Update_Frequency_JSON()
        {
            if (Live_Data != null)
            {
                return Live_Data.Launcher_JSON_Frequency_Update_Cache == true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Users's Choice to Enable Alternative Web Calls
        /// </summary>
        /// <returns></returns>
        public static bool WebCalls_Alt()
        {
            if (Live_Data != null)
            {
                return Live_Data.Launcher_WebClient_Method == "WebClientWithTimeout";
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Web Call Requests Timeout
        /// </summary>
        /// <returns>Numerical Value of Web Call Request Timeout</returns>
        public static int WebCalls_Timeout()
        {
            if ((Live_Data.Launcher_WebCall_TimeOut_Time < 0) || (Live_Data.Launcher_WebCall_TimeOut_Time > 179))
            {
                return 0;
            }

            return Live_Data.Launcher_WebCall_TimeOut_Time;
        }
        /// <summary>
        /// If Preview for Insider is Enabled
        /// </summary>
        /// <returns>True or False</returns>
        public static bool Preview_Insider()
        {
            if (Live_Data != null)
            {
                return Live_Data.Launcher_Insider == 1;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// If Preview for Developer is Enabled
        /// </summary>
        /// <returns>True or False</returns>
        public static bool Preview_Developer()
        {
            if (Live_Data != null)
            {
                return Live_Data.Launcher_Insider == 2;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// If Preview for Developer or Insider is Enabled
        /// </summary>
        /// <returns>True or False</returns>
        public static bool Preview_Mode()
        {
            if (Live_Data != null)
            {
                return (Preview_Developer() || Preview_Insider());
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Preview Mode
        /// </summary>
        /// <returns>Numerical Value of Preview</returns>
        public static long Preview_Mode_Int()
        {
            return Live_Data.Launcher_Insider;
        }
        /// <summary>
        /// If Custom Themes should be Used
        /// </summary>
        /// <returns>True or False</returns>
        public static bool Theme_Custom()
        {
            if (Live_Data != null)
            {
                return Live_Data.Launcher_Theme_Support == true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// If Proxy URL Domain should be localhost or 127.0.0.1
        /// </summary>
        /// <returns>True or False</returns>
        public static bool Proxy_Domain()
        {
            if (Live_Data != null)
            {
                return Live_Data.Launcher_Proxy_Domain == true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Proxy Log Record Type
        /// </summary>
        /// <returns>Communication Log Record Type</returns>
        public static Proxy.Log_.CommunicationLogRecord Proxy_Log_Mode()
        {
            if (Live_Data != null)
            {
                return Live_Data.Launcher_Proxy_Log_Mode switch
                {
                    0 => Proxy.Log_.CommunicationLogRecord.None,
                    2 => Proxy.Log_.CommunicationLogRecord.Errors,
                    3 => Proxy.Log_.CommunicationLogRecord.Responses,
                    4 => Proxy.Log_.CommunicationLogRecord.Requests,
                    _ => Proxy.Log_.CommunicationLogRecord.All
                };
            }
            else
            {
                return Proxy.Log_.CommunicationLogRecord.All;
            }
        }
        /// <summary>
        /// Proxy GZip Version
        /// </summary>
        /// <returns>Proxy GZip Version Type</returns>
        public static GzipVersion Proxy_GZip_Version()
        {
            if (Live_Data != null)
            {
                return Live_Data.Launcher_Proxy_GZip_Version switch
                {
                    1 => GzipVersion.One,
                    2 => GzipVersion.Two,
                    3 => GzipVersion.OneV2,
                    4 => GzipVersion.Four,
                    _ => GzipVersion.Three
                };
            }
            else
            {
                return GzipVersion.Three;
            }
        }
        /// <summary>
        /// Proxy Log Mode
        /// </summary>
        /// <returns>Numerical Value of Proxy Log</returns>
        public static long Proxy_Log_Mode_Int()
        {
            return Live_Data.Launcher_Proxy_Log_Mode;
        }
        /// <summary>
        /// Proxy GZip Version
        /// </summary>
        /// <returns>Numerical Value of Proxy GZip Version</returns>
        public static long Proxy_GZip_Version_Int()
        {
            return Live_Data.Launcher_Proxy_GZip_Version;
        }
        /// <summary>
        /// Proxy Port Number
        /// </summary>
        /// <returns>Numerical Value of Proxy Port</returns>
        public static int Proxy_Port_Int()
        {
            int Proxy_Port_Convert = 0;
            if (int.TryParse(Live_Data.Launcher_Proxy_Port ?? "0", out Proxy_Port_Convert))
            {
                if ((Proxy_Port_Convert < 0) || (Proxy_Port_Convert > 65353))
                {
                    Proxy_Port_Convert = 0;
                }
            }
            else
            {
                Proxy_Port_Convert = 0;
            }

            return Proxy_Port_Convert;
        }
        /// <summary>
        /// Log Cleanup Schedule
        /// </summary>
        /// <returns>DateTime of Converted Value, otherwise returns default (null) value of DateTime</returns>
        public static DateTime Log_Cleanup_Schedule()
        {
            if (Live_Data != null)
            {
                if (DateTime.TryParse(Live_Data.Launcher_Log_Schedule, out DateTime Converted_Time))
                {
                    return Converted_Time;
                }
                else
                {
                    return default;
                }
            }
            else
            {
                return default;
            }
        }
        /// <summary>
        /// Launcher Log Mode
        /// </summary>
        /// <returns>Launcher Log Mode Type</returns>
        public static Log_Enum Log_Mode()
        {
            if (Live_Data != null)
            {
                return Live_Data.Launcher_Log_Mode switch
                {
                    0 => Log_Enum.None,
                    2 => Log_Enum.Error,
                    3 => Log_Enum.Information,
                    4 => Log_Enum.Debug,
                    _ => Log_Enum.All
                };
            }
            else
            {
                return Log_Enum.All;
            }
        }
        /// <summary>
        /// Launcher Log Mode
        /// </summary>
        /// <returns>Numerical Value of Launcher Log</returns>
        public static long Log_Cleanup_Mode_Int()
        {
            return Live_Data.Launcher_Log_Schedule_Mode;
        }
        /// <summary>
        /// Launcher Log Mode
        /// </summary>
        /// <returns>Launcher Log Mode Type</returns>
        public static Log_Enum_Cleanup Log_Cleanup_Mode()
        {
            if (Live_Data != null)
            {
                return Live_Data.Launcher_Log_Schedule_Mode switch
                {
                    0 => Log_Enum_Cleanup.None,
                    1 => Log_Enum_Cleanup.Daily,
                    2 => Log_Enum_Cleanup.Weekly,
                    _ => Log_Enum_Cleanup.Monthly
                };
            }
            else
            {
                return Log_Enum_Cleanup.Monthly;
            }
        }
        /// <summary>
        /// Launcher Cleanup
        /// </summary>
        /// <returns>True if last saved time has elapsed, otherwise False</returns>
        public static bool Log_Cleanup()
        {
            if (Live_Data != null)
            {
                return Log_Cleanup_Schedule() <= Time_Clock.UnixEpoch().CompareNetworkWithPCTime();
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Launcher Log Mode
        /// </summary>
        /// <returns>Numerical Value of Launcher Log</returns>
        public static long Log_Mode_Int()
        {
            return Live_Data.Launcher_Log_Mode;
        }
        /// <summary>
        /// Launcher Log Mode
        /// </summary>
        /// <returns>Launcher Log Mode Type</returns>
        public static Log_Enum_Verify Verify_Log_Mode()
        {
            if (Live_Data != null)
            {
                return Live_Data.Launcher_Verify_Log_Mode switch
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
            else
            {
                return Log_Enum_Verify.All;
            }
        }
        /// <summary>
        /// Launcher Verify Log Mode
        /// </summary>
        /// <returns>Numerical Value of Launcher Verify Log</returns>
        public static long Verify_Log_Int()
        {
            return Live_Data.Launcher_Verify_Log_Mode;
        }
        /// <summary>
        /// Removal of Scripts Folder for Verify Scan
        /// </summary>
        /// <returns>True if User has enabled/allowed the removal of the scripts folder,
        /// otherwise False</returns>
        public static bool Verify_Script_Removal()
        {
            if (Live_Data != null)
            {
                return Live_Data.Launcher_Verify_Script_Removal == true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// User's Choice of Certificate Mode Functions
        /// </summary>
        /// <returns>Converted String to Long</returns>
        public static long Certificate_Mode_Int()
        {
            return Live_Data.Launcher_Certificate_Mode ? 1 : 0;
        }
        /// <summary>
        /// User's Choice of Certificate Mode
        /// </summary>
        /// <returns>True if User's allows the install of Custom Certificate,
        /// otherwise False</returns>
        public static bool Certificate_Mode()
        {
            if (Live_Data != null)
            {
                return Live_Data.Launcher_Certificate_Mode == true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Account Manager Save Display Status
        /// </summary>
        /// <returns></returns>
        public static bool Account_Manager()
        {
            if (Live_Data != null)
            {
                return Live_Data.Launcher_Account_Manager == true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Game Affinity Range Mode Status
        /// </summary>
        /// <returns>True if user has enabled a custom range of Affinity, 
        /// otherwise returns False</returns>
        public static bool Game_Affinity_Range_Mode()
        {
            if (Live_Data != null)
            {
                return Live_Data.Launcher_Game_Affinity_Range_Mode == true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Game Affinity Range Value if Set
        /// </summary>
        /// <returns>User's set range, otherwise defaults to 4 cores (0, 3) </returns>
        public static int[] Game_Affinity_Range()
        {
            if (Live_Data != null)
            {
                return Live_Data.Game_Affinity_Range;
            }
            else
            {
                return new int[] { 0, 3 };
            }
        }
        /// <summary>
        /// If the Game Downloader is Set to use LZMA
        /// </summary>
        /// <returns>True or False</returns>
        public static bool Downloader_Game_LZMA()
        {
            if (Live_Data != null)
            {
                return Live_Data.Launcher_Game_Downloader == 0;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// If the Game Downloader is Set to use Pack
        /// </summary>
        /// <returns>True or False</returns>
        public static bool Downloader_Game_Pack()
        {
            if (Live_Data != null)
            {
                return Live_Data.Launcher_Game_Downloader == 1;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// If the Game Downloader is Set to use Raw
        /// </summary>
        /// <returns>True or False</returns>
        public static bool Downloader_Game_Raw()
        {
            if (Live_Data != null)
            {
                return Live_Data.Launcher_Game_Downloader == 2;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Game Downloader Mode
        /// </summary>
        /// <returns>Numerical Value of Game Downloader</returns>
        public static long Downloader_Game()
        {
            return Live_Data.Launcher_Game_Downloader;
        }
        /// <summary>
        /// Display Timer - Static
        /// </summary>
        /// <returns>True for Static Time, otherwise False</returns>
        public static bool Display_Timer_Static()
        {
            if (Live_Data != null)
            {
                return Live_Data.Launcher_Display_Timer == 0;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Display Timer - Dynamic
        /// </summary>
        /// <returns>True for Time Countdown, otherwise False</returns>
        public static bool Display_Timer_Dynamic()
        {
            if (Live_Data != null)
            {
                return Live_Data.Launcher_Display_Timer == 1;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Display Timer - None
        /// </summary>
        /// <returns>True for No Timer on Window Handle, otherwise False</returns>
        public static bool Display_Timer_None()
        {
            if (Live_Data != null)
            {
                return Live_Data.Launcher_Display_Timer == 2;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Display Timer Mode
        /// </summary>
        /// <returns>Numerical Value of Display Timer</returns>
        public static long Display_Timer()
        {
            return Live_Data.Launcher_Display_Timer;
        }
        /// <summary>
        /// Displays Storage Space Alert
        /// </summary>
        /// <returns>True or False</returns>
        public static bool Storage_Space_Alert()
        {
            if (Live_Data != null)
            {
                return Live_Data.Alert_Storage_Space == false;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Path Location for Game Files Archive File
        /// </summary>
        /// <returns>
        /// Example: <b>C:\Soapbox Race World\Game Files\.Launcher\Downloads\GameFiles.sbrwpack</b><br/>
        /// OR <b><see cref="string.Empty"/></b>
        /// </returns>
        public static string Game_Archive_Path()
        {
            if (Live_Data != null)
            {
                return Live_Data.Game_Archive_Location;
            }
            else
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// Default Path Location for Game Files Archive File
        /// </summary>
        /// <param name="Game_Folder_Path"></param>
        /// <returns>
        /// Example: <b>C:\Soapbox Race World\Game Files\.Launcher\Downloads\GameFiles.sbrwpack</b><br/>
        /// OR <b>\.Launcher\Downloads\GameFiles.sbrwpack</b>
        /// </returns>
        public static string Game_Archive_Path_Primary(this string Game_Folder_Path)
        {
            if (!string.IsNullOrWhiteSpace(Game_Folder_Path))
            {
                return Path.Combine(Game_Folder_Path, ".Launcher", "Downloads", "GameFiles.sbrwpack");
            }
            else
            {
                return Path.Combine(".Launcher", "Downloads", "GameFiles.sbrwpack");
            }
        }
        /// <summary>
        /// Secondary Path Location for Game Files Archive File
        /// </summary>
        /// <param name="Game_Folder_Path"></param>
        /// <returns>
        /// Example: <b>C:\Soapbox Race World\Launcher\Launcher_Data\Archive\GameFiles.sbrwpack</b><br/>
        /// OR <b>\Launcher_Data\Archive\GameFiles.sbrwpack</b>
        /// </returns>
        public static string Game_Archive_Path_Secondary(this string Game_Folder_Path)
        {
            if (!string.IsNullOrWhiteSpace(Game_Folder_Path))
            {
                return Path.Combine(Game_Folder_Path, "Launcher_Data", "Archive", "GameFiles.sbrwpack");
            }
            else
            {
                return Path.Combine("Launcher_Data", "Archive", "GameFiles.sbrwpack");
            }
        }
        /// <summary>
        /// Secondary Path Location for Game Files Archive File
        /// </summary>
        /// <param name="Game_Folder_Path"></param>
        /// <returns>
        /// Example: <b>C:\Soapbox Race World\Launcher\Launcher_Data\Archive\Game Files\GameFiles.sbrwpack</b><br/>
        /// OR <b>\Launcher_Data\Archive\Game Files\GameFiles.sbrwpack</b>
        /// </returns>
        public static string Game_Archive_Path_Secondary_Old(this string Game_Folder_Path)
        {
            if (!string.IsNullOrWhiteSpace(Game_Folder_Path))
            {
                return Path.Combine(Game_Folder_Path, "Launcher_Data", "Archive", "Game Files", "GameFiles.sbrwpack");
            }
            else
            {
                return Path.Combine("Launcher_Data", "Archive", "Game Files", "GameFiles.sbrwpack");
            }
        }
        /// <summary>
        /// Legacy File path that existed for launchers 2.1.4.X - 2.1.5.X
        /// </summary>
        /// <param name="Game_Folder_Path"></param>
        /// <remarks>Example: C:\Soapbox Race World\Launcher\GameFiles.sbrwpack</remarks>
        /// <returns>
        /// Example: <b>C:\Soapbox Race World\Launcher\GameFiles.sbrwpack</b><br/>
        /// OR <b>GameFiles.sbrwpack</b>
        /// </returns>
        public static string Game_Archive_Path_Legacy(this string Game_Folder_Path)
        {
            if (!string.IsNullOrWhiteSpace(Game_Folder_Path))
            {
                return Path.Combine(Game_Folder_Path, "GameFiles.sbrwpack");
            }
            else
            {
                return "GameFiles.sbrwpack";
            }
        }
        /// <summary>
        /// Game File Integrity
        /// </summary>
        /// <returns>True if Value was set to "Good", otherwise False</returns>
        public static bool Game_Integrity_Good()
        {
            if (Live_Data != null)
            {
                return Live_Data.Game_Integrity == "Good";
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Game File Integrity
        /// </summary>
        /// <returns>True if Value was set to "Bad", otherwise False</returns>
        public static bool Game_Integrity_Bad()
        {
            if (Live_Data != null)
            {
                return Live_Data.Game_Integrity == "Bad";
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Game File Integrity
        /// </summary>
        /// <returns>True if Value was set to "Ignore", otherwise False</returns>
        public static bool Game_Integrity_Ignore()
        {
            if (Live_Data != null)
            {
                return Live_Data.Game_Integrity == "Ignore";
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Game File Integrity
        /// </summary>
        /// <returns>True if Value was set to "Unknown", otherwise False</returns>
        public static bool Game_Integrity_Unknown()
        {
            if (Live_Data != null)
            {
                return Live_Data.Game_Integrity == "Unknown";
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Time Server should be active
        /// </summary>
        /// <returns>True if Not Default or Null, otherwise False</returns>
        public static bool Time_Server_Mode()
        {
            if (Live_Data != null)
            {
                return !string.IsNullOrWhiteSpace(Live_Data.Launcher_Time_Server_URL) &&
                    (Live_Data.Launcher_Time_Server_URL != Time_Server.Static_Time_Server);
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string Time_Server_URL()
        {
            if (Time_Server_Mode())
            {
                return new Url(Live_Data.Launcher_Time_Server_URL).Host;
            }
            else
            {
                return Time_Server.Static_Time_Server;
            }
        }
    }
}