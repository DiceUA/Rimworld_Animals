using RimWorld;
using System;
using System.Collections.Generic;
using UnityEngine;
using Verse;
using Verse.AI;

namespace SRP_Fauna
{
    internal class JobDriver_giveBirth : JobDriver
    {
        //
        // Fields
        //
        private Eggs eg;

        //
        // Constructors
        //
        public JobDriver_giveBirth(Pawn pawn)
            : base(pawn)
        {
        }

        //
        // Methods
        //
        private void Birth()
        {
            //*
            foreach (AnimalsWild animalWild in Enum.GetValues(typeof(AnimalsWild)))
            {
                if (this.pawn.def.defName == animalWild + "Domestic" && (Enum.IsDefined(typeof(DomesticEggLayers), animalWild + "Domestic" )))
                {
                    LayEgg(this.pawn.def.defName);
                    break;
                }
                if (this.pawn.def.defName == animalWild + "Domestic" && !(Enum.IsDefined(typeof(DomesticEggLayers), animalWild + "Domestic" )))
                {                    
                    GiveAnimalBirth(animalWild.ToString());
                    break;
                }
            }
            // This is still bydlocode but probably it'll work, I'll try to make it with Lists */

            /* Avoid bydlocode, GM level
            if (this.pawn.def.defName == "MuffaloDomestic")
            {
                Pawn pawn = PawnGenerator.GeneratePawn(PawnKindDef.Named("MuffaloKid"), null);
                IntVec3 intVec = GenAdj.RandomAdjacentCell8Way(this.pawn.Position);
                GenSpawn.Spawn(pawn, intVec);
                return;
            }
            if (this.pawn.def.defName == "DeerDomestic")
            {
                Pawn pawn2 = PawnGenerator.GeneratePawn(PawnKindDef.Named("DeerKid"), null);
                IntVec3 intVec2 = GenAdj.RandomAdjacentCell8Way(this.pawn.Position);
                GenSpawn.Spawn(pawn2, intVec2);
                return;
            }
            if (this.pawn.def.defName == "DromedaryDomestic")
            {
                Pawn pawn3 = PawnGenerator.GeneratePawn(PawnKindDef.Named("DromedaryKid"), null);
                IntVec3 intVec3 = GenAdj.RandomAdjacentCell8Way(this.pawn.Position);
                GenSpawn.Spawn(pawn3, intVec3);
                return;
            }
            if (this.pawn.def.defName == "RhinocerosDomestic")
            {
                Pawn pawn4 = PawnGenerator.GeneratePawn(PawnKindDef.Named("RhinocerosKid"), null);
                IntVec3 intVec4 = GenAdj.RandomAdjacentCell8Way(this.pawn.Position);
                GenSpawn.Spawn(pawn4, intVec4);
                return;
            }
            /*if (this.pawn.def.defName == "SquirrelDomestic")
            {
                int i = UnityEngine.Random.Range(2, 4);
                while (i > 0)
                {
                    i--;
                    Pawn pawn5 = PawnGenerator.GeneratePawn(PawnKindDef.Named("SquirrelKid"), null);
                    IntVec3 intVec5 = GenAdj.RandomAdjacentCell8Way(this.pawn.Position);
                    GenSpawn.Spawn(pawn5, intVec5);
                }
                return;
            }
            if (this.pawn.def.defName == AnimalsWild.Squirrel + "Domestic")
            {
                GiveAnimalBirth(AnimalsWild.Squirrel.ToString());
            }
            if (this.pawn.def.defName == "BoomratDomestic")
            {
                int j = UnityEngine.Random.Range(2, 4);
                while (j > 0)
                {
                    j--;
                    Pawn pawn6 = PawnGenerator.GeneratePawn(PawnKindDef.Named("BoomratKid"), null);
                    IntVec3 intVec6 = GenAdj.RandomAdjacentCell8Way(this.pawn.Position);
                    GenSpawn.Spawn(pawn6, intVec6);
                }
                return;
            }
            if (this.pawn.def.defName == "MonkeyDomestic")
            {
                int k = UnityEngine.Random.Range(2, 3);
                while (k > 0)
                {
                    k--;
                    Pawn pawn7 = PawnGenerator.GeneratePawn(PawnKindDef.Named("MonkeyKid"), null);
                    IntVec3 intVec7 = GenAdj.RandomAdjacentCell8Way(this.pawn.Position);
                    GenSpawn.Spawn(pawn7, intVec7);
                }
                return;
            }
            if (this.pawn.def.defName == "BoarDomestic")
            {
                int l = UnityEngine.Random.Range(3, 9);
                while (l > 0)
                {
                    l--;
                    Pawn pawn8 = PawnGenerator.GeneratePawn(PawnKindDef.Named("BoarKid"), null);
                    IntVec3 intVec8 = GenAdj.RandomAdjacentCell8Way(this.pawn.Position);
                    GenSpawn.Spawn(pawn8, intVec8);
                }
                return;
            }
            if (this.pawn.def.defName == "MegascarabDomestic")
            {
                Thing thing = ThingMaker.MakeThing(ThingDef.Named("EggHatchery"), null);
                IntVec3 intVec9 = GenAdj.RandomAdjacentCell8Way(this.pawn.Position);
                this.eg = (thing as Eggs);
                this.eg.parentIs("MegascarabDomestic");
                GenSpawn.Spawn(thing, intVec9);
                return;
            }
            if (this.pawn.def.defName == "IguanaDomestic")
            {
                Thing thing2 = ThingMaker.MakeThing(ThingDef.Named("EggHatchery"), null);
                IntVec3 intVec10 = GenAdj.RandomAdjacentCell8Way(this.pawn.Position);
                this.eg = (thing2 as Eggs);
                this.eg.parentIs("IguanaDomestic");
                GenSpawn.Spawn(thing2, intVec10);
                return;
            }
            if (this.pawn.def.defName == "CobraDomestic")
            {
                Thing thing3 = ThingMaker.MakeThing(ThingDef.Named("EggHatchery"), null);
                IntVec3 intVec11 = GenAdj.RandomAdjacentCell8Way(this.pawn.Position);
                this.eg = (thing3 as Eggs);
                this.eg.parentIs("CobraDomestic");
                GenSpawn.Spawn(thing3, intVec11);
                return;
            }
            if (this.pawn.def.defName == "TortoiseDomestic")
            {
                Thing thing4 = ThingMaker.MakeThing(ThingDef.Named("EggHatchery"), null);
                IntVec3 intVec12 = GenAdj.RandomAdjacentCell8Way(this.pawn.Position);
                this.eg = (thing4 as Eggs);
                this.eg.parentIs("TortoiseDomestic");
                GenSpawn.Spawn(thing4, intVec12);
            }//*/// Bydlocode
        } 

