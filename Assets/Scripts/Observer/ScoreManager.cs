using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour, ISubject
{
    public static ScoreManager Instance { get; private set; }
    private const int SCORE_INIT_VALUE = 0;
    private static int score;
    
    //public static UnityAction<int> ScoreChange;

    List<IObserver> observers = new List<IObserver>();

    void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }
    

    #region Observer Pattern
    public void AddObserver(IObserver observer)
    {
        observers.Add(observer);
    }
    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }
    public void NotifyObservers()
    {
        foreach (IObserver observer in observers)
        {
            observer.UpdateScore(score);
        }
    }
    #endregion
    #region Score things
    public int GetScore()
    {
        return score;
    }
    public void ResetScore()
    {
        score = SCORE_INIT_VALUE;
        NotifyObservers();
    }
    public void AddScore(int value)
    {
        score += value;
        NotifyObservers();
    }
    public void SubtractScore(int value)
    {
        score -= value;
        if (score < SCORE_INIT_VALUE)
            ResetScore();

        NotifyObservers();
    }
    #endregion
}