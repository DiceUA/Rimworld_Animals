using RimWorld;
using System;
using Verse;
using Verse.AI;

namespace SRP_Fauna
{
    internal class JobGiver_AttackNearbyTargetPawn : ThinkNode_JobGiver
    {
        private const int EnemyForgetTime = 200;
        private const int MaxMeleeChaseTicksMax = 600;
        public const float MaxSearchDistance = 3f;

        protected override Job TryGiveTerminalJob(Pawn pawn)
        {
            IntVec3 vec = pawn.Position; //need to initialise
            Pawn enemyTarget = pawn.mindState.enemyTarget as Pawn;
            if (enemyTarget == null)
            {
                return null;
            }
            if ((!enemyTarget.Destroyed && !enemyTarget.Downed) && ((Find.TickManager.TicksGame - pawn.mindState.lastEngageTargetTick) <= 200))
            {
                vec = pawn.Position - enemyTarget.Position;
            }
            if (!((vec.LengthHorizontalSquared <= 9f) && GenSight.LineOfSight(pawn.Position, enemyTarget.Position, false)))
            {
                pawn.mindState.enemyTarget = null;
                return null;
            }
            if ((pawn.story != null) && pawn.story.WorkTagIsDisabled(WorkTags.Violent))
            {
                return null;
            }
            return new Job(JobDefOf.AttackMelee, enemyTarget) { maxNumMeleeAttacks = 1, MaxDuration = Rand.Range(200, 600) };
        }
    }
}

