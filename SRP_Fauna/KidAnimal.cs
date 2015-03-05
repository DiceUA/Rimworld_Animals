using RimWorld;
using System;
using Verse;

namespace SRP_Fauna
{
	public class KidAnimal : Pawn
	{
		//
		// Fields
		//
		private bool justBorn = true;

		private int maturityTime;

		//
		// Methods
		//
		public override void ExposeData ()
		{
			base.ExposeData ();
			Scribe_Values.LookValue<bool> (ref this.justBorn, "JustBorn", false, false);
			Scribe_Values.LookValue<int> (ref this.maturityTime, "maturityTime", 0, false);
		}

		public override string GetInspectString ()
		{
			return string.Concat (new string[] {
				"Maturity in: ",
				"",
				GenTime.TickstoDaysString (this.maturityTime),
				"",
				base.GetInspectString ()
			});
		}

		private void Grow ()
		{
			if (this.maturityTime > 0) {
				this.maturityTime--;
			}
			if (this.maturityTime == 0) {
				Pawn pawn = null;
				if (this.def.defName == "MuffaloKid") {
					pawn = PawnGenerator.GeneratePawn (PawnKindDef.Named ("D_Muffalo"), null);
				}
				else {
					if (this.def.defName == "DeerKid") {
						pawn = PawnGenerator.GeneratePawn (PawnKindDef.Named ("D_Deer"), null);
					}
					else {
						if (this.def.defName == "SquirrelKid") {
							pawn = PawnGenerator.GeneratePawn (PawnKindDef.Named ("D_Squirrel"), null);
						}
						else {
							if (this.def.defName == "BoomratKid") {
								pawn = PawnGenerator.GeneratePawn (PawnKindDef.Named ("D_Boomrat"), null);
							}
							else {
								if (this.def.defName == "MegascarabKid") {
									pawn = PawnGenerator.GeneratePawn (PawnKindDef.Named ("D_Megascarab"), null);
								}
								else {
									if (this.def.defName == "IguanaKid") {
										pawn = PawnGenerator.GeneratePawn (PawnKindDef.Named ("D_Iguana"), null);
									}
									else {
										if (this.def.defName == "CobraKid") {
											pawn = PawnGenerator.GeneratePawn (PawnKindDef.Named ("D_Cobra"), null);
										}
										else {
											if (this.def.defName == "DromedaryKid") {
												pawn = PawnGenerator.GeneratePawn (PawnKindDef.Named ("D_Dromedary"), null);
											}
											else {
												if (this.def.defName == "MonkeyKid") {
													pawn = PawnGenerator.GeneratePawn (PawnKindDef.Named ("D_Monkey"), null);
												}
												else {
													if (this.def.defName == "RhinocerosKid") {
														pawn = PawnGenerator.GeneratePawn (PawnKindDef.Named ("D_Rhinoceros"), null);
													}
													else {
														if (this.def.defName == "TortoiseKid") {
															pawn = PawnGenerator.GeneratePawn (PawnKindDef.Named ("D_Tortoise"), null);
														}
														else {
															if (this.def.defName == "BoarKid") {
																pawn = PawnGenerator.GeneratePawn (PawnKindDef.Named ("D_Boar"), null);
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
				pawn.gender = this.gender;
				IntVec3 position = base.Position;
				GenSpawn.Spawn (pawn, position);
				this.Destroy (0);
			}
		}

		public override void Tick ()
		{
			base.Tick ();
			if (this.justBorn) {
				if (this.def.defName == "MuffaloKid") {
					this.maturityTime = 300000;
					this.justBorn = false;
				}
				else {
					if (this.def.defName == "DeerKid") {
						this.maturityTime = 210000;
						this.justBorn = false;
					}
					else {
						if (this.def.defName == "SquirrelKid") {
							this.maturityTime = 120000;
							this.justBorn = false;
						}
						else {
							if (this.def.defName == "BoomratKid") {
								this.maturityTime = 170000;
								this.justBorn = false;
							}
							else {
								if (this.def.defName == "MegascarabKid") {
									this.maturityTime = 340000;
									this.justBorn = false;
								}
								else {
									if (this.def.defName == "IguanaKid") {
										this.maturityTime = 220000;
										this.justBorn = false;
									}
									else {
										if (this.def.defName == "CobraKid") {
											this.maturityTime = 200000;
											this.justBorn = false;
										}
										else {
											if (this.def.defName == "DromedaryKid") {
												this.maturityTime = 265000;
												this.justBorn = false;
											}
											else {
												if (this.def.defName == "MonkeyKid") {
													this.maturityTime = 220000;
													this.justBorn = false;
												}
												else {
													if (this.def.defName == "RhinocerosKid") {
														this.maturityTime = 290000;
														this.justBorn = false;
													}
													else {
														if (this.def.defName == "TortoiseKid") {
															this.maturityTime = 310000;
															this.justBorn = false;
														}
														else {
															if (this.def.defName == "BoarKid") {
																this.maturityTime = 200000;
																this.justBorn = false;
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
			}
			this.Grow ();
		}
	}
}
