using SBRW.Launcher.Core.Classes.Reference.Ini_;
using SBRW.Launcher.Core.Extra.Ini_;

namespace SBRW.Launcher.Core.Extra.File_
{
    /// <summary>
    /// Global Account Save System
    /// </summary>
    /// <remarks>Used to set Values and Save them</remarks>
    class Save_Account
    {
        /// <summary>Account Format Information In Live Memory</summary>
        public static Format_Account Live_Data = new Format_Account();
        ///<value>Account File Information on Disk</value>
        private static Ini_File AccountFile;
        ///<value>Used to Save Login Information when Remember me is Checked Marked</value>
        public static bool SaveLoginInformation = false;
        /// <summary>
        /// Null Safe Values Checker
        /// </summary>
        /// <remarks>Used to create, update, or remove Values before Critical Launcher Checks</remarks>
        public static void NullSafe()
        {
            AccountFile = new Ini_File(Ini_Location.Launcher_Account);

            if (!AccountFile.Key_Exists("Server"))
            {
                AccountFile.Key_Write("Server", Live_Data.Saved_Server_Address);
            }
            else
            {
                Live_Data.Saved_Server_Address = AccountFile.Key_Read("Server");
            }

            if (!AccountFile.Key_Exists("Hash"))
            {
                AccountFile.Key_Write("Hash", Live_Data.Saved_Server_Hash_Version);
            }
            else
            {
                Live_Data.Saved_Server_Hash_Version = AccountFile.Key_Read("Hash");
            }

            if (!AccountFile.Key_Exists("AccountEmail"))
            {
                AccountFile.Key_Write("AccountEmail", Live_Data.User_Raw_Email);
            }
            else
            {
                Live_Data.User_Raw_Email = AccountFile.Key_Read("AccountEmail");
            }

            if (!AccountFile.Key_Exists("AccountEmailHashed"))
            {
                AccountFile.Key_Write("AccountEmailHashed", Live_Data.User_Hashed_Email);
            }
            else
            {
                Live_Data.User_Hashed_Email = AccountFile.Key_Read("AccountEmailHashed");
            }

            if (AccountFile.Key_Exists("Password"))
            {
                Live_Data.User_Raw_Password = AccountFile.Key_Read("Password");
                AccountFile.Key_Delete("Password");
            }

            if (!AccountFile.Key_Exists("PasswordHashed"))
            {
                AccountFile.Key_Write("PasswordHashed", Live_Data.User_Hashed_Password);
            }
            else
            {
                Live_Data.User_Hashed_Password = AccountFile.Key_Read("PasswordHashed");
            }

            if (!AccountFile.Key_Exists("PasswordRaw"))
            {
                AccountFile.Key_Write("PasswordRaw", Live_Data.User_Raw_Password);
            }
            else if (AccountFile.Key_Exists("PasswordRaw"))
            {
                Live_Data.User_Raw_Password = AccountFile.Key_Read("PasswordRaw");
            }

            AccountFile = new Ini_File(Ini_Location.Launcher_Account);
        }
        /// <summary>
        /// Account Information Saver
        /// </summary>
        /// <remarks>Used to create, update, or remove Values after a successful login</remarks>
        public static void Save()
        {
            AccountFile = new Ini_File(Ini_Location.Launcher_Account);

            if (!AccountFile.Key_Exists("Server") || AccountFile.Key_Read("Server") != Live_Data.Saved_Server_Address)
            {
                AccountFile.Key_Write("Server", Live_Data.Saved_Server_Address);
            }

            if (!AccountFile.Key_Exists("Hash") || AccountFile.Key_Read("Hash") != Live_Data.Saved_Server_Hash_Version)
            {
                AccountFile.Key_Write("Hash", Live_Data.Saved_Server_Hash_Version);
            }

            if (SaveLoginInformation)
            {
                if (!AccountFile.Key_Exists("AccountEmail") || AccountFile.Key_Read("AccountEmail") != Live_Data.User_Raw_Email)
                {
                    AccountFile.Key_Write("AccountEmail", Live_Data.User_Raw_Email);
                }

                if (!AccountFile.Key_Exists("AccountEmailHashed") || AccountFile.Key_Read("AccountEmailHashed") != Live_Data.User_Hashed_Email)
                {
                    AccountFile.Key_Write("AccountEmailHashed", Live_Data.User_Hashed_Email);
                }

                if (!AccountFile.Key_Exists("PasswordHashed") || AccountFile.Key_Read("PasswordHashed") != Live_Data.User_Hashed_Password)
                {
                    AccountFile.Key_Write("PasswordHashed", Live_Data.User_Hashed_Password);
                }

                if (!AccountFile.Key_Exists("PasswordRaw") || AccountFile.Key_Read("PasswordRaw") != Live_Data.User_Raw_Password)
                {
                    AccountFile.Key_Write("PasswordRaw", Live_Data.User_Raw_Password);
                }
            }
            else
            {
                AccountFile.Key_Write("AccountEmail", string.Empty);
                AccountFile.Key_Write("AccountEmailHashed", string.Empty);
                AccountFile.Key_Write("PasswordHashed", string.Empty);
                AccountFile.Key_Write("PasswordRaw", string.Empty);
            }

            AccountFile = new Ini_File(Ini_Location.Launcher_Account);
        }
    }
}
