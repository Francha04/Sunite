using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backToMenu : MonoBehaviour
{
    public float creditsDuration;
    public SceneHandler sceneManager;
    void Start()
    {
        StartCoroutine("openMenu");
    }

    IEnumerator openMenu()
    {
        yield return new WaitForSeconds(creditsDuration);
        sceneManager.LoadMenu();
    }
}
