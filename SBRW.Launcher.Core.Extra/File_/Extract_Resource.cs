using SBRW.Launcher.Core.Extension.Logging_;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace SBRW.Launcher.Core.Extra.File_
{
    internal class Extract_Resource
    {
        internal static byte[] AsByte(String File_Name)
        {
            if (string.IsNullOrWhiteSpace(File_Name))
            {
                return null;
            }
            else
            {
                try
                {
                    Assembly TheRun = Assembly.GetExecutingAssembly();
                    using (Stream LiveStream = TheRun.GetManifestResourceStream(File_Name))
                    {
                        if (LiveStream == null) { return null; }
                        else
                        {
                            byte[] ba = new byte[LiveStream.Length];
                            LiveStream.Read(ba, 0, ba.Length);
                            return ba;
                        }
                    }
                }
                catch (Exception Error)
                {
                    Log_Detail.OpenLog("Extract Resource AsByte", null, Error, null, true);
                    return null;
                }
            }
        }

        internal static string AsString(string File_Name)
        {
            if (string.IsNullOrWhiteSpace(File_Name))
            {
                return string.Empty;
            }
            else
            {
                try
                {
                    Assembly TheRun = Assembly.GetExecutingAssembly();
                    using (Stream LiveStream = TheRun.GetManifestResourceStream(File_Name))
                    {
                        if (LiveStream == null) 
                        { 
                            return string.Empty; 
                        }
                        else
                        {
                            using (StreamReader StreamViewer = new StreamReader(LiveStream))
                            {
                                return StreamViewer.ReadToEnd();
                            }
                        }
                    }
                }
                catch (Exception Error)
                {
                    Log_Detail.OpenLog("Extract Resource AsString", null, Error, null, true);
                    return string.Empty;
                }
            }
        }
    }
}
