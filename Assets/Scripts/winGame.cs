using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winGame : MonoBehaviour
{
    public GameObject blackScreen;
    public settings gameManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        Movement player = collision.GetComponent<Movement>();
        if (player == null) return;
        if (player.gameObject.GetComponent<Orbitacion>().planetsOrbiting >= 7)
        {
            WinGame();
            gameManager.victoryCutscene();
        }
    }

    public void WinGame() 
    {
        blackScreen.SetActive(true);
        blackScreen.GetComponent<Animator>().SetTrigger("hasWon");
    }
}
