using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Verse;
using System.Text.RegularExpressions;

namespace SRP_Fauna
{
    public class Animal
    {
        //private string name;
        private string species;

        private AnimalsWild speciesEnum;

        //private bool eggLayer;

        private int pregnancyETA;

        private int maturityETA;

        private AnimalsInitializer animalInit  = new AnimalsInitializer();

        /// <summary>
        /// Constructors
        /// </summary>
        public Animal (string animal)
        {
            Species = animal;
        }
        public Animal ()
        {

        }

        /// <summary>
        /// Properties
        /// </summary>
        public string Species
        {
            get { return species; }
            set 
            { 
                species = value;
                CheckKind(species);
                SpecieToEnum(species);
                SetETAs();
                //IsEggLayer(species);                
            }
        }

        public int PregnancyETA
        {
            get { return pregnancyETA; }
        }

        public int MaturityETA
        {
            get { return maturityETA; }
        }

        public AnimalsWild SpeciesEnumerator
        {
            get { return speciesEnum; }
        }

        /// <summary>
        /// Methods
        /// </summary>
        private void SetETAs ()
        {
            pregnancyETA = animalInit.PregnancyETA(speciesEnum);
            maturityETA = animalInit.MaturityETA(speciesEnum);
        }
        //private void IsEggLayer (string animal)
        //{

        //    if (Enum.IsDefined(typeof(DomesticEggLayers), animal + "Domestic"))
        //        eggLayer = true;
        //    else
        //        eggLayer = false;
        //}

        private void SpecieToEnum (string animal)
        {
            foreach (AnimalsWild animalWild in Enum.GetValues(typeof(AnimalsWild)))
            {
                //Log.Message("Specie to enum try " + animalWild + "  " + animal);
                if (animal == animalWild.ToString())
                {
                    speciesEnum = animalWild;
                    break;
                }
            }
        }
        private void CheckKind (string animal)
        {
            string rPattern = "Domestic";
            string r1Pattern = "Kid";         
            if (species.Contains(rPattern))
                species = animal.Substring(0, animal.Length - rPattern.Length);
            else if (species.Contains(r1Pattern))
                species = animal.Substring(0, animal.Length - r1Pattern.Length);
            else
                species = animal;
        }
    }
}
