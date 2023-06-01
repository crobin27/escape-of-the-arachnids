using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour
{
    [SerializeField] private float fadeDuration = 2.0f;
    [SerializeField] private float initialAlpha = 1f;
    private Image fadeImage;

    private void Awake()
    {
        fadeImage = GetComponent<Image>();
    }

    public void StartFade()
    {
        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, initialAlpha);
        StartCoroutine(FadeImage());
    }

    private IEnumerator FadeImage()
    {
        float alphaFadeSpeed = 1f / fadeDuration;
        while (fadeImage.color.a > 0)
        {
            Color newColor = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, fadeImage.color.a - (alphaFadeSpeed * Time.deltaTime));
            fadeImage.color = newColor;
            yield return null;
        }
    }
}
