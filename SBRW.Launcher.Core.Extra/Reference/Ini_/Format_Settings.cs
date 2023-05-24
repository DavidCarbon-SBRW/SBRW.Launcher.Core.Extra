using System;

namespace SBRW.Launcher.Core.Extra.Reference.Ini_
{
    /// <summary>
    /// Ini Format for an Settings Information
    /// </summary>
    public class Format_Settings
    {
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
        /// <summary>
        /// Users's Choice Game Files CDN
        /// </summary>
        /// <remarks><i>Does not Affect Server Mod Files Delivery</i></remarks>
        public string Launcher_CDN { get; set; }
        /// <summary>
        /// Users's Choice for a Specific Language
        /// </summary>
        public string Launcher_Language { get; set; }
        /// <summary>
        /// Users's Choice to Disable Launcher Proxy
        /// </summary>
        public string Launcher_Proxy { get; set; }
        /// <summary>
        /// Users's Choice to Disable Discord Rich Presence
        /// </summary>
        public string Launcher_Discord_Presence { get; set; }
        /// <summary>
        /// Launcher Update Version Skip
        /// </summary>
        /// <remarks><i>User's Choice</i></remarks>
        public string Update_Version_Skip { get; set; }
        /// <summary>
        /// Windows Firewall Status for Launcher
        /// </summary>
        /// <remarks><i>Is Manually Set by a Launcher Function</i></remarks>
        public string Firewall_Launcher { get; set; }
        /// <summary>
        /// Windows Firewall Status for Game
        /// </summary>
        /// <remarks><i>Is Manually Set by a Launcher Function</i></remarks>
        public string Firewall_Game { get; set; }
        /// <summary>
        /// Windows Defender Status for Launcher
        /// </summary>
        /// <remarks><i>Is Manually Set by a Launcher Function</i></remarks>
        public string Defender_Launcher { get; set; }
        /// <summary>
        /// Windows Defender Status for Game
        /// </summary>
        /// <remarks><i>Is Manually Set by a Launcher Function</i></remarks>
        public string Defender_Game { get; set; }
        /// <summary>
        /// Windows 7 Patches
        /// </summary>
        /// <remarks><i>Is Manually Set by a Launcher Function</i></remarks>
        public string Win_7_Patches { get; set; }
        /// <summary>
        /// Launcher Write Status
        /// </summary>
        /// <remarks><i>Is Manually Set by a Launcher Function</i></remarks>
        public string Write_Permissions { get; set; }
        /// <summary>
        /// Game Files Integrity
        /// </summary>
        /// <remarks><i>Caused by an Error when cleaning up '.orig' files</i></remarks>
        public string Game_Integrity { get; set; }
        /// <summary>
        /// Users's Manual Specified Choice on a Proxy Port
        /// </summary>
        /// <remarks><i>OverRides Generated Port</i></remarks>
        public string Launcher_Proxy_Port { get; set; }
        /// <summary>
        /// Users's Choice to Enable Alternative Web Calls
        /// </summary>
        /// <remarks><i>Usually WebClientWithTimeout</i></remarks>
        public string Launcher_WebClient_Method { get; set; }
        /// <summary>
        /// Users's Choice to Enable "Native" Window Video Capture Support
        /// </summary>
        public string Launcher_Theme_Support { get; set; }
        /// <summary>
        /// Users's Choice to Enable "Native" Window Video Capture Support
        /// </summary>
        [Obsolete("Instead use 'Launcher_Legacy_Timer'")]
        public string Launcher_Streaming_Support { get; set; }
        /// <summary>
        /// Users's Choice on Opting Into Insider Builds
        /// </summary>
        public string Launcher_Insider { get; set; }
        /// <summary>
        /// Users's Choice to Enable Legacy Window Timer Support
        /// </summary>
        /// <remarks>Formally: <see cref="Launcher_Streaming_Support"/></remarks>
        [Obsolete("Instead use 'Launcher_Display_Timer'")]
        public string Launcher_Legacy_Timer { get; set; }
        /// <summary>
        /// Users's Choice to Enable LZMA Downloader
        /// </summary>
        public string Launcher_LZMA_Downloader { get; set; }
        /// <summary>
        /// User's Choice to Disable the Update Cache Frequency for Launcher Related JSON Files
        /// </summary>
        public string Launcher_JSON_Frequency_Update_Cache { get; set; }
        /// <summary>
        /// Users's Choice to Display Different Window Timers
        /// </summary>
        /// <remarks>Formally: <see cref="Launcher_Legacy_Timer"/></remarks>
        public string Launcher_Display_Timer { get; set; }
        /// <summary>
        /// Users's Desired Web Client Timeout
        /// </summary>
        public string Launcher_WebCall_TimeOut_Time { get; set; }
        /// <summary>
        /// Launcher's RunTime Environment, which will either limit Pervent Ini Saves or 
        /// Log Details without Enabling Insider Mode. Refer to the Documentation or Ask for Developers help.
        /// </summary>
        /// <remarks>Examples: Internet Cafe, Guest, and/or Development Machine(s)</remarks>
        public string Launcher_RunTime_Environment { get; set; }
        /// <summary>
        /// User's Desired Alert-Popup about Limited Storage Space
        /// </summary>
        public string Alert_Storage_Space { get; set; }
        /// <summary>
        /// User's Desired Host to IP conversion
        /// </summary>
        public string Launcher_Legacy_Host_To_IP { get; set; }
        /// <summary>
        /// Users's Domain such as LocalHost
        /// </summary>
        public string Launcher_Proxy_Domain { get; set; }
        /// <summary>
        /// User's Logging Mode Type
        /// </summary>
        public string Launcher_Proxy_Log_Mode { get; set; }
    }
}
