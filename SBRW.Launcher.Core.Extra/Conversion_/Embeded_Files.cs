using SBRW.Launcher.Core.Extra.File_;

namespace SBRW.Launcher.Core.Extra.Conversion_
{
    /// <summary>
    /// Embeded Files Function Extraction
    /// </summary>
    public class Embeded_Files
    {
        /// <summary>
        /// At Compilee Time Constant Static String File
        /// </summary>
        internal const string USXML = "SBRW.Launcher.Core.Extra.Reference.XML_.UserSettings.xml";
        /// <summary>
        /// User Settings File
        /// </summary>
        /// <returns>Embeded Resource XML File in Bytes</returns>
        public static byte[] User_Settings_XML_Bytes()
        {
            return Extract_Resource.AsByte(USXML);
        }
        /// <summary>
        /// User Settings File
        /// </summary>
        /// <returns>Embeded Resource XML File as a String</returns>
        public static string User_Settings_XML_String()
        {
            return Extract_Resource.AsString(USXML);
        }
    }
}
