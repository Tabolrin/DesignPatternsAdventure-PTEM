using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed = 3.5f;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float unfreezeDelay = 1.5f;
    
    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();
    }
    
    private void MoveToPlayer()
    {
        if (GameManager.Instance.EnemiesFreezeStatus)
        {
            rigidBody.linearVelocity = Vector2.zero;
            StartCoroutine(UnfreezeAfterDelay());
            return;
        }
        
        Transform playerPos = GameManager.Instance.PlayerPosition;
        Vector2 direction = (playerPos.position - transform.position).normalized;

        if (direction.x > 0)
            spriteRenderer.flipX = false;
        else if (direction.x < 0)
            spriteRenderer.flipX = true;
        
        rigidBody.linearVelocity = direction * speed;
    }
    
    private IEnumerator UnfreezeAfterDelay()
    {
        yield return new WaitForSeconds(unfreezeDelay);
        GameManager.Instance.EnemiesFreezeStatus = false;
    }
}
