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
            if (this.pawn.def.defName == "D_Muffalo")
            {
                Pawn pawn = PawnGenerator.GeneratePawn(PawnKindDef.Named("MuffaloKid"), null);
                IntVec3 intVec = GenAdj.RandomAdjacentCell8Way(this.pawn.Position);
                GenSpawn.Spawn(pawn, intVec);
                return;
            }
            if (this.pawn.def.defName == "D_Deer")
            {
                Pawn pawn2 = PawnGenerator.GeneratePawn(PawnKindDef.Named("DeerKid"), null);
                IntVec3 intVec2 = GenAdj.RandomAdjacentCell8Way(this.pawn.Position);
                GenSpawn.Spawn(pawn2, intVec2);
                return;
            }
            if (this.pawn.def.defName == "D_Dromedary")
            {
                Pawn pawn3 = PawnGenerator.GeneratePawn(PawnKindDef.Named("DromedaryKid"), null);
                IntVec3 intVec3 = GenAdj.RandomAdjacentCell8Way(this.pawn.Position);
                GenSpawn.Spawn(pawn3, intVec3);
                return;
            }
            if (this.pawn.def.defName == "D_Rhinoceros")
            {
                Pawn pawn4 = PawnGenerator.GeneratePawn(PawnKindDef.Named("RhinocerosKid"), null);
                IntVec3 intVec4 = GenAdj.RandomAdjacentCell8Way(this.pawn.Position);
                GenSpawn.Spawn(pawn4, intVec4);
                return;
            }
            if (this.pawn.def.defName == "D_Squirrel")
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
            if (this.pawn.def.defName == "D_Boomrat")
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
            if (this.pawn.def.defName == "D_Monkey")
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
            if (this.pawn.def.defName == "D_Boar")
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
            if (this.pawn.def.defName == "D_Megascarab")
            {
                Thing thing = ThingMaker.MakeThing(ThingDef.Named("EggHatchery"), null);
                IntVec3 intVec9 = GenAdj.RandomAdjacentCell8Way(this.pawn.Position);
                this.eg = (thing as Eggs);
                this.eg.parentIs("D_Megascarab");
                GenSpawn.Spawn(thing, intVec9);
                return;
            }
            if (this.pawn.def.defName == "D_Iguana")
            {
                Thing thing2 = ThingMaker.MakeThing(ThingDef.Named("EggHatchery"), null);
                IntVec3 intVec10 = GenAdj.RandomAdjacentCell8Way(this.pawn.Position);
                this.eg = (thing2 as Eggs);
                this.eg.parentIs("D_Iguana");
                GenSpawn.Spawn(thing2, intVec10);
                return;
            }
            if (this.pawn.def.defName == "D_Cobra")
            {
                Thing thing3 = ThingMaker.MakeThing(ThingDef.Named("EggHatchery"), null);
                IntVec3 intVec11 = GenAdj.RandomAdjacentCell8Way(this.pawn.Position);
                this.eg = (thing3 as Eggs);
                this.eg.parentIs("D_Cobra");
                GenSpawn.Spawn(thing3, intVec11);
                return;
            }
            if (this.pawn.def.defName == "D_Tortoise")
            {
                Thing thing4 = ThingMaker.MakeThing(ThingDef.Named("EggHatchery"), null);
                IntVec3 intVec12 = GenAdj.RandomAdjacentCell8Way(this.pawn.Position);
                this.eg = (thing4 as Eggs);
                this.eg.parentIs("D_Tortoise");
                GenSpawn.Spawn(thing4, intVec12);
            }
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
