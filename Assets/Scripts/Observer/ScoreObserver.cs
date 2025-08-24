using TMPro;
using UnityEngine;

public class ScoreObserver : MonoBehaviour, IObserver
{
    [SerializeField] TextMeshProUGUI uiText;
    [SerializeField] string textFormat;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ScoreManager.Instance.AddObserver(this);
        UpdateScore(ScoreManager.Instance.GetScore());
    }
    void OnDestroy()
    {
        ScoreManager.Instance.RemoveObserver(this);
    }

    public void UpdateScore(int score)
    {
        uiText.text = textFormat + score.ToString("N0"); //N0: adds ',' after every 3 digits, 123456789 becomes 123,456,789.
    }
}
