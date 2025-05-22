using System.Collections.Generic;
using CombatExtended;
using RimWorld;
using Verse;
using UnityEngine;

namespace HFWeaponSeries
{
    public class CompOvercharge : CompRangedGizmoGiver
    {
        public float currentHeat;
        public int ticksToCooldown;
        
        public CompProperties_Overcharge Props => (CompProperties_Overcharge) props;
        public float CurrentHeatPercentage => currentHeat / Props.maxHeat;
        public float CurrentDamageMulti => Mathf.Lerp(1, Props.maxDamageMulti, CurrentHeatPercentage);

        public override IEnumerable<Gizmo> CompGetGizmosExtra()
        {
            foreach (Gizmo item in base.CompGetGizmosExtra())
            {
                yield return item;
            }
            yield return new Gizmo_OverchargeStatus{comp = this};
        }

        public void TryAddHeat(float heatToAdd)
        {
            currentHeat = Mathf.Clamp(currentHeat + heatToAdd, 0, Props.maxHeat);
            ticksToCooldown = Props.ticksToCooldown;
        }

        public override void CompTick()
        {
            base.CompTick();
            ticksToCooldown--;
            if (ticksToCooldown <= 0)
            {
                currentHeat = Mathf.Clamp( currentHeat - Props.cooldownRate, 0, Props.maxHeat);
            }
        }
    }
}