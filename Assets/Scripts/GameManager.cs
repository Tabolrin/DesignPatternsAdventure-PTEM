using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [field:SerializeField] public Transform PlayerPosition { get; private set; }
    [SerializeField] private int maxKillableEnemiesOnBuff = 3;
    [SerializeField] private int EnemyKillScoreValue = 100;
    [SerializeField] private float pointsPerSecond = 5f;
    private float timer;
    public bool EnemiesKillableStatus { get; set; } = false;
    private int KilledEnemiesCount { get; set; } = 0;
    public bool EnemiesFreezeStatus { get; set; } = false;

    private void Awake()
    {
        //Singleton pattern
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
    }

    private void Start()
    {
        ScoreManager.Instance.ResetScore();
    }

    private void Update()
    {
        Tick(Time.deltaTime);
    }
    public void Tick(float deltaTime)
    {
        timer += deltaTime * pointsPerSecond;
        if (timer >= 1f)
        {
            int wholePoints = Mathf.FloorToInt(timer);
            timer -= wholePoints;
            ScoreManager.Instance.AddScore(wholePoints);
        }
    }

    public void KilledEnemy()
    {
        KilledEnemiesCount++;

        if (KilledEnemiesCount == maxKillableEnemiesOnBuff)
        {
            EnemiesKillableStatus = false;
            KilledEnemiesCount = 0;
        }
        
        ScoreManager.Instance.AddScore(EnemyKillScoreValue);
    }
}
