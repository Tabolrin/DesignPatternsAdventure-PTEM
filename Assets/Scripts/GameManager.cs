using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [field:SerializeField] public Transform PlayerPosition { get; private set; }
    [SerializeField] private int maxKillableEnemiesOnBuff = 3;
    [SerializeField] private int EnemyKillScoreValue = 100;

    public bool EnemiesKillableStatus { get; set; } = false;
    private int KilledEnemiesCount { get; set; } = 0;
    public bool EnemiesFreezeStatus { get; set; } = false;

    private void Awake()
    {
        //Singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        
        Instance = this;
        
        ScoreManager.ResetScore();
    }

    private void Update()
    {
        ScoreManager.Tick(Time.deltaTime);
    }

    public void KilledEnemy()
    {
        KilledEnemiesCount++;

        if (KilledEnemiesCount == maxKillableEnemiesOnBuff)
        {
            EnemiesKillableStatus = false;
            KilledEnemiesCount = 0;
        }
        
        ScoreManager.AddScore(EnemyKillScoreValue);
    }
}
