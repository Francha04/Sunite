using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endGame : MonoBehaviour
{
    public float videoDuration;
    public SceneHandler sceneManager;
    void Start()
    {
        Time.timeScale = 1f;
        StartCoroutine("goToCredits");
    }

    IEnumerator goToCredits()
    {
        yield return new WaitForSeconds(videoDuration);
        sceneManager.LoadCredits();
    }
}
