using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private  GameObject enemyPrefab;
    [SerializeField] private  BoxCollider2D mapBounds;

    [SerializeField] private  float spawnInterval = 2f;
    [SerializeField] private  float minDistance = 5f;
    [SerializeField] private  float edgePadding = 1f;

    float timer;

    void Update()
    {
        timer -= Time.deltaTime;
        
        if (timer > 0)
            return;
        
        timer = spawnInterval;

        Bounds bounds = mapBounds.bounds;
        Vector2 pos;
        int tries = 10;
        
        do
        {
            pos = new Vector2
            (
                Random.Range(bounds.min.x + edgePadding, bounds.max.x - edgePadding),
                Random.Range(bounds.min.y + edgePadding, bounds.max.y - edgePadding)
            );
        } while (Vector2.Distance(pos, player.position) < minDistance && --tries > 0);

        Instantiate(enemyPrefab, pos, Quaternion.identity);
    }
}