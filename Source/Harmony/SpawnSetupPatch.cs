using HarmonyLib;
using Verse;

namespace HFWeaponSeries;

[HarmonyPatch(typeof(Pawn), nameof(Pawn.SpawnSetup))]
public class SpawnSetupPatch
{
    public static void Postfix(Pawn __instance, Map map)
    {
        if (__instance.equipment?.Primary is TickingWeapon weapon)
        {
            map?.GetComponent<WeaponTickMapComponent>().RegisterWeapon(weapon);
        }
    }
}