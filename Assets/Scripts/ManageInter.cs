using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageInter : MonoBehaviour
{
    public GameObject pauseMenu;
    public settings configurationManage;
    private bool isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || (Input.GetKeyDown(KeyCode.Escape))) 
        {
            if (isPaused)
            {
                unPaused();
                configurationManage.unPauseGame();
            }
            else
            {
                paused();
                configurationManage.pauseGame();
            }
        }
    }
    public void paused() 
    {
        pauseMenu.SetActive(true);
        isPaused = true;
    }
    public void unPaused() 
    {
        pauseMenu.SetActive(false);
        isPaused = false;
    }
}
