using SBRW.Launcher.Core.Extra.Ini_;
using System.IO;

namespace SBRW.Launcher.Core.Extra.XML_
{
    /// <summary>
    /// XML Location and Name Class
    /// </summary>
    public class XML_Location
    {
        /// <summary>
        /// Roaming App Data Game Settings Folder Location
        /// </summary>
        public static string RoamingAppDataFolder_Game_Settings 
        {
            get
            {
                return Path.Combine(Ini_Location.RoamingAppDataFolder, "Need for Speed World", "Settings");
            }
        }
        /// <summary>
        /// Roaming App Data Game Settings XML Location
        /// </summary>
        public static string RoamingAppData_Game_XML 
        {
            get 
            { 
                return Path.Combine(RoamingAppDataFolder_Game_Settings, "UserSettings.xml");
            }
        }
    }
}
