using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BlackScreen : MonoBehaviour
{
    public float speed = 1f;
    public Image maskImage;

    private IEnumerator coroutine;

    public void Start()
    {
        coroutine = FadeOutCoroutine();
        StartCoroutine(coroutine);
    }

    private IEnumerator FadeInCoroutine(bool followedByFadeOut)
    {
        float t = 0f;
        Color c = maskImage.color;
        while (t <= 1f)
        {
            t += Time.deltaTime * speed;
            c.a = Mathf.Clamp01(t);
            maskImage.color = c;
            yield return null;
        }
        if (followedByFadeOut)
        {
            coroutine = FadeOutCoroutine();
            StartCoroutine(coroutine);
        }
    }

    private IEnumerator FadeOutCoroutine()
    {
        float t = 0f;
        Color c = maskImage.color;
        while (t <= 1f)
        {
            t += Time.deltaTime * speed;
            c.a = 1f - Mathf.Clamp01(t);
            maskImage.color = c;
            yield return null;
        }
    }

    public void FadeIn()
    {
        coroutine = FadeInCoroutine(false);
        StartCoroutine(coroutine);
    }

    public void FadeOut()
    {
        coroutine = FadeOutCoroutine();
        StartCoroutine(coroutine);
    }

    public void Ellipse()
    {
        coroutine = FadeInCoroutine(true);
        StartCoroutine(coroutine);
    }
}