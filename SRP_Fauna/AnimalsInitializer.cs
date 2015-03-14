using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SRP_Fauna
{
    public class AnimalsInitializer
    {

        private Dictionary<AnimalsWild, int> animalPregnancyETA = new Dictionary<AnimalsWild, int>();
        private Dictionary<AnimalsWild, int> animalGrowRate = new Dictionary<AnimalsWild, int>();

        public AnimalsInitializer()
        {
            
            //Вариант 1. Это хуйня полная. Но для теста покатит.
            //Pregnancy timers
            animalPregnancyETA.Add(AnimalsWild.Muffalo, 300000);
            animalPregnancyETA.Add(AnimalsWild.Deer, 265000);
            animalPregnancyETA.Add(AnimalsWild.Squirrel, 190000);
            animalPregnancyETA.Add(AnimalsWild.Boomrat, 210000);
            animalPregnancyETA.Add(AnimalsWild.Dromedary, 295000);
            animalPregnancyETA.Add(AnimalsWild.Monkey, 230000);
            animalPregnancyETA.Add(AnimalsWild.Rhinoceros, 320000);
            animalPregnancyETA.Add(AnimalsWild.WildBoar, 270000);
            animalPregnancyETA.Add(AnimalsWild.Furx, 274000);
            animalPregnancyETA.Add(AnimalsWild.Rimdog, 273000);
            animalPregnancyETA.Add(AnimalsWild.Rimram, 245000);
            animalPregnancyETA.Add(AnimalsWild.Rimwolf, 275000);
            animalPregnancyETA.Add(AnimalsWild.Snork, 280000);
            animalPregnancyETA.Add(AnimalsWild.Megascarab, 150000);
            animalPregnancyETA.Add(AnimalsWild.Iguana, 180000);
            animalPregnancyETA.Add(AnimalsWild.Cobra, 170000);
            animalPregnancyETA.Add(AnimalsWild.Tortoise, 190000);
            animalPregnancyETA.Add(AnimalsWild.Lacosdile, 200000);
            animalPregnancyETA.Add(AnimalsWild.Megaslug, 160000);

            //Time to get mature 

            animalGrowRate.Add(AnimalsWild.Muffalo, 300000);
            animalGrowRate.Add(AnimalsWild.Deer, 210000);
            animalGrowRate.Add(AnimalsWild.Squirrel, 120000);
            animalGrowRate.Add(AnimalsWild.Boomrat, 170000);
            animalGrowRate.Add(AnimalsWild.Dromedary, 265000);
            animalGrowRate.Add(AnimalsWild.Monkey, 220000);
            animalGrowRate.Add(AnimalsWild.Rhinoceros, 290000);
            animalGrowRate.Add(AnimalsWild.WildBoar, 200000);
            animalGrowRate.Add(AnimalsWild.Furx, 190000);
            animalGrowRate.Add(AnimalsWild.Rimdog, 200000);
            animalGrowRate.Add(AnimalsWild.Rimram, 180000);
            animalGrowRate.Add(AnimalsWild.Rimwolf, 195000);
            animalGrowRate.Add(AnimalsWild.Snork, 185000);
            animalGrowRate.Add(AnimalsWild.Megascarab, 340000);
            animalGrowRate.Add(AnimalsWild.Iguana, 220000);
            animalGrowRate.Add(AnimalsWild.Cobra, 200000);
            animalGrowRate.Add(AnimalsWild.Tortoise, 310000);
            animalGrowRate.Add(AnimalsWild.Lacosdile, 200000);
            animalGrowRate.Add(AnimalsWild.Megaslug, 280000);


        }

        public int PregnancyETA (AnimalsWild animal)
        {
            int timeToBirth;
            animalPregnancyETA.TryGetValue(animal, out timeToBirth);
            return timeToBirth;
        }

        public int MaturityETA (AnimalsWild animal)
        {
            int timeToMature;
            animalGrowRate.TryGetValue(animal, out timeToMature);
            return timeToMature;
        }        
    }
}
