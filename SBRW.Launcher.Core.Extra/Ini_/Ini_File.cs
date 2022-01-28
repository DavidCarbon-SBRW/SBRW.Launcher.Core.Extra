using SBRW.Ini.Parser;
using SBRW.Ini.Parser.Model;
using SBRW.Launcher.Core.Extension.Logging_;
using System;
using System.IO;
using System.Text;

namespace SBRW.Launcher.Core.Extra.Ini_
{
    /// <summary>
    /// Ini File Class
    /// </summary>
    public class Ini_File
    {
        internal string File_Path;
        /// <summary>
        /// Index Header for the Ini File
        /// </summary>
        public static string Index_Header { get; set; } = "GameLauncher";
        /// <summary>
        /// Conversion Failure Number to indicate if a value conversion had failed
        /// </summary>
        /// <remarks>Default Number: -2017</remarks>
        public static int Conversion_Failure { get; set; } = -2017;
        internal FileIniDataParser File_Parser { get; set; }
        internal IniData File_Data { get; set; }
        internal UTF8Encoding UTF8
        {
            get 
            { 
                return new UTF8Encoding(false); 
            }
        }
        /// <summary>
        /// Loads Ini File
        /// </summary>
        /// <param name="Ini_Path">Ini Full File Path</param>
        public Ini_File(string Ini_Path = null)
        {
            try
            {
                File_Path = new FileInfo(Ini_Path ?? Index_Header + ".ini").FullName;
                File_Parser = new FileIniDataParser();
                if (File.Exists(File_Path))
                {
                    File_Data = File_Parser.ReadFile(File_Path, UTF8);
                }
                else
                {
                    if (!File.Exists(File_Path))
                    {
                        File.Create(File_Path).Dispose();
                    }

                    File_Data = new IniData();
                }
            }
            catch (Exception Error)
            {
                Log_Detail.OpenLog("IniFile Core", null, Error, null, true);
            }
            finally
            {
                GC.Collect();
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
                if (new FileInfo(File_Path).IsReadOnly)
                {
                    Log.Warning("IniFile: ".ToUpper() + "[Key Write] Ini File is Key_Read-Only -> " + Path.GetFileName(File_Path));
                }
                else
                {
                    File_Data[Index_Header][Key_Index] = Index_Data;
                    File_Parser.WriteFile(File_Path, File_Data, UTF8);
                }
            }
            catch (Exception Error)
            {
                Log_Detail.OpenLog("IniFile Key Write", null, Error, null, true);
            }
            finally
            {
                GC.Collect();
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
                if (new FileInfo(File_Path).IsReadOnly)
                {
                    Log.Warning("IniFile: ".ToUpper() + "[Key Remove] Ini File is Key_Read-Only -> " + Path.GetFileName(File_Path));
                }
                else
                {
                    File_Data[Index_Header].RemoveKey(Key_Index);
                    File_Parser.WriteFile(File_Path, File_Data, UTF8);
                }
            }
            catch (Exception Error)
            {
                Log_Detail.OpenLog("IniFile Key Deletion", null, Error, null, true);
            }
            finally
            {
                GC.Collect();
            }
        }
        /// <summary>
        /// Checks the Ini File for an Existing Key Entry
        /// </summary>
        /// <param name="Key_Index">String Index Key</param>
        /// <returns>True if found; otherwise, False</returns>
        public bool Key_Exists(string Key_Index)
        {
            return File_Data[Index_Header].ContainsKey(Key_Index);
        }
        /// <summary>
        /// Converts the specified Boolean value to the equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="Key_Index">The String value to convert.</param>
        /// <returns>The number if value was converted successfully; otherwise, -2017 to indicate conversion failure.</returns>
        /// <remarks><b><i>Make Sure to Set a Value that be checked for conversion failure</i></b></remarks>
        public int Key_Read_Int(string Key_Index)
        {
            if (int.TryParse(File_Data[Index_Header][Key_Index], out int Converted_Port))
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
            return int.TryParse(File_Data[Index_Header][Key_Index], out int Converted_Port);
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
                if (new FileInfo(File_Path).IsReadOnly)
                {
                    Log.Warning("IniFile: ".ToUpper() + "[Key Delete Section] Ini File is Key_Read-Only -> " + Path.GetFileName(File_Path));
                }
                else
                {
                    File_Data.Sections.RemoveSection(Key_Section);
                    File_Parser.WriteFile(File_Path, File_Data);
                }
            }
            catch (Exception Error)
            {
                Log_Detail.OpenLog("IniFile Key Delete Section", null, Error, null, true);
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
