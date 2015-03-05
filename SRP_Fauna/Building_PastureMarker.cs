using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Verse;
using Verse.AI;

namespace SRP_Fauna
{
	public class Building_PastureMarker : Building
	{
		//
		// Static Fields
		//
		private static readonly Texture2D ButtonIconInfo = ContentFinder<Texture2D>.Get ("Buttons/Switch", true);

		private static readonly Texture2D ButtonIconCall = ContentFinder<Texture2D>.Get ("Buttons/Follow", true);

		//
		// Fields
		//
		private JobDef called = DefDatabase<JobDef>.GetNamed ("FollowMaster", true);

		private int halfTime = 10000;

		private int choice;

		private string animalParent;

		private string animalKid;

		//
		// Methods
		//
		private void CallAnimals ()
		{
			if (this.choice == 0) {
				List<Pawn> list = (from p in Find.ListerPawns.AllPawns
				where p.def.defName == "D_Boomrat" || p.def.defName == "D_Cobra" || p.def.defName == "D_Deer" || p.def.defName == "D_Dromedary" || p.def.defName == "D_Iguana" || p.def.defName == "D_Megascarab" || p.def.defName == "D_Monkey" || p.def.defName == "D_Muffalo" || p.def.defName == "D_Rhinoceros" || p.def.defName == "D_Squirrel" || p.def.defName == "D_Tortoise" || p.def.defName == "D_Boar"
				select p).ToList<Pawn> ();
				List<Pawn> list2 = (from p in Find.ListerPawns.AllPawns
				where p.def.defName == "BoomratKid" || p.def.defName == "CobraKid" || p.def.defName == "DeerKid" || p.def.defName == "DromedaryKid" || p.def.defName == "IguanaKid" || p.def.defName == "MegascarabKid" || p.def.defName == "MonkeyKid" || p.def.defName == "MuffaloKid" || p.def.defName == "RhinocerosKid" || p.def.defName == "SquirrelKid" || p.def.defName == "TortoiseKid" || p.def.defName == "BoarKid"
				select p).ToList<Pawn> ();
				foreach (Pawn current in GenCollection.InRandomOrder<Pawn> (list)) {
					if (!this.isKilled (current)) {
						current.jobs.StopAll (false);
						Job job = new Job (this.called, new TargetInfo (this));
						current.jobs.StartJob (job);
					}
				}
				foreach (Pawn current2 in GenCollection.InRandomOrder<Pawn> (list2)) {
					if (!this.isKilled (current2)) {
						current2.jobs.StopAll (false);
						Job job2 = new Job (this.called, new TargetInfo (this));
						current2.jobs.StartJob (job2);
					}
				}
				Messages.Message ("Calling all Domesticated Animals to the marker.");
				return;
			}
			List<Pawn> list3 = (from p in Find.ListerPawns.AllPawns
			where p.def.defName == (this.animalParent ?? "")
			select p).ToList<Pawn> ();
			List<Pawn> list4 = (from p in Find.ListerPawns.AllPawns
			where p.def.defName == (this.animalKid ?? "")
			select p).ToList<Pawn> ();
			foreach (Pawn current3 in GenCollection.InRandomOrder<Pawn> (list3)) {
				if (!this.isKilled (current3)) {
					current3.jobs.StopAll (false);
					Job job3 = new Job (this.called, new TargetInfo (this));
					current3.jobs.StartJob (job3);
				}
			}
			foreach (Pawn current4 in GenCollection.InRandomOrder<Pawn> (list4)) {
				if (!this.isKilled (current4)) {
					current4.jobs.StopAll (false);
					Job job4 = new Job (this.called, new TargetInfo (this));
					current4.jobs.StartJob (job4);
				}
			}
			int startIndex = this.animalKid.Count<char> () - 3;
			Messages.Message ("Calling all Domesticated " + this.animalKid.Remove (startIndex, 3) + "s to the marker.");
		}

		public override void ExposeData ()
		{
			base.ExposeData ();
			Scribe_Values.LookValue<int> (ref this.halfTime, "Time", 0, false);
			Scribe_Values.LookValue<int> (ref this.choice, "Choice", 0, false);
			Scribe_Values.LookValue<string> (ref this.animalParent, "Parent", null, false);
			Scribe_Values.LookValue<string> (ref this.animalKid, "Kid", null, false);
		}

