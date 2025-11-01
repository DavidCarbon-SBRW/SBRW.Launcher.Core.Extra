using SBRW.Launcher.Core.Extra.Ini_;
using SBRW.Launcher.Core.Extra.Reference.Ini_;
using System;

namespace SBRW.Launcher.Core.Extra.File_.Save_
{
    /// <summary>
    /// Global Settings Save System
    /// </summary>
    /// <remarks>Used to set Values and Save them</remarks>
    public static partial class Save_Settings
    {
        /// <summary>
        /// The active settings data
        /// </summary>
        public static Format_Settings Live_Data { get; set; } = new Format_Settings();
        /// <summary>
        /// Settings File Information on Disk
        /// </summary>
        private static Ini_File SettingFile { get; set; }
        /// <summary>
        /// Helper to write a setting only if it has changed.
        /// </summary>
        private static void WriteSetting<T>(string key, T value, Action<string, T> onChanged = null)
        {
            // Use the appropriate read method to get the current value for comparison
            string currentValue = SettingFile.Key_Read(key);
            string newValue = value?.ToString();

            if (value is bool boolValue)
            {
                newValue = boolValue ? "1" : "0";
            }

            if (currentValue != newValue)
            {
                // Use the new strongly-typed Key_Write overloads
                if (value is bool b) SettingFile.Key_Write(key, b);
                else if (value is int i) SettingFile.Key_Write(key, i);
                else SettingFile.Key_Write(key, newValue);

                onChanged?.Invoke(key, value);
            }
        }
        /// <summary>
        /// Helper to remove a setting only if it is no longer needed.
        /// </summary>
        /// <param name="key"></param>
        private static void RemoveSetting(string key)
        {
            if (SettingFile.Key_Exists(key))
            {
                SettingFile.Key_Delete(key);
            }
        }
        /// <summary>
        /// Helper to migrate an old accounts data from Setting.ini to Account.ini
        /// </summary>
        private static void MigrateAccountsToSeperateFile(string oldKey, Action<string> setValue)
        {
            if (SettingFile.Key_Exists(oldKey))
            {
                setValue(SettingFile.Key_Read(oldKey));
                SettingFile.Key_Delete(oldKey);
                Save_Account.Save();
            }
        }
    }
}