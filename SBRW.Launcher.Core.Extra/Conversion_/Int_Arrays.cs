using System;

namespace SBRW.Launcher.Core.Extra.Conversion_
{
    /// <summary>
    /// 
    /// </summary>
    internal static class Int_Arrays
    {
        /// <summary>
        /// Converts an integer array to a string
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static string ArrayToString(this int[] array)
        {
            return array.ArrayToString("-");
        }
        /// <summary>
        /// Converts an integer array to a string
        /// </summary>
        /// <param name="array"></param>
        /// <param name="Separator"></param>
        /// <returns></returns>
        public static string ArrayToString(this int[] array, string Separator)
        {
            if (array == null || array.Length == 0)
            {
                return string.Empty;
            }

            /* Using string.Join to convert the array to a string with a comma separator */
            return string.Join(Separator, array);
        }
        /// <summary>
        /// Converts a string array to an integer array
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int[] ToIntArray(this string[] array)
        {
            if (array == default || array.Length == 0)
            {
                return new int[0];
            }

            // Using Array.ConvertAll to convert the string array to an integer array
            return Array.ConvertAll(array, int.Parse);
        }
    }
}
