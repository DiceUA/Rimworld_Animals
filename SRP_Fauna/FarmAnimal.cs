﻿using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Verse;
using Verse.AI;

namespace SRP_Fauna
{
	public class FarmAnimal : Pawn
	{
		//
		// Fields
		//
		private string animmaster = "None";

		private JobDef Givebirth = DefDatabase<JobDef>.GetNamed ("giveBirth", true);

		private int breedingUrgeTime = UnityEngine.Random.Range (10000, 20000);

		private int PregnancyTime = -1;

		private JobDef called = DefDatabase<JobDef>.GetNamed ("FollowMaster", true);

		private JobDef mate = DefDatabase<JobDef>.GetNamed ("Mate", true);

		private Pawn Tamer;

		private bool reserved;

		private bool hasMaster = true;

		private bool follow = true;

		private int callTime = 200;

        private Animal animal;

		//
		// Methods
		//
		private void Birth ()
		{
			if (this.PregnancyTime > 0) {
				this.PregnancyTime--;
			}
			if (this.PregnancyTime == 0) {
				this.jobs.StopAll (false);
				Job job = new Job (this.Givebirth, null);
				this.jobs.StartJob (job);
				this.PregnancyTime = -1;
			}
		}

		private void Breed ()
		{
			if (this.gender == Gender.Male) {
				if (this.breedingUrgeTime > 0) {
					this.breedingUrgeTime--;
				}
				if (this.breedingUrgeTime == 0) {
					FarmAnimal farmAnimal;
					if (Verse.GenCollection.TryRandomElement<FarmAnimal> (from mf in Find.ListerPawns.AllPawns.OfType<FarmAnimal> ()
					where mf.gender == Gender.Female && mf.def.defName == this.def.defName && !mf.isPregnant () && !mf.isReserved ()
					select mf, out farmAnimal)) {
						farmAnimal.jobs.StopAll (false);
						farmAnimal.jobs.StartJob (new Job (JobDefOf.Wait));
						this.jobs.StopAll (false);
						Job job = new Job (this.mate, new TargetInfo (farmAnimal));
						this.jobs.StartJob (job);
					}
					this.breedingUrgeTime = UnityEngine.Random.Range (10000, 20000);
				}
			}
		}

		public override void ExposeData ()
		{
			base.ExposeData ();
			Scribe_Values.LookValue<int> (ref this.breedingUrgeTime, "breedingUrgeTime", 0, false);
			Scribe_Values.LookValue<int> (ref this.PregnancyTime, "pregnancyTime", 0, false);
			Scribe_Values.LookValue<bool> (ref this.reserved, "Reserved", false, false);
			Scribe_Values.LookValue<string> (ref this.animmaster, "AnimalMaster", null, false);
			Scribe_Values.LookValue<bool> (ref this.follow, "FollowMaster", false, false);
			Scribe_Values.LookValue<bool> (ref this.hasMaster, "Hasmaster", false, false);
		}

		public void Follow ()
		{
			if (this.follow) {
				if (this.callTime > 0) {
					this.callTime--;
				}
				if (this.callTime == 0) {
					if (GenCollection.TryRandomElement<Pawn> (from col in Find.ListerPawns.FreeColonists
					where col.IsColonist  && col.Name.nick == (this.animmaster ?? "")
					select col, out this.Tamer)) {
						this.jobs.StopAll (false);
						Job job = new Job (this.called, new TargetInfo (this.Tamer));
						this.jobs.StartJob (job);
						this.hasMaster = true;
					}
					else {
						this.Tamer = null;
						this.follow = false;
						this.hasMaster = false;
					}
					this.callTime = 600;
				}
			}
		}

		public override IEnumerable<Gizmo> GetGizmos ()
		{
			if (this.hasMaster) {
				Command_Toggle command_Toggle = new Command_Toggle ();
				command_Toggle.hotKey = KeyBindingDefOf.Misc5;
				command_Toggle.defaultLabel = "Toggle Follow";
				command_Toggle.icon = ContentFinder<Texture2D>.Get ("Buttons/Follow", true);
				command_Toggle.isActive = (() => this.follow);
				command_Toggle.toggleAction = delegate {
					this.follow = !this.follow;
				};
				command_Toggle.groupKey = 61733;
				command_Toggle.tutorHighlightTag = "Toggle Follow Master";
				yield return command_Toggle;
			}
			yield break;
		}

		public override string GetInspectString ()
		{
			string result;
			if (this.isPregnant ()) {
				result = string.Concat (new string[] {
					"Pregnant ",
					"\n",
					"Due In: ",
					GenTime.TickstoDaysString (this.PregnancyTime),
					"\n",
					base.GetInspectString ()
				});
			}
			else {
				result = base.GetInspectString ();
			}
			return result;
		}

		public void Impregnate ()
		{            
			if (this.gender == Gender.Female) 
            {
                animal = new Animal();
                animal.Species = this.def.defName;
                this.PregnancyTime = animal.PregnancyETA; //New code :3
                animal = null;

                //foreach (AnimalsWild animalWild in Enum.GetValues(typeof(AnimalsWild)))
                //{                   
                //    if (this.def.defName == animalWild + "Domestic")
                //    {
                //        this.PregnancyTime = (int)animalWild;
                //        break;
                //    }       
                //}
                


                /* Start of bydlocode
				if (this.def.defName == "MuffaloDomestic") {
					this.PregnancyTime = 300000;
					return;
				}
				if (this.def.defName == "DeerDomestic") {
					this.PregnancyTime = 265000;
					return;
				}
				if (this.def.defName == "SquirrelDomestic") {
					this.PregnancyTime = (int)DomesticAnimals.SquirrelDomestic; //190000
					return;
				}
				if (this.def.defName == "BoomratDomestic") {
					this.PregnancyTime = 210000;
					return;
				}
				if (this.def.defName == "MegascarabDomestic") {
					this.PregnancyTime = 150000;
					return;
				}
				if (this.def.defName == "IguanaDomestic") {
					this.PregnancyTime = 180000; //180000                    
					return;
				}
				if (this.def.defName == "CobraDomestic") {
					this.PregnancyTime = 170000;
					return;
				}
				if (this.def.defName == "DromedaryDomestic") {
					this.PregnancyTime = 295000;
					return;
				}
				if (this.def.defName == "MonkeyDomestic") {
					this.PregnancyTime = 230000;
					return;
				}
				if (this.def.defName == "RhinocerosDomestic") {
					this.PregnancyTime = 320000;
					return;
				}
				if (this.def.defName == "TortoiseDomestic") {
					this.PregnancyTime = 190000;
					return;
				}
				if (this.def.defName == "BoarDomestic") {
					this.PregnancyTime = 270000;
				}//*/// end of bydlocode
			}
		}

		public bool isPregnant ()
		{
			return this.PregnancyTime > 0;
		}

		public bool isReserved ()
		{
			return this.reserved;
		}

		public string Master (string master)
		{
			this.animmaster = master;
			return null;
		}

		public void Reserving (bool reserve)
		{
			this.reserved = reserve;
		}

		public override void SpawnSetup ()
		{
			base.SpawnSetup ();
			if (this.reserved) {
				this.reserved = false;
				this.jobs.EndCurrentJob (0);
			}
		}

		public override void Tick ()
		{
			base.Tick ();
			this.Breed ();
			this.Birth ();
			this.Follow ();
		}
	}
}
