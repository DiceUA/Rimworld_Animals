using RimWorld;
using System;
using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace SRP_Fauna
{
    internal class Pawn_WildAnimal : Pawn, ThoughtGiver
    {
        //
        // Properties
        //
        public override string Label
        {
            get
            {
                return base.KindLabel.ToString();
            }
        }

        //
        // Methods
        //
        private void addPawnCaptureDesignation()
        {
            Find.DesignationManager.AddDesignation(new Designation(this, DefDatabase<DesignationDef>.GetNamed("CaptureAnimal", true)));
        }

        public override void DrawGUIOverlay()
        {
            base.DrawGUIOverlay();
        }

        private Designation getCaptureDesignationOnSelf()
        {
            return Find.DesignationManager.DesignationOn(this, DefDatabase<DesignationDef>.GetNamed("CaptureAnimal", true));
        }

        public override IEnumerable<Gizmo> GetGizmos()
        {
            if (Find.ResearchManager.IsFinished(ResearchProjectDef.Named("AnimalHusbandry")) && this.isWildAnimal())
            {
                Command_Toggle command_Toggle = new Command_Toggle();
                command_Toggle.icon = ContentFinder<Texture2D>.Get("Buttons/CaptureAnimal", true);
                command_Toggle.isActive = new Func<bool>(this.isDesignatedToBeCaptured);
                if (this.isDesignatedToBeCaptured())
                {
                    command_Toggle.toggleAction = new Action(this.removePawnCaptureDesignation);
                }
                else
                {
                    command_Toggle.toggleAction = new Action(this.addPawnCaptureDesignation);
                }
                command_Toggle.defaultLabel = "Capture Animal";
                command_Toggle.defaultDesc = "Capture Animal";
                command_Toggle.hotKey = KeyBindingDefOf.Misc3;
                yield return command_Toggle;
            }
            yield break;
        }

        private WorkTypeDef getDef(string defName)
        {
            return DefDatabase<WorkTypeDef>.GetNamed(defName, true);
        }

        public Thought GiveObservedThought()
        {
            Thought result;
            if (this.isWildAnimal())
            {
                result = new Thought_Observation(ThoughtDef.Named("SawWildAnimal"), this);
            }
            else
            {
                result = null;
            }
            return result;
        }

        private bool isDesignatedToBeCaptured()
        {
            return this.getCaptureDesignationOnSelf() != null;
        }

        private bool isWildAnimal()
        {
            return base.RaceProps.IsAnimal && base.Faction == null;
        }

        private void removePawnCaptureDesignation()
        {
            Designation captureDesignationOnSelf = this.getCaptureDesignationOnSelf();
            if (captureDesignationOnSelf != null)
            {
                Find.DesignationManager.RemoveDesignation(captureDesignationOnSelf);
            }
        }

        public override void Tick()
        {
            base.Tick();
        }
    }
}
