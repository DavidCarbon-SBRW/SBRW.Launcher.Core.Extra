namespace SBRW.Launcher.Core.Extra.Reference.Ini_
{
    /// <summary>
    /// Ini Format for an Account Information
    /// </summary>
    public class Format_Account
    {
        /// <summary>
        /// Users's Raw Email Locally Saved
        /// </summary>
        public string User_Raw_Email { get; set; }
        /// <summary>
        /// Users's Raw Password Locally Saved
        /// </summary>
        public string User_Raw_Password { get; set; }
        /// <summary>
        /// Users's Hashed Email Locally Saved
        /// </summary>
        public string User_Hashed_Email { get; set; }
        /// <summary>
        /// Users's Hashed Password Locally Saved
        /// </summary>
        public string User_Hashed_Password { get; set; }
        /// <summary>
        /// Server's Address Locally Saved
        /// </summary>
        public string Saved_Server_Address { get; set; }
        /// <summary>
        /// Server's Authentication Version Locally Saved
        /// </summary>
        public string Saved_Server_Hash_Version { get; set; }
    }
}
