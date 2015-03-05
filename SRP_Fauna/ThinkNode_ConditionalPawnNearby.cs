using System;
using System.Runtime.InteropServices;
using Verse;
using Verse.AI;

namespace SRP_Fauna
{
    public class ThinkNode_ConditionalPawnNearby : ThinkNode_Priority
    {
        public bool AttackOtherAnimals = false;
        private int CheckForEnemyTime;

        public virtual Pawn FindTarget(Pawn pawn, float MaxAttackDistance, [Optional, DefaultParameterValue(false)] bool attackAnimals)
        {
            Predicate<Thing> validator = delegate (Thing t) {
                if (t == pawn)
                {
                    return false;
                }
                Pawn pawn1 = t as Pawn;
                if (pawn1.Downed)
                {
                    return false;
                }
                if ((!t.SpawnedInWorld || t.Destroyed) || (t.Position == IntVec3.Invalid))
                {
                    return false;
                }
                if (!(attackAnimals || !pawn1.RaceProps.IsAnimal))
                {
                    return false;
                }
                if (pawn1.def == pawn.def)
                {
                    return false;
                }
                if (!GenSight.LineOfSight(pawn.Position, t.Position, false))
                {
                    return false;
                }
                return true;
            };
            Pawn pawn2 = (Pawn) GenClosest.ClosestThingReachable(pawn.Position, ThingRequest.ForGroup(ThingRequestGroup.Pawn), PathMode.ClosestTouch, TraverseParms.For(pawn, Danger.Some, false), MaxAttackDistance, validator, null, 2);
            if (pawn2 == null)
            {
                return null;
            }
            return pawn2;
        }

        public override JobPackage TryIssueJobPackage(Pawn pawn)
        {
            Pawn enemyTarget = pawn.mindState.enemyTarget as Pawn;
            if (enemyTarget == null)
            {
                if ((Find.TickManager.TicksGame - pawn.mindState.lastEngageTargetTick) < this.CheckForEnemyTime)
                {
                    return null;
                }
                pawn.mindState.lastEngageTargetTick = Find.TickManager.TicksGame;
                this.CheckForEnemyTime = Rand.RangeInclusive(180, 600);
                enemyTarget = this.FindTarget(pawn, 3f, this.AttackOtherAnimals);
                if (enemyTarget == null)
                {
                    return null;
                }
                pawn.mindState.enemyTarget = enemyTarget;
            }
            return base.TryIssueJobPackage(pawn);
        }
    }
}

