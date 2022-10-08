using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Configuration;

namespace k190146_Q2
{
    public class HTMLParser
    {
        private XmlWriterSettings sts;
        private readonly string EntityName = "Scripts";
        private readonly string[] properties = new string[2] { "Script" , "Price"};
        public HTMLParser() {
            sts = new XmlWriterSettings()
            {
                Indent = true,
            };
        }
        public void writeXml(List<List<string>> stocks , string filename) {
            
            XmlWriter writer = XmlWriter.Create(filename ,sts );
            writer.WriteStartDocument();
            writer.WriteStartElement("xml");
            foreach (List<string> stock in stocks) {
                Console.WriteLine(stock[0] + stock[1]);
                writer.WriteStartElement(EntityName);
                for (int i = 0; i < properties.Length; i++) {

                    writer.WriteStartElement(properties[i]);
                    writer.WriteString(stock[i]);
                    writer.WriteEndElement();
    
                }

                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
            Console.WriteLine("XML document created");

        }

        public void createDir(string path, string dirname) {
            if (!Directory.Exists(path+ dirname))
            {
                Directory.CreateDirectory(path + dirname);
            }
        }
        public string getFileIndex(string folder) {
            int i = 0;
            string[] files = Directory.GetFiles(folder);
            i = files.Length;
            string baseName = "file";
            return baseName + i.ToString() + ".xml";
        }
        public void getInfo(HtmlNode head , HtmlNode node) {
            HtmlNode[] tr_nodes = node.SelectNodes(".//tr").ToArray();
            List<List<string>> stocks = new List<List<string>>();
            for (int i = 2; i < tr_nodes.Length; i++) {
                HtmlNode sub_tr_nodes = tr_nodes[i].SelectNodes(".//td").First();
                HtmlNode sub_price_node = tr_nodes[i].SelectNodes(".//td")[5];
                string companyName = sub_tr_nodes.InnerHtml;
                string companyStocks = sub_price_node.InnerHtml;
                
                Dictionary<string, string> stock = new Dictionary<string, string>();
                stocks.Add(new List<string>() {companyName.TrimEnd() ,companyStocks });

                //Console.WriteLine(tr_nodes[0].InnerHtml);
            }
            

            string root_path = ConfigurationManager.AppSettings["outputDir"];
            if (root_path == null) {
                Console.WriteLine("No output path required");
                return;
            }
            if (!root_path.EndsWith('\\')) {
                Console.WriteLine("Path must end with '\\'");
                return;
            }
            string cat_name = head.SelectSingleNode(".//tr/th/h4").InnerHtml;
            Console.WriteLine(cat_name);
            cat_name = cat_name.Split("/")[0].Trim().Replace('.' , ' ');
            string dir_path = root_path + cat_name + "\\";          //removing gibbereish files

            
            createDir(root_path, cat_name);
            string fname = getFileIndex(dir_path);

            string abs_path = dir_path + fname;
            
            writeXml(stocks , abs_path);
        }
       


    }
}
