using UnityEngine;

public class ScoringObject : Pickup
{
    [field: SerializeField] public int scoreWorth { get; private set; }
    public override void Collect(IPickupVisitor visitor)
    {
        visitor.Visit(this);
    }
}
