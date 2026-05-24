using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneFader : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 2f;
    public AudioSource musicSource;

    public void FadeToScene(string sceneName)
    {
        StartCoroutine(FadeAndLoad(sceneName));
    }

    IEnumerator FadeAndLoad(string sceneName)
    {
        float t = 0f;
        Color color = fadeImage.color;

        float startVolume = musicSource.volume;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float progress = t / fadeDuration;


            color.a = progress;
            fadeImage.color = color;


            musicSource.volume = Mathf.Lerp(startVolume, 0f, progress);

            yield return null;
        }

        color.a = 1f;
        fadeImage.color = color;
        musicSource.volume = 0f;

        yield return new WaitForEndOfFrame();

        SceneManager.LoadScene(sceneName);
    }
}