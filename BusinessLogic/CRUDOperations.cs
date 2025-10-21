using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperHero_Project_PRG282.Data;

namespace SuperHero_Project_PRG282.BusinessLogic
{
    internal class CRUDOperations
    {

        public static string addSuperhero(string heroID, string heroName, string superPower, int age, double examScore)
        {
            List<Superhero> superheroes = new List<Superhero>();
            superheroes = FileOperations.ReadSuperheroesFromFile();

            (string Rank, string ThreatLevel) = Utilities.CalculateRankAndThreat(examScore);

            Superhero newHero = new Superhero(heroID, heroName, superPower, age, examScore, Rank, ThreatLevel);
            superheroes.Add(newHero);
            FileOperations fileOps = new FileOperations();
            fileOps.WriteSuperheroesFile(superheroes);
            return "Hero added";
        }
        public static List<Superhero> ViewAllSuperheros()
        {
            List<Superhero> superheroes = new List<Superhero>();
            superheroes = FileOperations.ReadSuperheroesFromFile();
            return superheroes;
        }

        public static string updateSuperhero(heroID, heroName, superPower, age, examScore, Rank, ThreatLevel) 
        {
            List<Superhero> superheroes = new List<Superhero>();
            superheroes = FileOperations.ReadSuperheroesFromFile();

            foreach (Superhero hero in superheroes)
            {
                if (hero.HeroID == heroID)
                {
                    hero.HeroName = heroName;
                    hero.SuperPower = superPower;
                    hero.Age = age;
                    hero.ExamScore = examScore;
                    hero.Rank = Rank;
                    hero.ThreatLevel = ThreatLevel;
                    return "Superhero Updated";
                }
            }
            return "Superhero not found";
        }

        public static string deleteSuperhero(heroID, heroName, superPower, age, examScore, Rank, ThreatLevel)
        {
            List<Superhero> superheroes = new List<Superhero>();
            superheroes = FileOperations.ReadSuperheroesFromFile();

            foreach(Superhero hero in superheroes)
            {
                if (hero.HeroID == heroID)
                {
                    superheroes.Remove(hero);
                    return "Superhero Deleted";
                }
            }
            return "Superhero not found";
        }
    }
}
