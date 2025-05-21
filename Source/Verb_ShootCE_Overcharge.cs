using CombatExtended;
using Verse;

namespace HFWeaponSeries;

public class Verb_ShootCE_Overcharge : Verb_ShootCE
{
    private CompOvercharge heatComp = null;

    public virtual CompOvercharge HeatComp
    {
        get
        {
            if (heatComp == null && EquipmentSource != null)
            {
                heatComp = EquipmentSource.TryGetComp<CompOvercharge>();
            }
            return heatComp;
        }
    }

    public override void WarmupComplete()
    {
        base.WarmupComplete();
        HeatComp?.TryAddHeat(HeatComp.Props.heatGainPerShot);
    }
}