using SBRW.Launcher.Core.Proxy.Nancy_;
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
                return Live_Data.Launcher_Legacy_Host_To_IP == "0";
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
                return Live_Data.Launcher_Proxy == "0";
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
                return Live_Data.Launcher_Discord_Presence == "0";
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
                return Live_Data.Launcher_JSON_Frequency_Update_Cache == "1";
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
        /// If Preview for Insider is Enabled
        /// </summary>
        /// <returns>True or False</returns>
        public static bool Preview_Insider()
        {
            if (Live_Data != null)
            {
                return Live_Data.Launcher_Insider == "1";
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
                return Live_Data.Launcher_Insider == "2";
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
            long.TryParse(Live_Data.Launcher_Insider ?? "0", out long Preview_Value);
            return Preview_Value;
        }
        /// <summary>
        /// If Custom Themes should be Used
        /// </summary>
        /// <returns>True or False</returns>
        public static bool Theme_Custom()
        {
            if (Live_Data != null)
            {
                return Live_Data.Launcher_Theme_Support == "1";
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
                return Live_Data.Launcher_Proxy_Domain == "1";
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
                    "0" => Proxy.Log_.CommunicationLogRecord.None,
                    "2" => Proxy.Log_.CommunicationLogRecord.Errors,
                    "3" => Proxy.Log_.CommunicationLogRecord.Responses,
                    "4" => Proxy.Log_.CommunicationLogRecord.Requests,
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
                    "1" => GzipVersion.One,
                    "2" => GzipVersion.Two,
                    "3" => GzipVersion.OneV2,
                    "4" => GzipVersion.Four,
                    _ => GzipVersion.Three,
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
            long.TryParse(Live_Data.Launcher_Proxy_Log_Mode ?? "0", out long Proxy_Log_Value);
            return Proxy_Log_Value;
        }
        /// <summary>
        /// Proxy GZip Version
        /// </summary>
        /// <returns>Numerical Value of Proxy GZip Version</returns>
        public static long Proxy_GZip_Version_Int()
        {
            long.TryParse(Live_Data.Launcher_Proxy_GZip_Version ?? "0", out long Proxy_Log_Value);
            return Proxy_Log_Value;
        }
        /// <summary>
        /// Account Manager Save Display Status
        /// </summary>
        /// <returns></returns>
        public static bool Account_Manager()
        {
            if (Live_Data != null)
            {
                return Live_Data.Launcher_Account_Manager == "1";
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
                return Live_Data.Launcher_Game_Downloader == "0";
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
                return Live_Data.Launcher_Game_Downloader == "1";
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
                return Live_Data.Launcher_Game_Downloader == "2";
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
            long.TryParse(Live_Data.Launcher_Game_Downloader ?? "0", out long Game_Downloader_Value);
            return Game_Downloader_Value;
        }
        /// <summary>
        /// Displays Storage Space Alert
        /// </summary>
        /// <returns>True or False</returns>
        public static bool Storage_Space_Alert()
        {
            if (Live_Data != null)
            {
                return Live_Data.Alert_Storage_Space == "0";
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
    }
}
