using RimWorld;
using Verse;

namespace Smart_Colony.SmartThings
{
	public class SmartChecker
	{
		public static bool isSmart(Thing thing) => Smart_Colony.Settings.EnableGlobalSmartHub && IsCockneccted(thing);
		public static bool IsCockneccted(Thing AiCore)
		{
		return	AiCore.Map.listerBuildings.ColonistsHaveBuildingWithPowerOn(DefDatabase<ThingDef>.GetNamed("AI_Core_GS"));
		}
	}
}

