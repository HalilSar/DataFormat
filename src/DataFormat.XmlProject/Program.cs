using System;
using System.Xml;
using System.Collections.Generic;
namespace DataFormat.XmlProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string path =  @".\your\path\demo.xml";
            string path2 = @".\your\path\demo2.xml";

            WriteXmlToDoc(new Personal { Id = 1, Name = "Martin", SurName = "Fowler" }, path);

            WriteXmlToDoc(new List<Personal> { new Personal { Id = 1, Name = "Martin", SurName = "Fowler" },
                                               new Personal { Id = 2, Name = "Goerge", SurName = "Bool" },
                                               new Personal { Id = 3, Name = "Goerge", SurName = "Leibniz" }}, path2);
            ReadXml(path2);
            Console.WriteLine("******************************");
            //ReadXml(path2);

        }

        // Write only  personal object in the xml file
        // parameters: personal object and string path
        static void WriteXmlToDoc(Personal personal, string path)
        {


            var xml = XmlWriter.Create(path);
           
           
            xml.WriteStartElement("personal");
            xml.WriteAttributeString("Id", personal.Id.ToString());           
            xml.WriteElementString("Ad",personal.Name);
            xml.WriteElementString("Soyad", personal.SurName);           
            xml.WriteEndElement();

            xml.Close();
        }

        // Write personal list in the xml fil
        // parameters: personal list and string path
        static void WriteXmlToDoc(List<Personal> persons, string path)
        {
            var xml  = XmlWriter.Create(path);
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

        // Read all personal in the xml file
        // parameters: string path
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
