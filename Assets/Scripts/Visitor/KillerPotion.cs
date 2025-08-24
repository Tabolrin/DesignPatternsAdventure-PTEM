using UnityEngine;

public class KillerPotion : Pickup
{
    public override void Collect(IPickupVisitor visitor)
    {
        visitor.Visit(this);
    }
}
