using Verse;

namespace HFWeaponSeries;

public class TickingWeapon : ThingWithComps
{
    public virtual void EquippedTick()
    {
        if (AllComps != null)
        {
            for (int i = 0; i < AllComps.Count; i++)
            {
                AllComps[i].CompTick();
            }
        }
    }

    public override void Notify_Equipped(Pawn pawn)
    {
        base.Notify_Equipped(pawn);
        pawn.Map?.GetComponent<WeaponTickMapComponent>().RegisterWeapon(this);
    }

    public override void Notify_Unequipped(Pawn pawn)
    {
        base.Notify_Unequipped(pawn);
        pawn.Map?.GetComponent<WeaponTickMapComponent>().DeregisterWeapon(this);
    }
}