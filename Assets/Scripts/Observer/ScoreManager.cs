using UnityEngine;
using UnityEngine.Events;

public static class ScoreManager
{
    private const int SCORE_INIT_VALUE = 0;
    private static int score;
    public static UnityAction<int> ScoreChange;


    public static int GetScore()
    {
        return score;
    }
    public static void ResetScore()
    {
        score = SCORE_INIT_VALUE;
    }
    public static void AddScore(int value)
    {
        score += value;
        ScoreChange?.Invoke(score);
    }
    public static void SubsractScore(int value)
    {
        score -= value;
        if (score < SCORE_INIT_VALUE)
            ResetScore();
        ScoreChange?.Invoke(score);
    }
}
