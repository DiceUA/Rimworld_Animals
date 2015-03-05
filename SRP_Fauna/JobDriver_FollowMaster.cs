using RimWorld;
using System;
using System.Collections.Generic;
using Verse;
using Verse.AI;

namespace SRP_Fauna
{
    internal class JobDriver_FollowMaster : JobDriver
    {
        //
        // Constructors
        //
        public JobDriver_FollowMaster(Pawn pawn)
            : base(pawn)
        {
        }

        //
        // Methods
        //
        private void endFollow()
        {
        }

        private bool isKilled()
        {
            return this.pawn.Destroyed || this.pawn.Downed || this.pawn.Health <= 0;
        }

        protected override IEnumerable<Toil> MakeNewToils()
        {
			ToilFailConditions.FailOnDestroyed<JobDriver_FollowMaster>(this, TargetIndex.A);
			ToilFailConditions.FailOnDespawned<JobDriver_FollowMaster>(this, TargetIndex.A);
            ToilFailConditions.FailOn<JobDriver_FollowMaster>(this, new Func<bool>(this.isKilled));
			yield return Toils_Goto.GotoThing(TargetIndex.A, PathMode.ClosestTouch);
            Toil toil = new Toil
            {
                defaultCompleteMode = ToilCompleteMode.PatherArrival,
                defaultDuration = GenTime.SecondsToTicks(1)
            };
            toil.AddFinishAction(new Action(this.endFollow));
            yield return toil;
            yield break;
        }
    }
}
