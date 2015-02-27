using System;
using System.IO;
using System.Xml.Linq;
using System.Linq;
using System.Text;

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

        public static void ParseXml(string path, StringBuilder sb)
        {
            XDocument doc = XDocument.Load(path);
            XNamespace ns = "http://colorexchangeformat.com/v2";
            int index = 1;
            var colors = doc.Descendants(ns + "Color");
            foreach (var color in colors)
            {
                try
                {
                    var colorName = color.Attribute("ColorName").Value;
                    var L = color.Descendants(ns + "L").First().Value;
                    var a = color.Descendants(ns + "A").First().Value;
                    var b = color.Descendants(ns + "B").First().Value;
                    sb.AppendLine(String.Format("{0},{1},{2},{3},{4}", index, L, a, b, colorName));
                }
                catch
                {
                    sb.AppendLine(String.Format("{0},{1},{2},{3},{4}", index, 0, 0, 0, "ERROR"));
                }
                finally
                {
                    index++;
                }
            }
        }

    }
}
