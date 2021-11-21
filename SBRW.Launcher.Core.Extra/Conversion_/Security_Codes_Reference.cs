using SBRW.Launcher.Core.Classes.Cache;
using SBRW.Launcher.Core.Classes.Extension.Security_;
using SBRW.Launcher.Core.Classes.Required.System.Windows_;
using SBRW.Launcher.Core.Extra.File_;

namespace SBRW.Launcher.Core.Extra.Conversion_
{
    /// <summary>
    /// Security Center Conversion/Reference Kit Class
    /// </summary>
    public class Security_Codes_Reference
    {
        /// <summary>
        /// Reads the Saved Settings File Security Center State
        /// </summary>
        /// <returns>Security Center Status State</returns>
        public static SecurityCenterCodes Check()
        {
            if (Launcher_Value.System_Unix)
            {
                return SecurityCenterCodes.Unix;
            }
            else if (Save_Settings.Live_Data.Firewall_Launcher == "Excluded" && Save_Settings.Live_Data.Firewall_Game == "Excluded")
            {
                return SecurityCenterCodes.Firewall_Updated;
            }
            else if ((Save_Settings.Live_Data.Firewall_Launcher == "Excluded" && Save_Settings.Live_Data.Firewall_Game == "Not Excluded") ||
                (Save_Settings.Live_Data.Firewall_Launcher == "Unknown" && Save_Settings.Live_Data.Firewall_Game == "Unknown") ||
                (Save_Settings.Live_Data.Firewall_Launcher == "Removed" && Save_Settings.Live_Data.Firewall_Game == "Removed"))
            {
                return SecurityCenterCodes.Firewall_Outdated;
            }
            else if ((Save_Settings.Live_Data.Firewall_Launcher == "Error" && Save_Settings.Live_Data.Firewall_Game == "Error") ||
                (Save_Settings.Live_Data.Firewall_Launcher == "Not Supported" && Save_Settings.Live_Data.Firewall_Game == "Not Supported"))
            {
                return SecurityCenterCodes.Firewall_Error;
            }
            else if ((Product_Version.GetWindowsNumber() >= 10) &&
                Save_Settings.Live_Data.Defender_Launcher == "Excluded" && Save_Settings.Live_Data.Defender_Game == "Excluded")
            {
                return SecurityCenterCodes.Defender_Updated;
            }
            else if ((Product_Version.GetWindowsNumber() >= 10) &&
                ((Save_Settings.Live_Data.Defender_Launcher == "Excluded" && Save_Settings.Live_Data.Defender_Game == "Not Excluded") ||
                (Save_Settings.Live_Data.Defender_Launcher == "Unknown" && Save_Settings.Live_Data.Defender_Game == "Unknown") ||
                (Save_Settings.Live_Data.Defender_Launcher == "Removed" && Save_Settings.Live_Data.Defender_Game == "Removed")))
            {
                return SecurityCenterCodes.Defender_Outdated;
            }
            else if ((Product_Version.GetWindowsNumber() >= 10) &&
                ((Save_Settings.Live_Data.Defender_Launcher == "Error" && Save_Settings.Live_Data.Defender_Game == "Error") ||
                (Save_Settings.Live_Data.Defender_Launcher == "Not Supported" && Save_Settings.Live_Data.Defender_Game == "Not Supported")))
            {
                return SecurityCenterCodes.Defender_Error;
            }
            else if (Save_Settings.Live_Data.Write_Permissions == "Set")
            {
                return SecurityCenterCodes.Permissions_Updated;
            }
            else if (Save_Settings.Live_Data.Write_Permissions == "Error")
            {
                return SecurityCenterCodes.Permissions_Error;
            }
            else if (Save_Settings.Live_Data.Write_Permissions == "Not Set")
            {
                return SecurityCenterCodes.Permissions_Outdated;
            }
            else if ((Save_Settings.Live_Data.Firewall_Launcher == "Not Excluded" && Save_Settings.Live_Data.Firewall_Game == "Not Excluded") ||
                ((Product_Version.GetWindowsNumber() >= 10) &&
                Save_Settings.Live_Data.Defender_Launcher == "Not Excluded" && Save_Settings.Live_Data.Defender_Game == "Not Excluded"))
            {
                return SecurityCenterCodes.Unknown;
            }
            else
            {
                return SecurityCenterCodes.Unknown;
            }
        }
    }
}
