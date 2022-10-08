using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using k190146_Q4.Models;

namespace k190146_Q4.Services
{
    public class XmlUtils
    {
        public List<Stock> parseXml(string path)
        {
            List<Stock> LstStocks = new List<Stock>();

            string entityNode = "Scripts";
            /*string path = @"C:\Users\DARK VADER\Desktop\xmlFiles\ AUTOMOBILE ASSEMBLER\file.xml";*/
            XmlReader reader = XmlReader.Create(path);
            reader.ReadToFollowing(entityNode);
            do
            {
                reader.ReadToFollowing("Script");
                string name = reader.ReadElementContentAsString();


                reader.ReadToFollowing("Price");
                string price = reader.ReadElementContentAsString();


                LstStocks.Add(new Stock() { name = name, price = price });

            } while (reader.ReadToFollowing(entityNode));



            return LstStocks;
            //XmlReader.Create()
        }
    }
}
