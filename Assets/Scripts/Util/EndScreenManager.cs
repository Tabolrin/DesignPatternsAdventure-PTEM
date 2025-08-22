using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Image = UnityEngine.UI.Image;

public class EndScreenManager : MonoBehaviour
{
    [SerializeField] private Image blackOverlay;
    [SerializeField] private float fadeDuration = 2;

    private void Start()
    {
        blackOverlay.color = Color.black;
        StartCoroutine(FadeOut());
        StartCoroutine(DelayedDestruction());
    }

    public void StartOver()
    {
        SceneManager.LoadScene("GameScene");
    }

    private IEnumerator FadeOut()
    {
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.unscaledDeltaTime; 
            float a = Mathf.Lerp(1f, 0f, t / fadeDuration);
            blackOverlay.color = new Color(0f, 0f, 0f, a);
            yield return null;
        }
        blackOverlay.color = new Color(0f, 0f, 0f, 0f); 
    }

    private IEnumerator DelayedDestruction()
    {
        yield return new WaitForSeconds(fadeDuration);
        Destroy(blackOverlay.gameObject);
    }
}