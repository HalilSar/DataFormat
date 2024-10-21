using System;
using System.Xml;
using System.Collections.Generic;
namespace DataFormat.XmlProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\dotnet\.NetProject\Net53.DataExchangeFormat\src\DataFormat.XmlProject\D2.xml";
            //Console.WriteLine("Hello World!");

            //WriteXmlToDoc(new Personal { Id = 1, Name = "Martin", SurName = "Fowler" }, path);  @".\your\path"

            WriteXmlToDoc(new List<Personal> { new Personal { Id = 1, Name = "Martin", SurName = "Fowler" },
                                               new Personal { Id = 2, Name = "Goerge", SurName = "Bool" },
                                               new Personal { Id = 3, Name = "Goerge", SurName = "Leibniz" }}, path);
            ReadXml(path);
        }


        static void WriteXmlToDoc(Personal personal, string path)
        {
            //Xmlt
            
            var xml = XmlWriter.Create(path);
            xml.WriteStartDocument(true);

            xml.WriteStartElement("personal");
            xml.WriteAttributeString("Id", personal.Id.ToString());
            
            xml.WriteElementString("Ad",personal.Name);
            

            xml.WriteElementString("Soyad", personal.SurName);
           

            xml.WriteEndElement();

            xml.Close();
        }
    
        static void WriteXmlToDoc(List<Personal> persons, string path)
        {
            var xml  = XmlWriter.Create(path);
            xml.WriteStartDocument(true);
            xml.WriteStartElement("Personeller");
            
            foreach (var personal in persons)
            {
                xml.WriteStartElement("personal");
                xml.WriteAttributeString("Id", personal.Id.ToString());

                xml.WriteElementString("Ad", personal.Name);


                xml.WriteElementString("Soyad", personal.SurName);


                xml.WriteEndElement();
            }

            xml.WriteEndElement();
            xml.Close();
        }

        static void ReadXml(string path)
        {
            var xmlreader = XmlReader.Create(path);
            while(xmlreader.Read())
            {
                 Console.WriteLine(xmlreader.Name + " " + xmlreader.Value);
            }
            xmlreader.Close();
        }
    }
}
