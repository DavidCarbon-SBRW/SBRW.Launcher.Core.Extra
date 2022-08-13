using SBRW.Launcher.Core.Extension.Logging_;
using SBRW.Launcher.Core.Extra.Reference.System_;
using System;
using System.Diagnostics;
using System.IO;

namespace SBRW.Launcher.Core.Extra.File_
{
    /// <summary>
    /// 
    /// </summary>
    public class System_Storage
    {
        /// <summary>
        /// Provides access to information on a drive.
        /// </summary>
        /// <param name="Folder_File_Path">A valid drive path or drive letter. 
        /// This can be either uppercase or lowercase, 'a' to 'z'. A null value is not valid.</param>
        /// <param name="Human_Values">Retrives Human-Readable Values from Bash</param>
        /// <param name="Unix_Platforms">Returns Unix Related Information</param>
        /// <returns>Converted Drive Information</returns>
        public static Format_System_Storage Drive_Full_Info(string Folder_File_Path, bool Unix_Platforms = false, bool Human_Values = false)
        {
            Format_System_Storage Current_Drive = default;

            try
            {
                if (Unix_Platforms)
                {
                    string Command_Mode = Human_Values ? "df -h" : "df";
                    string Escaped_Args = Folder_File_Path.Replace("\"", "\\\"");

                    Process Bash_Process = new Process()
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = "/bin/bash",
                            Arguments = $"{Command_Mode} \"{Escaped_Args}\"",
                            RedirectStandardOutput = true,
                            UseShellExecute = false,
                            CreateNoWindow = true
                        }
                    };

                    Bash_Process.Start();
                    /* Example */
                    /* df -h / "Filesystem      Size  Used Avail Use% Mounted on  /dev/sda3        39G   30G  6.9G  82% /" */
                    /* df / "Filesystem     1K-blocks     Used Available Use% Mounted on  /dev/sda3       40502528 31190956   7224456  82% /" */
                    string Konsole = Bash_Process.StandardOutput.ReadToEnd();
                    string[] Konsole_Split = Folder_File_Path.Replace(' ', ',').Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    /* Lets wait 30 Seconds (Worst Case) */
                    Bash_Process.WaitForExit(30000);

                    int.TryParse(Konsole_Split[12].Replace("%", string.Empty), out int Final_Value);

                    if (Human_Values)
                    {
                        long.TryParse(Konsole_Split[9], out long Long_Value_Total_Space);
                        long.TryParse(Konsole_Split[11], out long Long_Value_Available);

                        Current_Drive = new Format_System_Storage()
                        {
                            DriveFormat = "Unknown",
                            TotalSize = Long_Value_Total_Space * 1000L,
                            AvailableFreeSpace = Long_Value_Available * 1000L,
                            Name = Konsole_Split[13],
                            VolumeLabel = Konsole_Split[8],
                            RootDirectory = new DirectoryInfo(Folder_File_Path),
                            IsReady = true,
                            TotalFreeSpace = Long_Value_Total_Space * 1000L,
                            DriveType = DriveType.Unknown,
                            Percentage_Of_Drive_Used = Final_Value
                        };
                    }
                    else
                    {
                        Current_Drive = new Format_System_Storage()
                        {
                            DriveFormat = "Unknown",
                            TotalSize_Linux = Konsole_Split[9],
                            AvailableFreeSpace_Linux = Konsole_Split[11],
                            Name = Konsole_Split[13],
                            VolumeLabel = Konsole_Split[8],
                            RootDirectory = new DirectoryInfo(Folder_File_Path),
                            IsReady = true,
                            TotalSizeUsed_Linux = Konsole_Split[10],
                            DriveType = DriveType.Unknown,
                            Percentage_Of_Drive_Used = Final_Value
                        };
                    }
                }
                else
                {
                    foreach (DriveInfo Next_Drive_In_List in DriveInfo.GetDrives())
                    {
                        if (Next_Drive_In_List.Name == Path.GetPathRoot(Folder_File_Path))
                        {
                            Current_Drive = new Format_System_Storage()
                            {
                                DriveFormat = Next_Drive_In_List.DriveFormat,
                                AvailableFreeSpace = Next_Drive_In_List.AvailableFreeSpace,
                                DriveType = Next_Drive_In_List.DriveType,
                                TotalFreeSpace = Next_Drive_In_List.TotalFreeSpace,
                                TotalSize = Next_Drive_In_List.TotalSize,
                                IsReady = Next_Drive_In_List.IsReady,
                                Name = Next_Drive_In_List.Name,
                                RootDirectory = Next_Drive_In_List.RootDirectory,
                                VolumeLabel = Next_Drive_In_List.VolumeLabel
                            };

                            break;
                        }
                    }
                }
            }
            catch (UnauthorizedAccessException Error)
            {
                Log_Detail.OpenLog("Drive_Full_Info [U.A.E.]", null, Error, null, true);
            }
            catch (Exception Error)
            {
                Log_Detail.OpenLog("Drive_Full_Info", null, Error, null, true);
            }

            return Current_Drive;
        }
    }
}
