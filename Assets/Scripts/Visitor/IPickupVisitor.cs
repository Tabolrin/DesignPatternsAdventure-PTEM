using UnityEngine;

public interface IPickupVisitor
{
    void Visit(SpeedPotion speedPot);
    void Visit(ScoringObject scoreObj);
    void Visit(KillerPotion killerPot);
    void Visit(FreezePotion freezePot);
}
