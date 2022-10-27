using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;

namespace Smart_Colony
{
	public class Smart_Colony : Verse.Mod
	{
		public static SmartColonySettings Settings;

		public Smart_Colony(ModContentPack content) : base(content)
		{
			Log.Message("Hello world from Smart Colony");

#if DEBUG
			Harmony.DEBUG = true;
#endif

			var harmony = new Harmony("Taggerung.rimworld.Smart_Colony.main");
			harmony.PatchAll();
			foreach (var td in DefDatabase<ThingDef>.AllDefsListForReading)
			{
				if (td.thingClass != null && (td.thingClass == typeof(Building_Turret) || td.thingClass.IsSubclassOf(typeof(Building_Turret))))
			{
				//Faghot
				CompProperties cp = new CompProperties();
				cp.compClass = typeof(SmartThings.Turrets.CompSmartTurret);
				td.comps.Add(cp);

			}
			}
			Settings = GetSettings<SmartColonySettings>();
		}

		public override void DoSettingsWindowContents(Rect inRect)
		{
			base.DoSettingsWindowContents(inRect);
			Settings.DoWindowContents(inRect);
		}

		public override string SettingsCategory()
		{
			return "Smart Colony";
		}
	}
}
