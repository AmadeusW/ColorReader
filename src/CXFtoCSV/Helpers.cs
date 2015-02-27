using System;
using System.IO;
using System.Xml.Serialization;

namespace CXFtoCSV
{
    public class Helpers
    {
        private const string TARGET_EXTENSION = ".csv";

        public static string GetTargetPath(string path)
        {
            var directoryName = Path.GetDirectoryName(path);
            var fileName = Path.GetFileNameWithoutExtension(path);
            return Path.Combine(directoryName, fileName + TARGET_EXTENSION);
        }


        
    }
}
