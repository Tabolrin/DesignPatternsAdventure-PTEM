using UnityEngine;

public class SpeedPotion : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(PLAYER_TAG))
        {
            Collect(collision.gameObject.GetComponent<PlayerController>());
        }
    }

    [ContextMenu("Collect")]
    public void Collect(PlayerController playerController)
    {
        playerController.ActivateSpeedBuff();
        Destroy(gameObject);
    }
}
