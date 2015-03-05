﻿using RimWorld;
using System;
using System.Collections.Generic;
using UnityEngine;
using Verse;
using Verse.AI;

namespace SRP_Fauna
{
    internal class JobDriver_CaptureAnimal : JobDriver
    {
        //
        // Fields
        //
        private Pawn_WildAnimal animal;

        private FarmAnimal d_animal;

        private string animalKind;

        //
        // Constructors
        //
        public JobDriver_CaptureAnimal(Pawn pawn)
            : base(pawn)
        {
        }

        //
        // Methods
        //
        protected override IEnumerable<Toil> MakeNewToils()
        {
			ToilFailConditions.FailOnDestroyed<JobDriver_CaptureAnimal>(this, (TargetIndex)1);
            ToilFailConditions.FailOnThingMissingDesignation<JobDriver_CaptureAnimal>(this, TargetIndex.A, DefDatabase<DesignationDef>.GetNamed("CaptureAnimal", true));
			ToilFailConditions.FailOnDespawned<JobDriver_CaptureAnimal>(this, (TargetIndex)1);
            yield return Toils_Reserve.Reserve ((TargetIndex)1, 0);
            yield return Toils_Goto.GotoThing ((TargetIndex)1, (PathMode)2);
            this.animal = (base.TargetThingA as Pawn_WildAnimal);
            this.animal.jobs.StopAll(false);
            this.animal.jobs.StartJob(new Job(JobDefOf.Wait));
            Toil toil = new Toil
            {
				defaultCompleteMode = (ToilCompleteMode)3,
                defaultDuration = GenTime.SecondsToTicks(15)
            };
            toil.AddFinishAction(new Action(this.TryCapture));
            yield return toil;
            yield break;
        }

        private void TryCapture()
        {
            if (this.animal.def.defName == "Muffalo")
            {
                this.animalKind = "MuffaloDomestic";
            }
            else
            {
                if (this.animal.def.defName == "Deer")
                {
                    this.animalKind = "DeerDomestic";
                }
                else
                {
                    if (this.animal.def.defName == "Squirrel")
                    {
                        this.animalKind = "SquirrelDomestic";
                    }
                    else
                    {
                        if (this.animal.def.defName == "Boomrat")
                        {
                            this.animalKind = "BoomratDomestic";
                        }
                        else
                        {
                            if (this.animal.def.defName == "Megascarab")
                            {
                                this.animalKind = "MegascarabDomestic";
                            }
                            else
                            {
                                if (this.animal.def.defName == "Iguana")
                                {
                                    this.animalKind = "IguanaDomestic";
                                }
                                else
                                {
                                    if (this.animal.def.defName == "Cobra")
                                    {
                                        this.animalKind = "CobraDomestic";
                                    }
                                    else
                                    {
                                        if (this.animal.def.defName == "Dromedary")
                                        {
                                            this.animalKind = "DromedaryDomestic";
                                        }
                                        else
                                        {
                                            if (this.animal.def.defName == "Monkey")
                                            {
                                                this.animalKind = "MonkeyDomestic";
                                            }
                                            else
                                            {
                                                if (this.animal.def.defName == "Rhinoceros")
                                                {
                                                    this.animalKind = "RhinocerosDomestic";
                                                }
                                                else
                                                {
                                                    if (this.animal.def.defName == "Tortoise")
                                                    {
                                                        this.animalKind = "TortoiseDomestic";
                                                    }
                                                    else
                                                    {
                                                        if (this.animal.def.defName == "WildBoar")
                                                        {
                                                            this.animalKind = "BoarDomestic";
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            int num = UnityEngine.Random.Range(0, 100);
            int level = this.pawn.skills.GetSkill(SkillDefOf.Social).level;
            float num2 = (float)(level * 2);
            float num3 = 1000 / (float)level;
            float num4 = 500 / (float)level;
            if ((float)num <= num2)
            {
                this.pawn.skills.Learn(SkillDefOf.Social, num3);
                Pawn pawn = PawnGenerator.GeneratePawn(PawnKindDef.Named(this.animalKind ?? ""), null);
                pawn.gender = this.animal.gender;
                IntVec3 position = this.animal.Position;
                GenSpawn.Spawn(pawn, position);
                this.d_animal = (pawn as FarmAnimal);
                this.d_animal.Master(this.pawn.Name.nick ?? "");
                this.d_animal.inventory.container.TryAdd(ThingMaker.MakeThing(ThingDefOf.DoorKey, null));
                this.animal.Destroy(0);
                string text = this.pawn.Name.nick + " has successfully captured a " + this.animal.def.defName + "!";
                Find.History.AddGameEvent(text, 0, true, this.pawn, string.Empty);
                return;
            }
            this.pawn.skills.Learn(SkillDefOf.Social, num4);
            int num5 = UnityEngine.Random.Range(0, 100);
            if (num5 >= 95)
            {
                this.pawn.TakeDamage(new DamageInfo(DamageDefOf.Blunt, 7, null, null, null));
                Messages.Message(this.pawn.Name.nick + " got hit by the " + this.animal.def.label + ".");
                this.animal.jobs.EndCurrentJob(0);
                return;
            }
            Messages.Message("Failed to capture " + this.animal.def.defName + ". ");
            this.animal.jobs.EndCurrentJob(0);
        }
    }
}
