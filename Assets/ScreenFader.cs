using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour
{
    [SerializeField] private float fadeDuration = 2.0f; // How long the fade should take
    private Image fadeImage;

    private void Awake()
    {
        fadeImage = GetComponent<Image>();
    }

    public void StartFade()
    {
        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 1f); // Set alpha to 1
        StartCoroutine(FadeImage());
    }

    private IEnumerator FadeImage()
    {
        float fadeSpeed = 1f / fadeDuration;
        while (fadeImage.color.a > 0)
        {
            Color newColor = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, fadeImage.color.a - (fadeSpeed * Time.deltaTime));
            fadeImage.color = newColor;
            yield return null;
        }
    }
}