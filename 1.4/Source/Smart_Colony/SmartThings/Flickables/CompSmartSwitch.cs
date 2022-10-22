using System.Collections.Generic;
using RimWorld;
using Verse;

namespace Smart_Colony.SmartThings.Flickables
{
	public class CompSmartSwitch : ThingComp
	{
		private CompFlickable _compFlickable;
		private CompPowerTrader _compPowerTrader;
		private CompPower _compPower;

		private CompProperties_SmartSwitch Props => (CompProperties_SmartSwitch)props;

		public override void PostSpawnSetup(bool respawningAfterLoad)
		{
			_compFlickable = parent.GetComp<CompFlickable>();
			_compPowerTrader = parent.GetComp<CompPowerTrader>();
			if (_compPowerTrader == null)
			{
				_compPower = parent.AllComps.Find(p => p.props is CompProperties_Power) as CompPower;
			}
		}

		public override IEnumerable<Gizmo> CompGetGizmosExtra()
		{
			if (parent.Faction != Faction.OfPlayer ||
			    _compFlickable == null ||
			    !SmartChecker.isSmart(parent) ||
			    IsUnpowered())
			{
				yield break;
			}

			var extra = new Command_Action
			{
				icon = TexCommand.DesirePower,
				defaultLabel = Props.CommandLabelKey.Translate(),
				defaultDesc = Props.CommandDescKey.Translate(),
				action = () => _compFlickable.DoFlick()
			};

			yield return extra;
		}

		private bool IsUnpowered() => (_compPowerTrader == null && _compPower == null) ||
		                              (_compFlickable.SwitchIsOn && (!_compPowerTrader?.PowerOn ?? false) &&
		                               !(_compPower?.TransmitsPowerNow ?? false)) ||
		                              parent.IsBrokenDown();
	}
}
