﻿using System;
using UnityEngine;
using Verse;

namespace SRP_Fauna
{
    public class Eggs : Building
    {
        //
        // Fields
        //
        private string eggParent;

        private bool justSpawned = true;

        private int hatchTime;

        //
        // Methods
        //

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.LookValue<int>(ref this.hatchTime, "HatchTime", 0, true);
            Scribe_Values.LookValue<bool>(ref this.justSpawned, "JustSpawned", true, true);
            Scribe_Values.LookValue<string>(ref this.eggParent, "Parents", null, false);
        }

        public string parentIs(string parents)
        {
            this.eggParent = parents;
            return null;
        }

        public override void Tick()
        {
            if (this.justSpawned)
            {
                if (this.eggParent == DomesticEggLayers.MegascarabDomestic.ToString())
                    this.hatchTime = 200000;
                if (this.eggParent == DomesticEggLayers.IguanaDomestic.ToString())
                    this.hatchTime = 260000; //260000
                if (this.eggParent == DomesticEggLayers.CobraDomestic.ToString())
                    this.hatchTime = 240000;
                if (this.eggParent == DomesticEggLayers.TortoiseDomestic.ToString())
                    this.hatchTime = 220000;
                if (this.eggParent == DomesticEggLayers.LacosdileDomestic.ToString())
                    this.hatchTime = 280000;
                if (this.eggParent == DomesticEggLayers.MegaslugDomestic.ToString())
                    this.hatchTime = 200000;

                this.justSpawned = false;
            }
            if (this.hatchTime > 0)
            {
                this.hatchTime--;
            }
            if (this.hatchTime <= 0)
            {

                //Awesome code
                foreach (AnimalsWild animalWild in Enum.GetValues(typeof(AnimalsWild)))
                {
                    if (this.eggParent == animalWild + "Domestic")
                    {
                        EggBirth(animalWild + "Kid");
                        break;
                    }                       
                }
                return;

                /* fuuuuuu
                Pawn pawn;
                IntVec3 intVec;
                int i;
                if (this.eggParent == DomesticEggLayers.MegascarabDomestic.ToString())
                {
                    i = UnityEngine.Random.Range(3, 12);
                    while (i > 0)
                    {
                        i--;
                        pawn = PawnGenerator.GeneratePawn(PawnKindDef.Named("MegascarabKid"), null);
                        intVec = GenAdj.RandomAdjacentCell8Way(base.Position);
                        GenSpawn.Spawn(pawn, intVec);
                    }
                    this.Destroy(0);
                    return;
                }
                if (this.eggParent == DomesticEggLayers.IguanaDomestic.ToString())
                {
                    i = UnityEngine.Random.Range(3, 9);
                    while (i > 0)
                    {
                        i--;
                        pawn = PawnGenerator.GeneratePawn(PawnKindDef.Named("IguanaKid"), null);
                        intVec = GenAdj.RandomAdjacentCell8Way(base.Position);
                        GenSpawn.Spawn(pawn, intVec);
                    }
                    this.Destroy(0);
                    return;
                }
                if (this.eggParent == DomesticEggLayers.CobraDomestic.ToString())
                {
                    i = UnityEngine.Random.Range(3, 9);
                    while (i > 0)
                    {
                        i--;
                        pawn = PawnGenerator.GeneratePawn(PawnKindDef.Named("CobraKid"), null);
                        intVec = GenAdj.RandomAdjacentCell8Way(base.Position);
                        GenSpawn.Spawn(pawn, intVec);
                    }
                    this.Destroy(0);
                    return;
                }
                if (this.eggParent == DomesticEggLayers.TortoiseDomestic.ToString())
                {
                    i = UnityEngine.Random.Range(3, 16);
                    while (i > 0)
                    {
                        i--;
                        pawn = PawnGenerator.GeneratePawn(PawnKindDef.Named("TortoiseKid"), null);
                        intVec = GenAdj.RandomAdjacentCell8Way(base.Position);
                        GenSpawn.Spawn(pawn, intVec);
                    }
                    this.Destroy(0);
                    return;
                }
                if (this.eggParent == DomesticEggLayers.LacosdileDomestic.ToString())
                {
                    i = UnityEngine.Random.Range(1, 3);
                    while (i > 0)
                    {
                        i--;
                        pawn = PawnGenerator.GeneratePawn(PawnKindDef.Named("LacosdileKid"), null);
                        intVec = GenAdj.RandomAdjacentCell8Way(base.Position);
                        GenSpawn.Spawn(pawn, intVec);
                    }
                    this.Destroy(0);
                    return;
                }
                if (this.eggParent == DomesticEggLayers.MegaslugDomestic.ToString())                   
                    EggBirth(AnimalsWild.Megaslug.ToString() + "Kid"); // Пока так, а там посмотрим

                //*/
                // End ifs
            }
        } // END public override void Tick()

        private void EggBirth(string kidSpecies)
        {
            int i = UnityEngine.Random.Range(3, 16);
            while (i > 0)
            {
                i--;
                Pawn pawn = PawnGenerator.GeneratePawn(PawnKindDef.Named(kidSpecies), null);
                IntVec3 intVec = GenAdj.RandomAdjacentCell8Way(base.Position);
                GenSpawn.Spawn(pawn, intVec);
            }
            this.Destroy(0);
            return;
        }
    }
}
