using TMPro;
using UnityEngine;

public class ScoreObserver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI uiText;
    [SerializeField] string textFormat;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ScoreManager.ScoreChange += OnScoreChange;
        OnScoreChange(ScoreManager.GetScore());
    }

    private void OnScoreChange(int score)
    {
        uiText.text = textFormat + score.ToString("N0"); //N0: adds ',' after every 3 digits, 123456789 becomes 123,456,789.
    }
}
