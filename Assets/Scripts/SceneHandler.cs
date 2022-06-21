using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public settings settingsScript;           // El script que contiene los boolean de hasVideo y hasSound.
    public void LoadNextScene()               // Carga la siguiente escena.
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex + 1);
    }

    public void LoadGame()                    // Carga directamente el juego. Usada si el jugador define que no tiene video.
                                              // No se le pregunta si tiene audio porque, en el caso de que no, sería imposible jugar. Se asume que, a falta de vídeo, tiene audio.
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("Game Scene");
        FMODUnity.RuntimeManager.PlayOneShot("event:/Sound/Button Play");
    }
    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
        FMODUnity.RuntimeManager.PlayOneShot("event:/Sound/Button UI");
    }
    public void LoadMenu() 
    {
        SceneManager.LoadScene("Menu Principal");
    }
    public void CloseGame() 
    {
        Application.Quit();
    }
}
