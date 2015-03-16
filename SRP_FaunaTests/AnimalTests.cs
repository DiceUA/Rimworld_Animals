using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SRP_Fauna;
using Verse;

namespace SRP_FaunaTests
{
    [TestClass]
    public class AnimalTests
    {
        [TestMethod]
        public void AnimalSubstring()
        {
            //arrange
            string animalSpecie = "FurxDomestic";
            string expected = "Furx";
            var animal = new Animal(animalSpecie);
            //act
            string actual = animal.Species;
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AnimalSubstring_Property()
        {
            //arrange
            string animalSpecie = "MuffaloDomestic";
            string expected = "Muffalo";
            var animal = new Animal();
            //act
            animal.Species = animalSpecie;
            string actual = animal.Species;
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Create_Animal_Kid()
        {
            //arrange
            string animalSpecie = "MuffaloKid";
            string expected = "Muffalo";
            var animal = new Animal();
            //act
            animal.Species = animalSpecie;
            string actual = animal.Species;
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Create_Animal_NoKind()
        {
            //arrange
            string animalSpecie = "Squirrel";
            string expected = "Squirrel";
            var animal = new Animal();
            //act
            animal.Species = animalSpecie;
            string actual = animal.Species;
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ETAs()
        {
            //arrange
            string animalSpecie = "SquirrelDomestic";
            int expectedMaturity = 120000;
            int expectedPregnancy = 190000;
            var animal = new Animal();
            //act
            animal.Species = animalSpecie;
            int actualMaturity = animal.MaturityETA;
            int actualPregnancy = animal.PregnancyETA;
            //assert            
            Assert.AreEqual(expectedMaturity, actualMaturity);
            Assert.AreEqual(expectedPregnancy, actualPregnancy);
        }
        [TestMethod]
        public void Enum_Test()
        {
            //arrange
            string animalSpecie = "SquirrelDomestic";            
            var animal = new Animal();
            //act
            animal.Species = animalSpecie;
            AnimalsWild actualSpecies = animal.SpeciesEnumerator;
            //assert            
            Assert.AreEqual(AnimalsWild.Squirrel, actualSpecies);            
        }
    }
}
