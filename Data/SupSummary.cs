using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SuperHero_Project_PRG282.Data
{
    public class SupSummary
    {
        private int totalHeroes;
        private int totalSH;
        private int totalAH;
        private int totalBH;
        private int totalCH;
        private double averageScore;
        private double averageAge;

        public SupSummary() { }

        public SupSummary(int totalHeroes, int totalSH, int totalAH,int totalBH, int totalCH, double averageScore, double averageAge )
        {
            this.totalHeroes = totalHeroes;
            this.totalSH = totalSH;
            this.totalAH = totalAH;
            this.totalBH = totalBH;
            this.totalCH = totalCH;
            this.averageScore = averageScore;
            this.averageAge = averageAge;
           
        }

        public int TotalHeroes { get { return totalHeroes; } set { totalHeroes = value; } }
        public int TotalSH { get { return totalSH; } set { totalSH = value; } }
        public int TotalAH { get { return totalAH; } set { totalAH = value; } }
        public int TotalBH { get { return totalBH; } set { totalBH = value; } }
        public int TotalCH { get { return totalCH; } set { totalCH = value; } }
        public double AverageScore { get { return averageScore; } set { averageScore = value; } }
        public double AverageAge { get { return averageAge; } set { averageAge = value; } }
        

        public override string ToString()
        {
            return $"{totalHeroes},{totalSH},{totalAH},{totalBH},{totalCH},{averageScore},{averageAge}";
        }
    }
}
