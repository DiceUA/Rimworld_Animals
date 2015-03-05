using System;
using System.Collections.Generic;
using System.Linq;
using Verse;
using Verse.AI;

namespace SRP_Fauna
{
    public class JobGiver_WanderPasture : JobGiver_Wander
    {
        //
        // Constructors
        //
        public JobGiver_WanderPasture()
        {
            this.wanderRadius = 7;
            this.ticksBetweenWandersRange = new IntRange(125, 200);
            this.wanderDestValidator = ((Pawn pawn, IntVec3 loc) => true);
        }

        //
        // Methods
        //

        protected override IntVec3 GetWanderRoot(Pawn pawn)
        {
            List<Building> list = (from Building g in Find.ListerBuildings.allBuildingsColonist
                                   where g.def.defName == "PastureMarker"
                                   select g).ToList<Building>();
            IntVec3 position;
            if (list.Count<Building>() == 0 || list == null)
            {
                position = pawn.Position;
            }
            else
            {
				Building building = list.RandomElement<Building>();
                if ((pawn.Position - building.Position).LengthHorizontalSquared <= 64)
                {
					IntVec3 intVec = GenAdj.CellsAdjacent8Way(building).ToList<IntVec3>().RandomElement<IntVec3>();
                    if (GenGrid.Standable(intVec) && Reachability.CanReach (pawn.Position, intVec, (PathMode)3, TraverseParms.For (pawn, (Danger)2, true)) && !GridsUtility.IsInPrisonCell(intVec))
                    {
                        return intVec;
                    }
                }
                position = pawn.Position;
            }
            return position;
        } //*/ override GetWanderRoot
    }
}
