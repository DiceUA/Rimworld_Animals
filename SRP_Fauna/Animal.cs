using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SRP_Fauna
{
    public class Animal
    {
        private string name;
        private string species;
        private bool eggLayer;

        public string Species
        {
            get { return species; }
            set { species = value; }
        }

        public bool EggLayer
        {
            get { return eggLayer; }
            set {
                if (Enum.IsDefined(typeof(DomesticEggLayers), value + "Domestic"))
                    eggLayer = true;
                else
                    eggLayer = false;           
            }
        }

        private bool IsEggLayer (string animalWild)
        {

            if (Enum.IsDefined(typeof(DomesticEggLayers), animalWild + "Domestic" ))
                return true;
            else
                return false;
        }
    }
}
