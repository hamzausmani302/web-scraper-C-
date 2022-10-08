using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace k190146_Q3
{
    public class DirUtils
    {
        public static string getLatestFile(string dirPath) {
           
            string [] files = Directory.GetFiles(dirPath);
            
            return "\\"+ files.Last().Split("\\").Last();
        }

        public static List<string> getCategories(string path) {
            try
            {
                
                List<string> dirs = new List<string>(Directory.EnumerateDirectories(path).Select(x=> x.Split(@"\").Last()));
                
                return dirs;
            }
            catch (Exception e) {
                return new List<string>();
            }
        }


    }
}