        private void LayEgg(string animalSpecies)
        {           
            Thing thing = ThingMaker.MakeThing(ThingDef.Named("EggHatchery"), null);
            IntVec3 intVec = GenAdj.RandomAdjacentCell8Way(this.pawn.Position);
            this.eg = (thing as Eggs);
            this.eg.parentIs(animalSpecies);
            GenSpawn.Spawn(thing, intVec);
            return;            
        }

        private void GiveAnimalBirth (string animalSpecies)
        {
            Pawn pawn = PawnGenerator.GeneratePawn(PawnKindDef.Named(animalSpecies + "Kid"), null);
            IntVec3 intVec = GenAdj.RandomAdjacentCell8Way(this.pawn.Position);
            GenSpawn.Spawn(pawn, intVec);
            return;
        }

        private bool isKilled()
        {
            return this.pawn.Destroyed || this.pawn.Downed || this.pawn.Health <= 0;
        }

        protected override IEnumerable<Toil> MakeNewToils()
        {
			ToilFailConditions.FailOnDestroyed<JobDriver_giveBirth> (this, (TargetIndex)1);
			ToilFailConditions.FailOnDespawned<JobDriver_giveBirth> (this, (TargetIndex)1);
            ToilFailConditions.FailOn<JobDriver_giveBirth>(this, new Func<bool>(this.isKilled));
            Toil toil = new Toil
            {
				defaultCompleteMode = (ToilCompleteMode)1,
                defaultDuration = GenTime.SecondsToTicks(10)
            };
            toil.AddFinishAction(new Action(this.Birth));
            yield return toil;
            yield break;
        }
    }
}
