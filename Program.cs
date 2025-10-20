using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

// write in terminal when done : git push -u origin master
//when saving: git commit -m "Initial commit"
namespace SuperHero_Project_PRG282
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    public class FileService
    {
        private const string DataFile = "superheroes.txt";
        private const string SummaryFile = "summary.txt";

        //superhero model
        public class Superhero
        {
            public string HeroID { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public string SuperPower { get; set; }
            public int ExamScore { get; set; }
            public string Rank { get; set; }
            public string ThreatLevel { get; set; }
        }

        //rank and threat calculation
        public static (string Rank, string ThreatLevel) CalculateRankAndThreat(int score)
        {
            if (score >= 81) return ("S-Rank", "Finals Week");
            if (score >= 61) return ("A-Rank", "Midterm Madness");
            if (score >= 41) return ("B-Rank", "Group Project Gone Wrong");
            return ("C-Rank", "Pop Quiz");
        }

        //read all superheroes from file
        public List<Superheroes> LoadSuperheroes()
        {
            var heroes = new List<Superhero>();
            if (!File.Exists(DataFile)) return heroes;

            foreach (var line in File.ReadAllLines(DataFile))
            {
                var parts = line.Split('|');
                if (parts.Length == 7)
                {
                    heroes.Add(new Superhero
                    {
                        HeroID = parts[0],
                        Name = parts[1],
                        Age = int.Parse(parts[2]),
                        SuperPower = parts[3],
                        ExamScore = int.Parse(parts[4]),
                        Rank = parts[5],
                        ThreatLevel = parts[6]
                    });
                }
            }
            return heroes;
        }

        //save all superheroes to file
        public void SaveSuperheroes(List<Superhero> heroes)
        {
            var lines = heroes.Select(h => $"{h.HeroID}|{h.Name}|{h.Age}|{h.SuperPower}|{h.ExamScore}|{h.Rank}|{h.ThreatLevel}");
            File.WriteAllLines(DataFile, lines);
        }

        //add new superhero
        public void AddSuperhero(Superhero hero)
        {
            var (rank, threat) = CalculateRankAndThreat(hero.ExamScore);
            hero.Rank = rank;
            hero.ThreatLevel = threat;

            using (StreamWriter sw = File.AppendText(DataFile))
            {
                sw.WriteLine($"{hero.HeroID}|{hero.Name}|{hero.Age}|{hero.SuperPower}|{hero.ExamScore}|{hero.Rank}|{hero.ThreatLevel}");
            }
        }

        //generate summary report
        public void GenerateSummaryReport()
        {
            int total = heroes.Count();
            double avgAge = heroes.Average(h => h.Age);
            double avgScore = heroes.Average(h => h.ExamScore);
            var rankCounts = heroes.GroupBy(h => h.Rank.ToDictionary(g => g.Key, g => g.Count()));

            using (StreamWriter writer = new StreamWriter(SummaryFile))
            {
                writer.WriteLine($"Total Superheroes: {total}");
                writer.WriteLine($"Average Age: {avgAge:F1}");
                writer.WriteLine($"Average Exam Score: {avgScore:F1}");
                writer.WriteLine("Rank Distribution:");
                foreach (var rank in new[] { "S-Rank", "A-Rank", "B-Rank", "C-Rank" })
                {
                    writer.WriteLine($"  {rank}: {rankCounts.GetValueOrDefault(rank, 0)}");
                }
            }
        }

        //ReadAllText for superheroes.txt
        public string ReadSuperheroesFile()
        {
            return File.Exists(DataFile) ? File.ReadAllText(DataFile) : string.Empty;
        }

        //write string to superheroes.txt
        public void WriteSuperheroesFile(string content)
        {
            File.WriteAllText(DataFile, content);
        }

        //ReadAllText for summary.txt
        public string ReadSummaryFile()
        {
            return File.Exists(SummaryFile) ? File.ReadAllText(SummaryFile) : string.Empty;
        }

        //write string to summary.txt
        public void WriteSummaryFile(string content)
        {
            File.WriteAllText(SummaryFile, content);
        }
    }
}



