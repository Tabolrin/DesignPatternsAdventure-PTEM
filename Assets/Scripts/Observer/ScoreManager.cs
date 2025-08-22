using UnityEngine;
using UnityEngine.Events;

public static class ScoreManager
{
    private const int SCORE_INIT_VALUE = 0;
    private static int score;

    public static UnityAction<int> ScoreChange;
    
    private static float pointsPerSecond = 5f; 
    private static float timer;

    
    public static int GetScore()
    {
        return score;
    }

    
    public static void ResetScore()
    {
        score = SCORE_INIT_VALUE;
        timer = 0f;
        ScoreChange?.Invoke(score);
    }

    
    public static void AddScore(int value)
    {
        score += value;
        ScoreChange?.Invoke(score);
    }

    
    public static void SubtractScore(int value)
    {
        score -= value;
        if (score < SCORE_INIT_VALUE)
            ResetScore();
        else
            ScoreChange?.Invoke(score);
    }
    
    
    public static void Tick(float deltaTime)
    {
        timer += deltaTime * pointsPerSecond;
        if (timer >= 1f)
        {
            int wholePoints = Mathf.FloorToInt(timer);
            timer -= wholePoints;
            AddScore(wholePoints);
        }
    }
}