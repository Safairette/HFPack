using Verse;
using HarmonyLib;

namespace HFWeaponSeries;

[StaticConstructorOnStartup]
public class HarmonyInit
{
    static HarmonyInit()
    {
        HarmonyLib.Harmony harmony = new HarmonyLib.Harmony("Safair.HFWeapons");
        harmony.PatchAll();
    }
}