using System;
using static System.Console;
using CsvHelper;
using System.Collections.Generic;
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
            string path =  @".\your\path\data.csv";
            string path2 = @".\your\path\data2.csv"; 

            WriteCsv(path, new Personal { Id = 1, Name = "Martin", SurName = "Fowler" });
            WriteObjectsCsv(path2, new List<Personal> { new Personal { Id = 1, Name = "Martin", SurName = "Fowler" },
                                               new Personal { Id = 2, Name = "Goerge", SurName = "Bool" },
                                               new Personal { Id = 3, Name = "Goerge", SurName = "Leibniz" }});
            ReadCsv(path);
        }

        static void WriteCsv(string path, Personal personal)
        {
           
            StreamWriter sw = new StreamWriter(path);
            using (CsvWriter csvWriter = new CsvWriter(sw, System.Globalization.CultureInfo.InvariantCulture))
            {
          
                csvWriter.WriteHeader<Personal>();
                csvWriter.NextRecord();
                csvWriter.WriteRecord(personal);
            }
            sw.Close();
        }

        static void WriteObjectsCsv(string path, List<Personal> personals)
        {
            StreamWriter sw = new StreamWriter(path);
            using (CsvWriter csvWriter = new CsvWriter(sw, System.Globalization.CultureInfo.InvariantCulture))
            {
                csvWriter.WriteHeader<Personal>();
                csvWriter.WriteRecords(personals);
            }
            sw.Close();
        }

        static void ReadCsv(string path)
        {
            StreamReader sr = new StreamReader(path);
            using (CsvReader reader = new CsvReader(sr, System.Globalization.CultureInfo.InvariantCulture))
            {
                    reader.Read();
                    var obj = reader.GetRecord<Personal>();
                    WriteLine(obj.Name);
                    WriteLine(obj.SurName);

            }
            sr.Close();
        }

    }
}
