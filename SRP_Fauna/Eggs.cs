using System;
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
                if (this.eggParent == "D_Megascarab")
                {
                    this.hatchTime = 200000;
                }
                else
                {
                    if (this.eggParent == "D_Iguana")
                    {
                        this.hatchTime = 260000;
                    }
                    else
                    {
                        if (this.eggParent == "D_Cobra")
                        {
                            this.hatchTime = 240000;
                        }
                        else
                        {
                            if (this.eggParent == "D_Tortoise")
                            {
                                this.hatchTime = 220000;
                            }
                        }
                    }
                }
                this.justSpawned = false;
            }
            if (this.hatchTime > 0)
            {
                this.hatchTime--;
            }
            if (this.hatchTime == 0)
            {
                if (this.eggParent == "D_Megascarab")
                {
                    int i = UnityEngine.Random.Range(3, 12);
                    while (i > 0)
                    {
                        i--;
                        Pawn pawn = PawnGenerator.GeneratePawn(PawnKindDef.Named("MegascarabKid"), null);
                        IntVec3 intVec = GenAdj.RandomAdjacentCell8Way(base.Position);
                        GenSpawn.Spawn(pawn, intVec);
                    }
                    this.Destroy(0);
                    return;
                }
                if (this.eggParent == "D_Iguana")
                {
                    int j = UnityEngine.Random.Range(3, 9);
                    while (j > 0)
                    {
                        j--;
                        Pawn pawn2 = PawnGenerator.GeneratePawn(PawnKindDef.Named("IguanaKid"), null);
                        IntVec3 intVec2 = GenAdj.RandomAdjacentCell8Way(base.Position);
                        GenSpawn.Spawn(pawn2, intVec2);
                    }
                    this.Destroy(0);
                    return;
                }
                if (this.eggParent == "D_Cobra")
                {
                    int k = UnityEngine.Random.Range(3, 9);
                    while (k > 0)
                    {
                        k--;
                        Pawn pawn3 = PawnGenerator.GeneratePawn(PawnKindDef.Named("CobraKid"), null);
                        IntVec3 intVec3 = GenAdj.RandomAdjacentCell8Way(base.Position);
                        GenSpawn.Spawn(pawn3, intVec3);
                    }
                    this.Destroy(0);
                    return;
                }
                if (this.eggParent == "D_Tortoise")
                {
                    int l = UnityEngine.Random.Range(3, 16);
                    while (l > 0)
                    {
                        l--;
                        Pawn pawn4 = PawnGenerator.GeneratePawn(PawnKindDef.Named("TortoiseKid"), null);
                        IntVec3 intVec4 = GenAdj.RandomAdjacentCell8Way(base.Position);
                        GenSpawn.Spawn(pawn4, intVec4);
                    }
                    this.Destroy(0);
                }
            }
        }
    }
}
