using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Image = UnityEngine.UI.Image;

public class EndScreenManager : MonoBehaviour
{
    [SerializeField] private Image blackOverlay;
    [SerializeField] private float fadeDuration;
    private void Start()
    {
        blackOverlay.color = Color.black;
        
        blackOverlay.CrossFadeColor
        (
            new Color(0, 0, 0, 0),
            fadeDuration,
            true,
            true
        );
        StartCoroutine(DelayedDestruction());
    }

    public void StartOver()
    {
        SceneManager.LoadScene("GameScene");
    }

    private IEnumerator DelayedDestruction()
    {
        yield return new WaitForSeconds(fadeDuration);
        Destroy(blackOverlay.gameObject);
    }
}
