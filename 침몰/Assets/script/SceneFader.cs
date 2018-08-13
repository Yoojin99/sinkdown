using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneFader : MonoBehaviour {

    public Image img;

    void Start()
    {
        StartCoroutine(FadeIn());
    }
    IEnumerator FadeIn() {

        float t = 1f;

        while (t > 0f) {
            t -= Time.deltaTime;
            img.color = new Color(0f, 0f, 0f, t);
            yield return 0;
        }
    }

    IEnumerator FadeOut(string scene)
    {

        float t = 1f;

        while (t < 1f)
        {
            t += Time.deltaTime;
            img.color = new Color(0f, 0f, 0f, t);
            yield return 0;
        }

        SceneManager.LoadScene(scene);
    }

    public void FadeTo(string scene) {
        StartCoroutine(FadeOut(scene));
    }
}
