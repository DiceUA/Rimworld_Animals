﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using RimWorld;
using Verse;
using UnityEngine;
using System.Text.RegularExpressions;

namespace SRP_Fauna
{
    internal class ModInitializer : ITab
    {
        public ModInitializer ()
        {
            Log.Message("SRP_Fauna Initialized"); // Сообщение в ЛОГ при загрузке мода.
//            Log.Message(Directory.GetCurrentDirectory().ToString()); // Получаем директорию в которой хранится экзешник римворлда.
//            string modDir = Directory.GetCurrentDirectory() + @"\Mods\SRP_Fauna\Defs\ThingDefs\";
//            Log.Message(modDir);
//            List<Animal> animalList = new List<Animal>();
//            DirectoryInfo dir = new DirectoryInfo(modDir);
            /* И этот сука код почему-то не работает из-за FileInfo, хер знает почему, поэтому будем ебать себе мозг с перечислениями, нахуй все.
            FileInfo[] file = dir.GetFiles("SRP_anim*.xml");
            Log.Message("Total number of files " + file.Length.ToString());
            string pattern = "(SRP_animHusb_)";
            foreach (FileInfo f in file)
            {
                string specie = Regex.Replace(f.Name, pattern, String.Empty);
                specie = specie.Substring(0, specie.Length - 4);                
                animalList.Add(new Animal() { Species = specie });
            }
            foreach (Animal a in animalList)
            {
                //if (a.Species == "Furx")
                Log.Message(a.Species.ToString());
            }            
            //*/
            GameObject obj = new GameObject("SRP_Fauna_ModInitializer");
            UnityEngine.Object.DontDestroyOnLoad(obj);
        }
        protected override void FillTab()
        {
        }
    }
}
