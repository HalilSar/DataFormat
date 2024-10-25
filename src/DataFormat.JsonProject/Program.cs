using System;
using Newtonsoft.Json;
using System.IO;
namespace DataFormat.JsonProject
{
    public class Personal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            string path = @".\your\path\demo.xml";
            WriteJson(new Personal { Id = 1, Name = "Martin", SurName = "Fowler" }, path);
        }


        static void WriteJson(Personal personal,string path)
        {
            var obj = Newtonsoft.Json.JsonConvert.SerializeObject(personal);
            File.WriteAllText(path, obj);

        }
    }
}