		public override IEnumerable<Gizmo> GetGizmos ()
		{
			IList<Gizmo> list = new List<Gizmo> ();
			list.Add (new Command_Action {
				icon = Building_PastureMarker.ButtonIconInfo,
				defaultLabel = "Switch Animal",
				defaultDesc = "Switch animal that Pastures here",
				hotKey = KeyBindingDefOf.Misc2,
				activateSound = SoundDef.Named ("Click"),
				action = new Action (this.switchAnimal),
				disabled = false,
				groupKey = 125691
			});
			list.Add (new Command_Action {
				icon = Building_PastureMarker.ButtonIconCall,
				defaultLabel = "Call assigned Animals",
				defaultDesc = "Calls the assigned animal to the Pasture",
				hotKey = KeyBindingDefOf.Misc4,
				activateSound = SoundDef.Named ("Click"),
				action = new Action (this.CallAnimals),
				disabled = false,
				groupKey = 125692
			});
			IEnumerable<Gizmo> commands = base.GetGizmos ();
			IEnumerable<Gizmo> result;
			if (commands != null) {
				result = list.AsEnumerable<Gizmo> ().Concat (commands);
			}
			else {
				result = list.AsEnumerable<Gizmo> ();
			}
			return result;
		}

		public override string GetInspectString ()
		{
			string result;
			if (this.choice == 0) {
				result = string.Concat (new string[] {
					"Assigned Animal Kind",
					": ",
					"",
					"All Animals",
					"",
					base.GetInspectString ()
				});
			}
			else {
				int startIndex = this.animalKid.Count<char> () - 3;
				result = string.Concat (new string[] {
					"Assigned Animal Kind",
					": ",
					"",
					this.animalKid.Remove (startIndex, 3),
					"",
					base.GetInspectString ()
				});
			}
			return result;
		}

		private bool isKilled (Pawn pawn)
		{
			return pawn.Destroyed || pawn.Downed || pawn.Health <= 0;
		}

		private void switchAnimal ()
		{
			this.choice++;
			if (this.choice > 12) {
				this.choice = 0;
			}
			if (this.choice == 1) {
				this.animalParent = "D_Boomrat";
				this.animalKid = "BoomratKid";
				return;
			}
			if (this.choice == 2) {
				this.animalParent = "D_Cobra";
				this.animalKid = "CobraKid";
				return;
			}
			if (this.choice == 3) {
				this.animalParent = "D_Deer";
				this.animalKid = "DeerKid";
				return;
			}
			if (this.choice == 4) {
				this.animalParent = "D_Dromedary";
				this.animalKid = "DromedaryKid";
				return;
			}
			if (this.choice == 5) {
				this.animalParent = "D_Iguana";
				this.animalKid = "IguanaKid";
				return;
			}
			if (this.choice == 6) {
				this.animalParent = "D_Megascarab";
				this.animalKid = "MegascarabKid";
				return;
			}
			if (this.choice == 7) {
				this.animalParent = "D_Monkey";
				this.animalKid = "MonkeyKid";
				return;
			}
			if (this.choice == 8) {
				this.animalParent = "D_Muffalo";
				this.animalKid = "MuffaloKid";
				return;
			}
			if (this.choice == 9) {
				this.animalParent = "D_Rhinoceros";
				this.animalKid = "RhinocerosKid";
				return;
			}
			if (this.choice == 10) {
				this.animalParent = "D_Squirrel";
				this.animalKid = "SquirrelKid";
				return;
			}
			if (this.choice == 11) {
				this.animalParent = "D_Tortoise";
				this.animalKid = "TortoiseKid";
				return;
			}
			if (this.choice == 12) {
				this.animalParent = "D_Boar";
				this.animalKid = "BoarKid";
			}
		}

		public override void Tick ()
		{
			if (this.halfTime > 0) {
				this.halfTime--;
			}
			if (this.halfTime == 0) {
				this.CallAnimals ();
				this.halfTime = 10000;
			}
		}
	}
}
