using CombatExtended;
using RimWorld;
using Verse;

namespace HFWeaponSeries
{
    public class OverchargedBulletCE : BulletCE
    {
        public override float DamageAmount
        {
            get
            {
                if (this.damageAmount == null)
                {
                    // Apply a multiplier to bullet damage based on the quality of the weapon that fired it
                    var weaponDamageMultiplier = equipment?.GetStatValue(StatDefOf.RangedWeapon_DamageMultiplier) ?? 1f;
                    this.damageAmount = def.projectile.GetDamageAmount(weaponDamageMultiplier);
                }

                CompOvercharge comp = equipment.TryGetComp<CompOvercharge>();
                if (comp != null)
                {
                    this.damageAmount *= comp.CurrentDamageMulti;
                }

                return (float)this.damageAmount;
            }
        }
    }
}