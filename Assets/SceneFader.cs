using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{

    public Image img;

    public AnimationCurve curve;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    // Fade In = Ecran noir vers scene (disparition de l'�cran noir)
    IEnumerator FadeIn()
    {
        float t = 1f;

        while (t > 0f)
        {
            t -= Time.deltaTime;
            float a = curve.Evaluate(t);
            yield return 0;
        }
    }

    // Fade Out = Scene vers �cran noir (apparition de l'�cran noir)
    IEnumerator FadeOut(string scene)
    {
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime;
            float a = curve.Evaluate(t);
            yield return 0;
        }

        // le code ci-dessous ne se lit que lorsque le fondu est termin�
        SceneManager.LoadScene(scene);
    }

}