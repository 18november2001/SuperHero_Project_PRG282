using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SuperHero_Project_PRG282.Data
{
    public class FileOperations
    {
        private const string DataFile = "superheroes.txt";
        private const string SummaryFile = "summary.txt";


        public static List<Superhero> ReadSuperheroesFromFile()
        {
            List<Superhero> superheroes = new List<Superhero>();
            if (File.Exists(DataFile))
            {
                var lines = File.ReadAllLines(DataFile);
                foreach (var line in lines)
                {
                    try
                    {
                        Superhero superhero = Utilities.Fromtxt(line);
                        superheroes.Add(superhero);
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine($"Error parsing line: {line}. Exception: {e.Message}");
                    }
                }
            }
            return superheroes;
        }
       

        //write string to superheroes.txt
        public void WriteSuperheroesFile(List<Superhero> superheroes)
        {
            string content = Utilities.Totxt(superheroes);
            File.WriteAllText(DataFile, content);
        }

        //ReadAllText for summary.txt
        public SupSummary ReadSummaryFile()
        {
            SupSummary summary = new SupSummary();
            if (File.Exists(SummaryFile))
            {
                var lines = File.ReadAllLines(SummaryFile);
                summary = Utilities.Fromsumtxt(lines[0]);
            }
              return summary;

        }

        //write string to summary.txt
        public void WriteSummaryFile(SupSummary supSummary)
        {
            string content = Utilities.Tosumtxt(supSummary);
            File.WriteAllText(SummaryFile,content );
        }


    }
}
