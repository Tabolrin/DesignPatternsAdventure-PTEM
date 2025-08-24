using UnityEngine;

public abstract class Pickup : MonoBehaviour, IPickup
{
    private const string PLAYER_TAG = "Player";
    public abstract void Collect(IPickupVisitor visitor);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(PLAYER_TAG))
        {
            PlayerController playerController = collision.GetComponent<PlayerController>();
            Collect(playerController);
            Destroy(gameObject);
        }
    }
}
