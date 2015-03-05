using RimWorld;
using System;
using System.Collections.Generic;
using Verse;
using Verse.AI;

namespace SRP_Fauna
{
    public class WorkGiver_CaptureAnimal : WorkGiver
    {
        //
        // Fields
        //
        private DesignationDef captureDesDef = DefDatabase<DesignationDef>.GetNamed("CaptureAnimal", true);

        private JobDef captureJobDef = DefDatabase<JobDef>.GetNamed("CaptureAnimal", true);

        //
        // Properties
        //
        public override IEnumerable<Thing> PotentialWorkThingsGlobal (Pawn pawn)
        {
            
            foreach (Designation current in Find.DesignationManager.DesignationsOfDef(this.captureDesDef))
            {
                yield return current.target.Thing;
            }
            yield break;
            
        }

        //
        // Constructors
        //
        public WorkGiver_CaptureAnimal(WorkGiverDef giverDef)
            : base(giverDef)
        {
        }

        //
        // Methods
        //
        public override Job JobOnThing(Pawn pawn, Thing t)
        {
            Pawn_WildAnimal pawn_WildAnimal = t as Pawn_WildAnimal;
            Job result;
            if (pawn_WildAnimal == null)
            {
                result = null;
            }
            else
            {
                if (!ReservationUtility.CanReserve(pawn, pawn_WildAnimal, 0))
                {
                    result = null;
                }
                else
                {
                    if (Find.DesignationManager.DesignationOn(t, this.captureDesDef) == null)
                    {
                        result = null;
                    }
                    else
                    {
                        result = new Job(this.captureJobDef, pawn_WildAnimal);
                    }
                }
            }
            return result;
        }
    }
}
