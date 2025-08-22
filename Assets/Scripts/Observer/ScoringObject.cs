using UnityEngine;

public class ScoringObject : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";
    [SerializeField] private int scoreWorth;

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
        ScoreManager.AddScore(scoreWorth);
        Destroy(gameObject);
    }
}
