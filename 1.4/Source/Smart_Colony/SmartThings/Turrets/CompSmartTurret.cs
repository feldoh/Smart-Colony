using System.Collections.Generic;
using RimWorld;
using Verse;

namespace Smart_Colony.SmartThings.Turrets
{
	public class CompSmartTurret : ThingComp
	{
		private Building_Turret _turretRef;
		private CompPowerTrader _compPowerTrader;

		private CompProperties_SmartTurret Props => (CompProperties_SmartTurret)props;

		public override void PostSpawnSetup(bool respawningAfterLoad)
		{
			_turretRef = parent as Building_Turret;
			_compPowerTrader = parent.GetComp<CompPowerTrader>();
		}

		public bool UnableToFire() => parent.Faction != Faction.OfPlayer ||
		                                    _turretRef == null ||
		                                    !SmartChecker.isSmart(parent) ||
		                                    !(_turretRef.PowerComp.TransmitsPowerNow ||
		                                      (_compPowerTrader?.PowerOn ?? false));
		
	}
}
