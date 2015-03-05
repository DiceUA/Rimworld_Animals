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
                /*/This fucking switch case can fuck your brain hard so I commented it and made IFs
                switch ((DomesticEggLayers)Enum.Parse(typeof(DomesticEggLayers), this.eggParent, true) {
                    case DomesticEggLayers.MegascarabDomestic:
                        this.hatchTime = 200000;
                        break;
                    case DomesticEggLayers.IguanaDomestic:
                        this.hatchTime = 260000;
                        break;
                    case DomesticEggLayers.CobraDomestic:
                        this.hatchTime = 240000;
                        break;
                    case DomesticEggLayers.TortoiseDomestic:
                        this.hatchTime = 220000;
                        break;
                    case DomesticEggLayers.LacosdileDomestic:
                        this.hatchTime = 280000;
                        break;
                    case DomesticEggLayers.MegaslugDomestic:
                        this.hatchTime = 200000;
                        break;    
                } //*///End of switch

                if (this.eggParent == DomesticEggLayers.MegascarabDomestic.ToString())
                    this.hatchTime = 200000;
                if (this.eggParent == DomesticEggLayers.IguanaDomestic.ToString())
                    this.hatchTime = 260000;
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
                }
                if (this.eggParent == DomesticEggLayers.MegaslugDomestic.ToString())
                {
                    i = UnityEngine.Random.Range(3, 16);
                    while (i > 0)
                    {
                        i--;
                        pawn = PawnGenerator.GeneratePawn(PawnKindDef.Named("MegaslugKid"), null);
                        intVec = GenAdj.RandomAdjacentCell8Way(base.Position);
                        GenSpawn.Spawn(pawn, intVec);
                    }
                    this.Destroy(0);
                }
            }
        }
    }
}
