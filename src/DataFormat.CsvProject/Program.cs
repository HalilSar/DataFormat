using System;
using static System.Console;
using CsvHelper;
using System.IO;
namespace DataFormat.CsvProject
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
            string path = @".\your\path\data2.csv";          
            WriteCsv( path,new Personal { Id = 1, Name = "Martin", SurName = "Fowler" });
        }

        static void WriteCsv(string path, Personal personal)
        {
           
            StreamWriter sw = new StreamWriter(path);
            CsvWriter csvWriter = new CsvWriter(sw);
            csvWriter.WriteHeader(typeof(Personal));
            csvWriter.WriteRecord(personal);
            sw.Close();
        }

    }
}
