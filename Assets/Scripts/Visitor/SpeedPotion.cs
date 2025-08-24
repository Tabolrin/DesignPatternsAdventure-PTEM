using UnityEngine;

public class SpeedPotion : Pickup
{

    public override void Collect(IPickupVisitor visitor)
    {
        visitor.Visit(this);
    }
}
