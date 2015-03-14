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
    }
}
