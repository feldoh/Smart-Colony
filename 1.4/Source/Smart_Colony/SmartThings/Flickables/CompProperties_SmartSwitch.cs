using Verse;

namespace Smart_Colony.SmartThings.Flickables
{
	public class CompProperties_SmartSwitch : CompProperties
	{
		[NoTranslate] public string CommandLabelKey = "SmartColony_SmartSwitchToggleOn";

		[NoTranslate] public string CommandDescKey = "SmartColony_SmartSwitchToggleOnDescription";

		public CompProperties_SmartSwitch() => compClass = typeof(CompSmartSwitch);
	}
}