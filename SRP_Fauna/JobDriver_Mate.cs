using RimWorld;
using System;
using System.Collections.Generic;
using UnityEngine;
using Verse;
using Verse.AI;

namespace SRP_Fauna
{
    internal class JobDriver_Mate : JobDriver
    {
        //
        // Fields
        //
        private FarmAnimal fm;

        //
        // Constructors
        //
        public JobDriver_Mate(Pawn pawn)
            : base(pawn)
        {
        }

        //
        // Methods
        //
        private void endMate()
        {
            FarmAnimal farmAnimal = base.TargetThingA as FarmAnimal;
            int num = UnityEngine.Random.Range(0, 100);
            if (num >= 65)
            {
                farmAnimal.Impregnate();
            }
            this.fm.Reserving(false);
            farmAnimal.jobs.EndCurrentJob(0);
        }

        private bool isKilled()
        {
            return this.pawn.Destroyed || this.pawn.Downed || this.pawn.Health <= 0;
        }

        protected override IEnumerable<Toil> MakeNewToils()
        {
			ToilFailConditions.FailOnDestroyed<JobDriver_Mate> (this, (TargetIndex)1);
			ToilFailConditions.FailOnDespawned<JobDriver_Mate> (this, (TargetIndex)1);
            ToilFailConditions.FailOn<JobDriver_Mate>(this, new Func<bool>(this.isKilled));
            yield return Toils_Reserve.Reserve ((TargetIndex)1, 0);
            yield return Toils_Goto.GotoThing ((TargetIndex)1, (PathMode)3);
            this.fm = (base.TargetThingA as FarmAnimal);
            this.fm.Reserving(true);
            Toil toil = new Toil
            {
				defaultCompleteMode = (ToilCompleteMode)3,
                defaultDuration = GenTime.SecondsToTicks(20)
            };
            toil.AddFinishAction(new Action(this.endMate));
            yield return toil;
            yield break;
        }
    }
}
