using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLose : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Movement player = collision.transform.parent.GetComponent<Movement>();
        Planet planet = collision.transform.parent.GetComponent<Planet>();
        if (player == null && planet == null) return;
        FMODUnity.RuntimeManager.PlayOneShot("event:/Sound/Lose");
        player.isPlaying = false;
    }
}   
