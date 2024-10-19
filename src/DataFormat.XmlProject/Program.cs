using System;
using System.Xml;
namespace DataFormat.XmlProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            WriteXmlToDoc(new Personal { Id = 1, Name = "Martin", SurName = "Fowler" }, @".\your\path");


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
    }
}
