using SBRW.Launcher.Core.Extension.Time_;

namespace SBRW.Launcher.Core.Extra.Reference.Ini_
{
    /// <summary>
    /// Ini Format for an Settings Information
    /// </summary>
    public class Format_Settings
    {
        #region File/Folder Paths
        /// <summary>
        /// Game Files Path
        /// </summary>
        public string Game_Path { get; set; }
        /// <summary>
        /// Old Game Files Path
        /// </summary>
        /// <remarks><i>Usually when User changes Path Locations</i></remarks>
        public string Game_Path_Old { get; set; }
        /// <summary>
        /// Saved Game Archive Path
        /// </summary>
        public string Game_Archive_Location { get; set; }
        #endregion
        #region Launcher
        /// <summary>
        /// Users's Choice Game Files CDN
        /// </summary>
        /// <remarks><i>Does not Affect Server Mod Files Delivery</i></remarks>
        public string Launcher_CDN { get; set; } = "http://localhost";
        /// <summary>
        /// Users's Choice for a Specific Language
        /// </summary>
        public string Launcher_Language { get; set; } = "EN";
        /// <summary>
        /// Users's Choice to use Launcher Proxy
        /// </summary>
        /// <remarks>Default: True</remarks>
        public bool Launcher_Proxy { get; set; } = true;
        /// <summary>
        /// Users's Manual Specified Choice on a Proxy Port
        /// </summary>
        /// <remarks><i>OverRides Generated Port</i></remarks>
        public string Launcher_Proxy_Port { get; set; }
        /// <summary>
        /// Users's Domain such as LocalHost
        /// </summary>
        public bool Launcher_Proxy_Domain { get; set; }
        /// <summary>
        /// Users's Choice to use Discord Rich Presence
        /// </summary>
        /// <remarks>Default: True</remarks>
        public bool Launcher_Discord_Presence { get; set; } = true;
        /// <summary>
        /// Users's Choice to Enable Alternative Web Calls
        /// </summary>
        /// <remarks><i>Usually WebClientWithTimeout</i></remarks>
        public string Launcher_WebClient_Method { get; set; } = "WebClient";
        /// <summary>
        /// Users's Choice of use of Launcher's Custom Theme
        /// </summary>
        /// <remarks>Default: False</remarks>
        public bool Launcher_Theme_Support { get; set; } = false;
        /// <summary>
        /// Users's Choice on Opting Into Insider Builds
        /// </summary>
        /// <remarks>0 = Stable (Default)<br/>1 = Beta<br/>2 = Dev<br/></remarks>
        public long Launcher_Insider { get; set; } = 0;
        /// <summary>
        /// Users's Choice of Game Downloader Method
        /// </summary>
        public long Launcher_Game_Downloader { get; set; } = 0;
        /// <summary>
        /// User's Choice to Change the Update Cache Frequency for Launcher Related JSON Files
        /// </summary>
        public bool Launcher_JSON_Frequency_Update_Cache { get; set; } = false;
        /// <summary>
        /// Users's Choice to Display Different Window Timers
        /// </summary>
        /// <remarks>0 = Static Timer (Default)<br/> 1 = Dynamic Timer<br/> 2 = No Timer</remarks>
        public long Launcher_Display_Timer { get; set; } = 0;
        /// <summary>
        /// Users's Desired Web Client Timeout
        /// </summary>
        /// <remarks>Default 0 seconds - No Timeout</remarks>
        public int Launcher_WebCall_TimeOut_Time { get; set; } = 0;
        /// <summary>
        /// Launcher's RunTime Environment, which will either limit Pervent Ini Saves or 
        /// Log Details without Enabling Insider Mode. Refer to the Documentation or Ask for Developers help.
        /// </summary>
        /// <remarks>Examples: Internet Cafe, Guest, and/or Development Machine(s)</remarks>
        public long Launcher_RunTime_Environment { get; set; } = 0;
        /// <summary>
        /// User's Desired use of Legacy Host to IP conversion
        /// </summary>
        /// <remarks>Default: True</remarks>
        public bool Launcher_Legacy_Host_To_IP { get; set; } = true;
        /// <summary>
        /// User's Logging Mode Type
        /// </summary>
        public long Launcher_Proxy_Log_Mode { get; set; } = 1;
        /// <summary>
        /// User's Choice on Proxy GZip Version
        /// </summary>
        public long Launcher_Proxy_GZip_Version { get; set; } = 0;
        /// <summary>
        /// User's Choice of Certificate Mode Functions
        /// </summary>
        /// <remarks>Default: False</remarks>
        public bool Launcher_Certificate_Mode { get; set; } = false;
        /// <summary>
        /// User's Logging Mode Type
        /// </summary>
        public long Launcher_Log_Mode { get; set; } = 1;
        /// <summary>
        /// User's Logging Mode Type
        /// </summary>
        public long Launcher_Verify_Log_Mode { get; set; } = 1;
        /// <summary>
        /// User's Choice on removing the Scripts Folder during Verify Hash Scan
        /// </summary>
        /// <remarks>Default: False</remarks>
        public bool Launcher_Verify_Script_Removal { get; set; } = false;
        /// <summary>
        /// User's Choice on Log File removal
        /// </summary>
        public long Launcher_Log_Schedule_Mode { get; set; } = 3;
        /// <summary>
        /// User's Choice on Log File removal Schedule in Unix Time
        /// </summary>
        public string Launcher_Log_Schedule { get; set; } = Time_Clock.UnixEpoch().CompareNetworkWithPCTime().AddMonths(1).ToString();
        /// <summary>
        /// User's Saved Time Server URL
        /// </summary>
        public string Launcher_Time_Server_URL { get; set; } = "time.google.com";
        /// <summary>
        /// User's Choice to use the Account Manager
        /// </summary>
        /// <remarks>Default: False</remarks>
        public bool Launcher_Account_Manager { get; set; } = false;
        #endregion
        #region Game
        /// <summary>
        /// Game Files Integrity
        /// </summary>
        /// <remarks><i>Caused by an Error when cleaning up '.orig' files</i></remarks>
        public string Game_Integrity { get; set; } = "Unknown";
        /// <summary>
        /// User's Game Affinity Simple Mode
        /// </summary>
        /// <remarks>Default: False</remarks>
        public bool Launcher_Game_Affinity_Range_Mode { get; set; } = false;
        /// <summary>
        /// User's Game Affinity Range "Advanced"
        /// </summary>
        public int[] Game_Affinity_Range { get; set; } = new int[] { 0, 3 };
        #endregion
        #region System
        /// <summary>
        /// Launcher Update Version Skip
        /// </summary>
        /// <remarks><i>User's Choice</i></remarks>
        public string Update_Version_Skip { get; set; }
        /// <summary>
        /// Windows Firewall Status for Launcher
        /// </summary>
        /// <remarks><i>Is Manually Set by a Launcher Function</i></remarks>
        public string Firewall_Launcher { get; set; } = "Unknown";
        /// <summary>
        /// Windows Firewall Status for Game
        /// </summary>
        /// <remarks><i>Is Manually Set by a Launcher Function</i></remarks>
        public string Firewall_Game { get; set; } = "Unknown";
        /// <summary>
        /// Windows Defender Status for Launcher
        /// </summary>
        /// <remarks><i>Is Manually Set by a Launcher Function</i></remarks>
        public string Defender_Launcher { get; set; } = "Unknown";
        /// <summary>
        /// Windows Defender Status for Game
        /// </summary>
        /// <remarks><i>Is Manually Set by a Launcher Function</i></remarks>
        public string Defender_Game { get; set; }= "Unknown";
        /// <summary>
        /// Windows 7 Patches
        /// </summary>
        /// <remarks><i>Is Manually Set by a Launcher Function</i></remarks>
        public string Win_7_Patches { get; set; }
        /// <summary>
        /// Launcher Write Status
        /// </summary>
        /// <remarks><i>Is Manually Set by a Launcher Function</i></remarks>
        public string Write_Permissions { get; set; } = "Unknown";
        /// <summary>
        /// User's Desired Alert-Popup about Limited Storage Space
        /// </summary>
        /// <remarks>Default: True</remarks>
        public bool Alert_Storage_Space { get; set; } = true;
        #endregion
    }
}
