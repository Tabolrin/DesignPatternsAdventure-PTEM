using UnityEngine;

public class FreezePotion : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(PLAYER_TAG))
        {
            Collect();
        }
    }

    [ContextMenu("Collect")]
    public void Collect()
    {
        GameManager.Instance.EnemiesFreezeStatus = true;
        Destroy(gameObject);
    }
}