using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CXFtoCSV
{
    public class DataConverter
    {
        public static void ProcessFiles(string[] files)
        {
            foreach (var file in files)
            {
                var targetPath = Helpers.GetTargetPath(file);
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("index,L,a,b,ColorName");
                Helpers.ParseXml(file, sb);
                File.WriteAllText(targetPath, sb.ToString());
            }
        }


    }
}
