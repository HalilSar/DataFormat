using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
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
            string path = @".\your\path\data.json";
            string path2 = @".\your\path\data2.json";
            WriteJson(new Personal { Id = 1, Name = "Martin", SurName = "Fowler" }, path);

            WriteJson(new List<Personal> { new Personal { Id = 1, Name = "Martin", SurName = "Fowler" },
                                               new Personal { Id = 2, Name = "Goerge", SurName = "Bool" },
                                               new Personal { Id = 3, Name = "Goerge", SurName = "Leibniz" }}, path2);
      
            ReadJson(path);
            ReadJsonObjects(path2);
        }


        static void WriteJson(Personal personal,string path)
        {
            var obj = JsonConvert.SerializeObject(personal);
            File.WriteAllText(path, obj);

        }

        static void WriteJson(List<Personal> personals, string path)
        {
            var obj = JsonConvert.SerializeObject(personals);
            File.WriteAllText(path, obj);

        }

        static void ReadJson(string path) 
        {
            var stringVal = File.ReadAllText(path);
            var obj = JsonConvert.DeserializeObject<Personal>(stringVal);
            Console.WriteLine(obj.Id);
            Console.WriteLine(obj.Name);
            Console.WriteLine(obj.SurName);
        }

        static void ReadJsonObjects(string path)
        {
            var stringVal = File.ReadAllText(path);
            var objs = JsonConvert.DeserializeObject<List<Personal>>(stringVal);
            foreach (var obj in objs)
            {
                Console.WriteLine(obj.Id);
                Console.WriteLine(obj.Name);
                Console.WriteLine(obj.SurName);
            }

        }
    }
}
