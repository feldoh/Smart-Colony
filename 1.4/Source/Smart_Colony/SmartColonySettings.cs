using UnityEngine;
using Verse;

namespace Smart_Colony
{
	public class SmartColonySettings : ModSettings
	{
		private const float RowHeight = 22f;

		private readonly Listing_Standard _options = new();

		public bool EnableGlobalSmartHub;

		public void DoWindowContents(Rect wrect)
		{
			_options.Begin(wrect);

			_options.CheckboxLabeled("SmartColony_GlobalSmartHubSetting".Translate(), ref EnableGlobalSmartHub);

			_options.End();
		}

		public override void ExposeData()
		{
			Scribe_Values.Look(ref EnableGlobalSmartHub, "EnableGlobalSmartHub", false);
		}
	}
}
