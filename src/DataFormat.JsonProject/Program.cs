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
            Console.WriteLine("Hello World!");
        }


        static void WriteJson(string value,string path)
        {
          //  var 
        }
    }
}
