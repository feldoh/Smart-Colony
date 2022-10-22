using Verse;

namespace Smart_Colony.SmartThings.Doors
{
	public class CompProperties_SmartDoor : CompProperties
	{
		[NoTranslate] public string CommandLabelKey = "SmartColony_SmartDoorToggleOpen";

		[NoTranslate] public string CommandDescKey = "SmartColony_SmartDoorToggleOpenDescription";

		public CompProperties_SmartDoor() => compClass = typeof (CompSmartDoor);
	}
}