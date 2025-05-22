using HarmonyLib;
using Verse;

namespace HFWeaponSeries;

[HarmonyPatch(typeof(Pawn), nameof(Pawn.DeSpawn))]
public class PreDespawnPatch
{
    public static void Prefix(Pawn __instance)
    {
        if (__instance.equipment?.Primary is TickingWeapon weapon)
        {
            __instance.Map?.GetComponent<WeaponTickMapComponent>().DeregisterWeapon(weapon);
        }
    }
}