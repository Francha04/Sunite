using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class settings : MonoBehaviour
{
    static public bool gameHasStarted = false;
    static public bool hasSound = true;
    static public bool hasVideo = true;
    public GameObject meteors;
    static public FMOD.Studio.EventInstance evtInst;
    public float numPlanets;
    public soundDistance sunPlanetSound;

    // Métodos para leer los estados de los boolean.
    public bool soundStatus()
    {
        return hasSound;
    }
    public bool videoStatus()
    {
        return hasVideo;
    }
    public void Start()
    {
        if (!gameHasStarted) 
        {
            evtInst = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Music");
            evtInst.start();
        }
        evtInst.setVolume(1f);
        gameHasStarted = true;
        if (SceneManager.GetActiveScene().name == "Menu Principal")
        {
            Time.timeScale = 1f; 
            evtInst.setParameterByName("State", 0);
        }
        if (SceneManager.GetActiveScene().name == "Credits")
        {
            evtInst.setParameterByName("State", 0);
        }
        if (SceneManager.GetActiveScene().name == "VictoryCutScene") 
        {
            evtInst.setVolume(0f);
        }
        if (SceneManager.GetActiveScene().buildIndex == 1) 
        {
            numPlanets = 0;
            evtInst.setParameterByName("State", 1);
            evtInst.setParameterByName("Gameplay", 0);

        }
    }
    public void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1) 
        {
            evtInst.setParameterByName("Gameplay", numPlanets + sunPlanetSound.currentDistance);
        }
    }
    public void gameStart() 
    {
        gameHasStarted = true;
        Time.timeScale = 1f;
        evtInst.setVolume(1f);
    }
    // SONIDO
    public void willHaveSound()                 //SÍ.
    {
        hasSound = true;
    }
    public void notHaveSound()                  //NO.
    {
        hasSound = false;
    }
    // VIDEO
    public void willHaveVideo()                 //SÍ.
    {
        hasVideo = true;
    }
    public void notHaveVideo()                  //NO.
    {
        hasVideo = false;
    }

    public void pauseGame()
    {
        Time.timeScale = 0f;
    }
    public void unPauseGame()
    {
        Time.timeScale = 1f;
    }
    public void quitGame()
    {
        Application.Quit();
    }
    public void reloadGame()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        FMODUnity.RuntimeManager.PlayOneShot("event:/Sound/Button UI");
    }

    public void victoryCutscene() 
    {
        StartCoroutine("loadCinematic");
    }

    IEnumerator loadCinematic()
    {
        Destroy(meteors);
        yield return new WaitForSeconds(1.5f);
        evtInst.setParameterByName("State", 2);
        SceneManager.LoadScene("VictoryCutScene");
        evtInst.setVolume(0f);
    }
    //SOUND STUFF
    public void onPlanetGrab() 
    {
        sunPlanetSound.onToNextPlanet();
        numPlanets++;
        Mathf.Clamp(numPlanets, 0f, 6f);
        evtInst.setParameterByName("Gameplay", numPlanets);
        
    }





}



    