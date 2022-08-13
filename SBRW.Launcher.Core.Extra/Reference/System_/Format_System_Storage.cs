using System;
using System.IO;
using System.Security;

namespace SBRW.Launcher.Core.Extra.Reference.System_
{
    /// <summary>
    /// Provides access to information on a drive.
    /// </summary>
    public class Format_System_Storage
    {
        /// <summary>
        /// The amount of available free space on a drive, in bytes.
        /// </summary>
        /// <returns>The amount of free space available on the drive, in bytes.</returns>
        /// <exception cref="UnauthorizedAccessException">Access to the drive information is denied.</exception>
        /// <exception cref="IOException">An I/O error occurred (for example, a disk error or a drive was not ready).</exception>
        public long AvailableFreeSpace { get; set; }
        /// <summary>
        /// The amount of available free space on a drive.
        /// </summary>
        /// <returns>The amount of free space available on the drive.</returns>
        /// <exception cref="UnauthorizedAccessException">Access to the drive information is denied.</exception>
        /// <exception cref="IOException">An I/O error occurred (for example, a disk error or a drive was not ready).</exception>
        public string AvailableFreeSpace_Linux { get; set; }
        /// <summary>
        /// The name of the file system, such as NTFS or FAT32.
        /// </summary>
        /// <returns>The name of the file system on the specified drive.</returns>
        /// <exception cref="UnauthorizedAccessException">Access to the drive information is denied.</exception>
        /// <exception cref="IOException">An I/O error occurred (for example, a disk error or a drive was not ready).</exception>
        public string DriveFormat { get; set; }
        /// <summary>
        /// The drive type, such as CD-ROM, removable, network, or fixed.
        /// </summary>
        /// <returns>One of the enumeration values that specifies a drive type.</returns>
        public DriveType DriveType { get; set; }
        /// <summary>
        /// A value that indicates whether a drive is ready.
        /// </summary>
        /// <returns>true if the drive is ready; false if the drive is not ready.</returns>
        public bool IsReady { get; set; }
        /// <summary>
        /// The name of a drive, such as C:\.
        /// </summary>
        /// <returns>The name of the drive.</returns>
        public string Name { get; set; }
        /// <summary>
        /// The root directory of a drive.
        /// </summary>
        /// <returns>An object that contains the root directory of the drive.</returns>
        public DirectoryInfo RootDirectory { get; set; }
        /// <summary>
        /// The total amount of free space available on a drive, in bytes.
        /// </summary>
        /// <returns>The total free space available on a drive, in bytes.</returns>
        /// <exception cref="UnauthorizedAccessException">Access to the drive information is denied.</exception>
        /// <exception cref="DriveNotFoundException">The drive is not mapped or does not exist.</exception>
        /// <exception cref="IOException">An I/O error occurred (for example, a disk error or a drive was not ready).</exception>
        public long TotalFreeSpace { get; set; }
        /// <summary>
        /// The total size of storage space on a drive, in bytes.
        /// </summary>
        /// <returns>The total size of the drive, in bytes.</returns>
        /// <exception cref="UnauthorizedAccessException">Access to the drive information is denied.</exception>
        /// <exception cref="DriveNotFoundException">The drive is not mapped or does not exist.</exception>
        /// <exception cref="IOException">An I/O error occurred (for example, a disk error or a drive was not ready).</exception>
        public long TotalSize { get; set; }
        /// <summary>
        /// The total size of storage space on a drive.
        /// </summary>
        /// <returns>The total size of the drive.</returns>
        /// <exception cref="UnauthorizedAccessException">Access to the drive information is denied.</exception>
        /// <exception cref="DriveNotFoundException">The drive is not mapped or does not exist.</exception>
        /// <exception cref="IOException">An I/O error occurred (for example, a disk error or a drive was not ready).</exception>
        public string TotalSize_Linux { get; set; }
        /// <summary>
        /// The volume label of a drive.
        /// </summary>
        /// <returns>The volume label.</returns>
        /// <exception cref="IOException">An I/O error occurred (for example, a disk error or a drive was not ready).</exception>
        /// <exception cref="DriveNotFoundException">The drive is not mapped or does not exist.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="UnauthorizedAccessException">The volume label is being set on a network or CD-ROM drive. -or- 
        /// Access to the drive information is denied.</exception>
        public string VolumeLabel { get; set; }
        /// <summary>
        /// The total size of storage space being used on a drive, in bytes.
        /// </summary>
        /// <returns>The total size of the drive being used, in bytes.</returns>
        /// <exception cref="UnauthorizedAccessException">Access to the drive information is denied.</exception>
        /// <exception cref="DriveNotFoundException">The drive is not mapped or does not exist.</exception>
        /// <exception cref="IOException">An I/O error occurred (for example, a disk error or a drive was not ready).</exception>
        public long TotalSizeUsed { get; set; }
        /// <summary>
        /// The total size of storage space being used on a drive.
        /// </summary>
        /// <returns>The total size of the drive being used.</returns>
        /// <exception cref="UnauthorizedAccessException">Access to the drive information is denied.</exception>
        /// <exception cref="DriveNotFoundException">The drive is not mapped or does not exist.</exception>
        /// <exception cref="IOException">An I/O error occurred (for example, a disk error or a drive was not ready).</exception>
        public string TotalSizeUsed_Linux { get; set; }
        /// <summary>
        /// Percentage of the Drive being Used
        /// </summary>
        /// <remarks>Linux Only</remarks>
        public int Percentage_Of_Drive_Used { get; set; } 
    }
}