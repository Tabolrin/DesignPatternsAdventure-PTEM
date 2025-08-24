using UnityEngine;

public interface IPickup
{
    void Collect(IPickupVisitor visitor);
}
