using System.Collections.Generic;
using HarmonyLib;
using RimWorld;
using Verse;

namespace Smart_Colony.SmartThings.Doors
{
	public class CompSmartDoor : ThingComp
	{
		private Building_Door _doorRef;
		private Traverse _holdOpenStateField;
		
		private CompProperties_SmartDoor Props => (CompProperties_SmartDoor) props;

		public override void PostSpawnSetup(bool respawningAfterLoad)
		{
			_doorRef = parent as Building_Door;
			_holdOpenStateField = Traverse.Create(_doorRef).Field("holdOpenInt");
		}

		private void toggleDoorState()
		{
			if (_doorRef.HoldOpen)
			{
				_holdOpenStateField.SetValue(false);
				_doorRef.StartManualCloseBy(null);
			}
			else
			{
				_holdOpenStateField.SetValue(true);
				_doorRef.StartManualOpenBy(null);
			}
		}

		public override IEnumerable<Gizmo> CompGetGizmosExtra()
		{
			if (!SmartChecker.isSmart(_doorRef) || !_doorRef.DoorPowerOn || parent.IsBrokenDown() || _doorRef.Faction != Faction.OfPlayer)
			{
				yield break;
			}

			var extra = new Command_Action
			{
				icon = TexCommand.HoldOpen,
				defaultLabel = Props.CommandLabelKey.Translate(),
				defaultDesc = Props.CommandDescKey.Translate(),
				action = toggleDoorState
			};

			yield return extra;
		}
	}
}
