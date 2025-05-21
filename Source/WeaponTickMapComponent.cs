using System.Collections.Generic;
using Verse;

namespace HFWeaponSeries;

public class WeaponTickMapComponent : MapComponent
{
    public List<TickingWeapon> tickingWeapons = new List<TickingWeapon>();
    
    public WeaponTickMapComponent(Map map) : base(map)
    {
    }

    public override void MapComponentTick()
    {
        foreach (var item in tickingWeapons)
        {
            item.EquippedTick();
        }
    }

    public override void FinalizeInit()
    {
        base.FinalizeInit();
        tickingWeapons.Clear();
        foreach (Pawn pawn in map.mapPawns.AllPawnsSpawned)
        {
            if (pawn.equipment?.Primary is TickingWeapon weapon)
            {
                tickingWeapons.Add(weapon);
            }
        }
    }

    public void RegisterWeapon(TickingWeapon weapon)
    {
        tickingWeapons.Add(weapon);
    }

    public void DeregisterWeapon(TickingWeapon weapon)
    {
        tickingWeapons.Remove(weapon);
    }
}