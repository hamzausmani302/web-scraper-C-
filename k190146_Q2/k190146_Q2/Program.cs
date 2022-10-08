using System;
using System.Configuration;
using HtmlAgilityPack;
using k190146_Q2;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        public static HTMLParser parser = new HTMLParser();

        public static string getFilename(string path) {
            DateTime today = DateTime.Now;
            string basename = "Summary";
            string day = today.Day.ToString();
            if (day.Length == 1) {
                day = "0" + day;
            }
            string month = today.ToString("MMM");
            string year = "22";
            return path + basename+day+month+year + ".html";
        }
        
        static void Main(string[] args)
        {
            string root_path = ConfigurationManager.AppSettings["outputDir"];
            if (!root_path.EndsWith('\\'))
            {
                Console.WriteLine("Path must end with '\\'");
                return;
            }

            Console.WriteLine("Enter the file path(full path) : ");
            string filePath = Console.ReadLine();
            Console.WriteLine(filePath);
            try
            {
                HtmlDocument doc = new HtmlDocument();
                doc.Load(filePath);


                HtmlNode[] categoryNodes = doc.DocumentNode.SelectNodes("//div[@class='table-responsive']").ToArray();


                for (int i = 0; i < categoryNodes.Length; i++)
                {

                    HtmlNode tableHeads = categoryNodes[i].SelectNodes(".//table/thead").First();
                    HtmlNode tableBody = categoryNodes[i].SelectSingleNode(".//table[1]");
                    parser.getInfo(tableHeads , tableBody);



                    //Console.WriteLine(tableBody.InnerHtml);
                }

            }
            catch (Exception err) {
                Console.WriteLine(err.Message);
            }
        }
    }
}