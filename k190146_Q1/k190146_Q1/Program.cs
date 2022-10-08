// See https://aka.ms/new-console-template for more information


using System;
using System.Data;
using System.Text;
using System.Threading.Tasks;
namespace App // Note: actual namespace depends on the project name.
{
    public class Program
    {
        private static readonly HttpClient client = new HttpClient();

        public static async  Task<string> getContent(string url) {
            var contentTask = client.GetStringAsync(url);
            var content = await contentTask;
            return content;
        }

        public static bool createFile(string path, string filename , string content) {
            try
            {
                FileStream fs = File.Create(path + "/" + filename);
                byte[] bytes = Encoding.ASCII.GetBytes(content);
                fs.Write(bytes, 0, bytes.Length);
                return true;
            }
            catch (Exception err) {
                Console.WriteLine(err.Message);
                return false;
            }
            
        }
        
        static async Task Main(string[] args)
        {
            if (args[0] == null || args[1] == null || args[0] == "" || args[1] == "") {
                Console.WriteLine("Arguments not provided");
                return;
            }
            string url = args[0];
            string dest_path = args[1];

            DateTime today = DateTime.Now;
            string baseName = "Summary";
            string day = today.Day.ToString();
            if (day.Length == 1) {
                day = "0" + day;
            }


            string month = today.ToString("MMM");
            string year = "22";
            string filename = baseName + day + month + year + ".html";
            Console.WriteLine(filename);
            string data = await getContent(url);
            bool result = createFile(dest_path, filename, data);


        }
    }
}