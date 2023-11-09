using System;

namespace WG_Core
{
    public class FileHelper
    {
        public static bool IsFileExist(string path) {         
            return System.IO.File.Exists(path);        
        }
    }
}
