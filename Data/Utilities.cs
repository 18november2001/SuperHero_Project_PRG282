using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperHero_Project_PRG282.Data; 

namespace SuperHero_Project_PRG282.Data
{
    public class Utilities
    {
        public static (string Rank, string ThreatLevel) CalculateRankAndThreat(double score)
        {
            if (score >= 81) return ("S-Rank", "Finals Week");
            if (score >= 61) return ("A-Rank", "Midterm Madness");
            if (score >= 41) return ("B-Rank", "Group Project Gone Wrong");
            return ("C-Rank", "Pop Quiz");
        }

        public static Superhero Fromtxt(string line)
        {
            var parts = line.Split(',');
            if (parts.Length != 7)
                throw new FormatException("Invalid Superhero Metrics");
            string heroID = parts[0].Trim();
            string heroName = parts[1].Trim();
            string superPower = parts[2].Trim();
            if (!int.TryParse(parts[3].Trim(), out int age))
                throw new FormatException("Invalid age format");
            if (!double.TryParse(parts[4].Trim(), out double examScore))
                throw new FormatException("Invalid exam score format");
            (string rank, string threatLevel) = CalculateRankAndThreat(examScore);           
            return new Superhero(heroID, heroName, superPower, age, examScore, rank, threatLevel);
        }

        public static SupSummary Fromsumtxt(string line)
        {
            var parts = line.Split(',');
            if (parts.Length != 7)
                throw new FormatException("Invalid Superhero Summary Metrics");

                int totalHeroes = int.Parse(parts[0].Trim());
                int totalSH = int.Parse(parts[1].Trim());
                int totalAH = int.Parse(parts[2].Trim());
                int totalBH = int.Parse(parts[3].Trim());
                int totalCH = int.Parse(parts[4].Trim());
                double averageScore = double.Parse(parts[5].Trim());
                double averageAge = double.Parse(parts[6].Trim());
            return new SupSummary(totalHeroes, totalSH, totalAH, totalBH, totalCH, averageScore, averageAge);
        }
        public static SupSummary SummaryCalc()
        {
             int totalHeroes;
             int totalSH;
             int totalAH;
             int totalBH;
             int totalCH;
             double averageScore;
             double averageAge;

             List<Superhero> superheroes = new List<Superhero>();
             superheroes = FileOperations.ReadSuperheroesFromFile();

            
                totalHeroes = superheroes.Count;
                totalSH = superheroes.Count(s => s.Rank == "S-Rank");
                totalAH = superheroes.Count(s => s.Rank == "A-Rank");
                totalBH = superheroes.Count(s => s.Rank == "B-Rank");
                totalCH = superheroes.Count(s => s.Rank == "C-Rank");
                averageScore = superheroes.Average(s => s.ExamScore);
                averageAge = superheroes.Average(s => s.Age);
                return new SupSummary(totalHeroes, totalSH, totalAH, totalBH, totalCH, averageScore, averageAge);
            

        }

        public static string Tosumtxt(SupSummary supSummary)
        {
            return supSummary.ToString();
        }

        public static string Totxt(List<Superhero> superheros)
        {
            string result = "";
            foreach (Superhero superhero in superheros){ 
               result += superhero.ToString() +"\n";
            }
            return result;
        }


    }
}
