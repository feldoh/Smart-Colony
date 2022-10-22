using Verse;

namespace Smart_Colony.SmartThings
{
	public class SmartChecker
	{
		public static bool isSmart(Thing thing) => Smart_Colony.Settings.EnableGlobalSmartHub;
	}
}
