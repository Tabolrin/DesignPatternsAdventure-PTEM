using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] pickupPrefabs; // assign 3
    [SerializeField] private BoxCollider2D mapBounds;

    [SerializeField] private float spawnInterval = 5f;
    [SerializeField] private float edgePadding = 1f;

    private float timer;

    void Update()
    {
        timer -= Time.deltaTime;
        
        if (timer > 0)
            return;
        
        timer = spawnInterval;

        Bounds b = mapBounds.bounds;
        Vector2 pos = new Vector2
        (
            Random.Range(b.min.x + edgePadding, b.max.x - edgePadding),
            Random.Range(b.min.y + edgePadding, b.max.y - edgePadding)
        );

        int i = Random.Range(0, pickupPrefabs.Length);
        Instantiate(pickupPrefabs[i], pos, Quaternion.identity);
    }
}