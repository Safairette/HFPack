using Verse;

namespace HFWeaponSeries
{
    public class CompProperties_Overcharge : CompProperties
    {
        public CompProperties_Overcharge()
        {
            compClass = typeof(CompOvercharge);
        }

        public float maxDamageMulti = 1.5f;
        public float heatGainPerShot = 0.8f;
        public float maxHeat = 50f;
        public float cooldownRate = 0.2f;
        public int ticksToCooldown = 450;
    }
}