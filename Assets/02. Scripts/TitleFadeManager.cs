using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class TitleFadeManager : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float fadeDuration = 3.0f;
    public float waitTimeAfterFadeIn = 2.0f;

    void Start()
    {

        StartCoroutine(FadeInAndOut());
    }

    private IEnumerator FadeInAndOut()
    {
        // ���̵� ��
        yield return StartCoroutine(FadeIn());

        // 3�� ���
        yield return new WaitForSeconds(waitTimeAfterFadeIn);

        // ���̵� �ƿ�
        yield return StartCoroutine(FadeOut());
    }

    public IEnumerator FadeIn()
    {
        Color originalColor = text.color;
        float elapsedTime = 0.0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            text.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }
    }

    public IEnumerator FadeOut()
    {
        Color originalColor = text.color;
        float elapsedTime = 0.0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(1.0f - (elapsedTime / fadeDuration));
            text.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }
    }
}
