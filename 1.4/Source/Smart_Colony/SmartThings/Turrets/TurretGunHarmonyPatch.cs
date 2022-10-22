using HarmonyLib;
using RimWorld;

namespace Smart_Colony.SmartThings.Turrets
{
	[HarmonyPatch(typeof(Building_TurretGun), "get_CanSetForcedTarget")]
	public static class CanSetForcedTarget_Patch
	{
		[HarmonyPostfix]
		public static bool AllowSmartTurrets(bool __result, Building_TurretGun __instance)
		{
			return __result || !(__instance.GetComp<CompSmartTurret>()?.UnableToFire() ?? true);
		}
	}
}
