﻿using SBRW.Ini.Parser;
using SBRW.Launcher.Core.Extension.Logging_;
using SBRW.Launcher.Core.Extension.String_;
using System;
using System.IO;

namespace SBRW.Launcher.Core.Extra.Ini_
{
    /// <summary>
    /// Ini File Class
    /// </summary>
    public class Ini_File
    {
        /// <summary>
        /// Ini File Path
        /// </summary>
        public string File_Path { get; set; }
        /// <summary>
        /// Index Header for the Ini File
        /// </summary>
        public string Index_Header { get; set; } = "GameLauncher";
        /// <summary>
        /// Conversion Failure Number to indicate if a value conversion had failed
        /// </summary>
        /// <remarks>Default Number: -2017</remarks>
        public int Conversion_Failure { get; set; } = -2017;
        internal IniDataFile File_Parser { get; set; }
        internal IniData File_Data { get; set; }
        /// <summary>
        /// Loads Ini File
        /// </summary>
        public Ini_File()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(File_Path))
                {
                    File_Path = Index_Header + ".ini".ToLowerInvariant();
                }

                File_Parser = new IniDataFile();
                try
                {
                    if (File.Exists(File_Path))
                    {
                        File_Data = File_Parser.ReadFile(File_Path);
                    }
                    else
                    {
                        if (!File.Exists(File_Path))
                        {
                            File.Create(File_Path).Close();
                        }

                        File_Data = new IniData();
                    }
                }
                catch (Ini.Parser.Exceptions.ParsingException)
                {
                    if (File.Exists(File_Path))
                    {
                        /* Lets create a new .ini File since its going to be a problem on next run */
                        string Old_Extention = File_Path.GetExtension();
                        File.Move(File_Path, File_Path.Replace(Old_Extention, DateTime.Now.ToLongDateString() + "." + Old_Extention));
                        File.Create(File_Path).Close();
                    }
                    else
                    {
                        File.Create(File_Path).Close();
                    }

                    File_Data = new IniData();
                }
            }
            catch (IOException Error)
            {
                Log_Detail.Full("IniFile Core [I.O.]", Error);
            }
            catch (Exception Error)
            {
                Log_Detail.Full("IniFile Core", Error);
            }
        }
        /// <summary>
        /// Loads Ini File
        /// </summary>
        /// <param name="Ini_Path">Ini Full File Path</param>
        public Ini_File(string Ini_Path)
        {
            try
            {
                File_Path = new FileInfo(string.IsNullOrWhiteSpace(Ini_Path) ? Index_Header + ".ini".ToLowerInvariant() : Ini_Path).FullName;
                File_Parser = new IniDataFile();

                try
                {
                    if (File.Exists(File_Path))
                    {
                        File_Data = File_Parser.ReadFile(File_Path);
                    }
                    else
                    {
                        if (!File.Exists(File_Path))
                        {
                            File.Create(File_Path).Close();
                        }

                        File_Data = new IniData();
                    }
                }
                catch (Ini.Parser.Exceptions.ParsingException)
                {
                    if (File.Exists(File_Path))
                    {
                        string Old_Extention = File_Path.GetExtension();
                        File.Move(File_Path, File_Path.Replace(Old_Extention, DateTime.Now.ToLongDateString() + "." + Old_Extention));
                        File.Create(File_Path).Close();
                    }
                    else
                    {
                        File.Create(File_Path).Close();
                    }

                    File_Data = new IniData();
                }
            }
            catch (IOException Error)
            {
                Log_Detail.Full("IniFile Core [I.O.]", Error);
            }
            catch (Exception Error)
            {
                Log_Detail.Full("IniFile Core", Error);
            }
        }
        /// <summary>
        /// Read a Key Entry inside the Ini File
        /// </summary>
        /// <param name="Key_Index">String Index Key</param>
        /// <returns>String Inside Key Index</returns>
        public string Key_Read(string Key_Index)
        {
            return File_Data[Index_Header][Key_Index];
        }
        /// <summary>
        /// Creates a Key Entry inside the Ini File
        /// </summary>
        /// <param name="Key_Index">String Index Key</param>
        /// <param name="Index_Data">String Key Data</param>
        public void Key_Write(string Key_Index, string Index_Data)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(File_Path))
                {
                    Log.Warning("IniFile: ".ToUpper() + "[Key Write] Ini File's Path can not be Null");
                }
                else if (string.IsNullOrWhiteSpace(Key_Index))
                {
                    Log.Warning("IniFile: ".ToUpper() + "[Key Write] Key can not be Null");
                }
                else if (new FileInfo(File_Path).IsReadOnly)
                {
                    Log.Warning("IniFile: ".ToUpper() + "[Key Write] Ini File is Key_Read-Only -> " + Path.GetFileName(File_Path));
                }
                else
                {
                    if (File_Data[Index_Header] == default)
                    {
                        File_Data.Sections.Add(Index_Header);
                    }

                    File_Data[Index_Header][Key_Index] = Index_Data;
                    File_Parser.WriteFile(File_Path, File_Data);
                }
            }
            catch (Exception Error)
            {
                Log_Detail.Full("IniFile Key Write", Error);
            }
        }
        /// <summary>
        /// Deletes a Key Entry from the Ini File
        /// </summary>
        /// <param name="Key_Index">String Index Key</param>
        /// <remarks></remarks>
        public void Key_Delete(string Key_Index)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(File_Path) || string.IsNullOrWhiteSpace(Key_Index))
                {
                    if (string.IsNullOrWhiteSpace(Key_Index))
                    {
                        Log.Warning("IniFile: ".ToUpper() + "[Key Remove] Key can not be Null");
                    }
                    else
                    {
                        Log.Warning("IniFile: ".ToUpper() + "[Key Remove] Ini File's Path can not be Null");
                    }
                }
                else if (File_Data == default)
                {
                    Log.Warning("IniFile: ".ToUpper() + "[Key Remove] Ini Data can not be Null");
                }
                else if (File_Data[Index_Header] == default)
                {
                    Log.Warning("IniFile: ".ToUpper() + "[Key Remove] Ini File's Header can not be Null");
                }
                else if (new FileInfo(File_Path).IsReadOnly)
                {
                    Log.Warning("IniFile: ".ToUpper() + "[Key Remove] Ini File is Key_Read-Only -> " + Path.GetFileName(File_Path));
                }
                else
                {
                    File_Data[Index_Header].Remove(Key_Index);
                    File_Parser.WriteFile(File_Path, File_Data);
                }
            }
            catch (Exception Error)
            {
                Log_Detail.Full("IniFile Key Deletion", Error);
            }
        }
        /// <summary>
        /// Checks the Ini File for an Existing Key Entry
        /// </summary>
        /// <param name="Key_Index">String Index Key</param>
        /// <returns>True if found; otherwise, False</returns>
        public bool Key_Exists(string Key_Index)
        {
            if (string.IsNullOrWhiteSpace(Key_Index) || (File_Data == default) || (File_Data[Index_Header] == default))
            {
                return false;
            }
            else
            {
                return File_Data[Index_Header].Contains(Key_Index);
            }
        }
        /// <summary>
        /// Converts the specified Boolean value to the equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="Key_Index">The String value to convert.</param>
        /// <returns>The number if value was converted successfully; otherwise, -2017 to indicate conversion failure.</returns>
        /// <remarks><b><i>Make Sure to Set a Value that be checked for conversion failure</i></b></remarks>
        public int Key_Read_Int(string Key_Index)
        {
            if (string.IsNullOrWhiteSpace(Key_Index) || (File_Data == default) || (File_Data[Index_Header] == default))
            {
                return Conversion_Failure;
            }
            else if (int.TryParse(File_Data[Index_Header][Key_Index], out int Converted_Port))
            {
                return Converted_Port;
            }
            else
            {
                return Conversion_Failure;
            }
        }
        /// <summary>
        /// Converts the specified Boolean value to the equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="Key_Index">The String value to convert.</param>
        /// <returns>True if value was converted successfully; otherwise, False.</returns>
        public bool Key_Read_Int_Check(string Key_Index)
        {
            if (string.IsNullOrWhiteSpace(Key_Index) || (File_Data == default) || (File_Data[Index_Header] == default))
            {
                return false;
            }
            else
            {
                return int.TryParse(File_Data[Index_Header][Key_Index], out int Converted_Port);
            }
        }
        /// <summary>
        /// Deletes a Section of Ini File Section
        /// </summary>
        /// <param name="Key_Section">Section Key</param>
        /// <remarks><b><i>Documentation is still ongoing</i></b></remarks>
        public void Key_Delete_Section(string Key_Section)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(File_Path) || string.IsNullOrWhiteSpace(Key_Section))
                {
                    if (string.IsNullOrWhiteSpace(Key_Section))
                    {
                        Log.Warning("IniFile: ".ToUpper() + "[Key Delete Section] Key can not be Null");
                    }
                    else
                    {
                        Log.Warning("IniFile: ".ToUpper() + "[Key Delete Section] Ini File's Path can not be Null");
                    }
                }
                else if (File_Data == default)
                {
                    Log.Warning("IniFile: ".ToUpper() + "[Key Delete Section] Ini Data can not be Null");
                }
                else if (File_Data[Index_Header] == default)
                {
                    Log.Warning("IniFile: ".ToUpper() + "[Key Delete Section] Ini File's Header can not be Null");
                }
                else if (new FileInfo(File_Path).IsReadOnly)
                {
                    Log.Warning("IniFile: ".ToUpper() + "[Key Delete Section] Ini File is Key_Read-Only -> " + Path.GetFileName(File_Path));
                }
                else
                {
                    File_Data.Sections.Remove(Key_Section);
                    File_Parser.WriteFile(File_Path, File_Data);
                }
            }
            catch (Exception Error)
            {
                Log_Detail.Full("IniFile Key Delete Section", Error);
            }
        }
    }
}
