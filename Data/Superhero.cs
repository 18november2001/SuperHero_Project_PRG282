using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHero_Project_PRG282.Data
{
    public class Superhero
    {
        private string heroID;
        private string heroName;
        private string superPower;
        private int age;
        private double examScore;
        private string rank;
        private string threatLevel;

        public Superhero(string heroID, string heroName, string superPower, int age, double examScore, string rank, string threatLevel)
        {
            this.age = age;
            this.examScore = examScore;
            this.heroID = heroID;
            this.heroName = heroName;
            this.superPower = superPower;
            this.rank = rank;
            this.threatLevel = threatLevel;

        }

        public string HeroID { get { return heroID; } set { heroID = value; } }
        public string HeroName { get { return heroName; } set { heroName = value; } }
        public string SuperPower { get { return superPower; } set { superPower = value; } }
        public int Age { get { return age; } set { age = value; } }
        public double ExamScore { get { return examScore; } set { examScore = value; } }
        public string Rank { get { return rank; } set { rank = value; } }
        public string ThreatLevel { get { return threatLevel; } set { threatLevel = value; } }

        public override string ToString()
        {
            return $"{heroID},{heroName},{superPower},{age},{examScore},{rank},{threatLevel}";
        }

    }
}
