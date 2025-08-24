using UnityEngine;

public class FreezePotion : Pickup
{
    public override void Collect(IPickupVisitor visitor)
    {
        visitor.Visit(this);
    }
}