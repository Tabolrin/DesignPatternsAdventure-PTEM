using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;
    [SerializeField] private BoxCollider2D mapBounds;
    
    [Header("Stats")]
    [SerializeField] private float speedBuffDuration = 4f;
    [SerializeField] private float buffedSpeed = 15f;
    [SerializeField] private float baseSpeed = 5f;
    [SerializeField] private float currentSpeed = 5f;
    
    public bool IsAlive { get; private set; } = true;
    
    private void Update()
    {
        GetInput();
        
        if (rb.linearVelocity.x > 0)
            spriteRenderer.flipX = false;
        else if (rb.linearVelocity.x < 0)
            spriteRenderer.flipX = true;

        ClampToMap();
        animator.SetFloat("Speed", Mathf.Abs(rb.linearVelocity.x));
    }
    
    
    private void GetInput()
    {
        if (!IsAlive) 
            return;
        
        rb.linearVelocity = Vector2.zero;
        
        if(Input.GetKey(KeyCode.W))
            rb.linearVelocity += Vector2.up * currentSpeed;
        
        if(Input.GetKey(KeyCode.S))
            rb.linearVelocity += Vector2.down * currentSpeed;
        
        if(Input.GetKey(KeyCode.A))
            rb.linearVelocity += Vector2.left * currentSpeed;
        
        if(Input.GetKey(KeyCode.D))
            rb.linearVelocity += Vector2.right * currentSpeed;
    }
    
    
    private void ClampToMap()
    {
        if (!mapBounds) return;

        Bounds b = mapBounds.bounds;
        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, b.min.x, b.max.x);
        pos.y = Mathf.Clamp(pos.y, b.min.y, b.max.y);

        transform.position = pos;
    }
    
    
    public void ActivateSpeedBuff()
    {
        currentSpeed = buffedSpeed;
        StartCoroutine(SpeedBuffTimer());
        animator.speed *= 2;
    }
    
    
    private IEnumerator SpeedBuffTimer()
    {
        yield return new WaitForSeconds(speedBuffDuration);
        currentSpeed = baseSpeed;
        animator.speed /= 2;
    }
    
    
    private IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("EndScene");
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (GameManager.Instance.EnemiesKillableStatus)
            {
                Destroy(other.gameObject);
                GameManager.Instance.KilledEnemy();
            }
            else
            {
                IsAlive = false;
                rb.linearVelocity = Vector2.zero;
                StartCoroutine(DeathDelay());
            }
        }
    }
}
