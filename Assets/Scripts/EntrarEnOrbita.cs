using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntrarEnOrbita : MonoBehaviour
{
    public Orbitacion orbitacion;                                       // El script que maneja la orbitacion, contenido en el GameObject del player.
    public cameraManagement camaraprincipal;                            // La camara. Para poder moverla para atras. 
    public GameObject siguientePlaneta;                                 // El siguiente planeta a ser activado.
    public GameObject siguienteCollider;                                // El siguiente collider a ser activado.
    private GameObject thisObject;                                      // Guarda el objeto que contiene este  script.
    public GameObject player;
    public Animator sunDialogue;
    public sunDialogManage dialogueManager;
    public settings soundSettingsManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Planet planeta = collision.GetComponent<Planet>();             // Guardamos en una variable de tipo Planet el objeto que colisionó.
        if (planeta == null) return;                                   // Validacion de que sea un planeta.
        if (!planeta.isApproaching || planeta.isOrbit) return;         // Validacion de que no este ya orbitando.
        planeta.isOrbit = true;                                        // El planeta ahora está orbitando.
        planeta.isApproaching = false;                                 // El planeta ya no está acercandose.
        planeta.transform.SetParent(player.transform, true);             // Transformamos al planeta en hijo del Sol.
        orbitacion.planetsOrbiting = orbitacion.planetsOrbiting + 1;   // Aumentamos en 1 la  cantidad de planetas en orbita.
        if (orbitacion.planetsOrbiting == 2) dialogueManager.StartCoroutine("showPause");
        camaraprincipal.moveBack();            // Mueve para atras la camara.  
        //sunDialogue.gameObject.GetComponent<sunDialogManage>().goToNextSprite();
        sunDialogue.gameObject.GetComponent<SpriteRenderer>().sprite = dialogueManager.possibleDialogues[2];
        dialogueManager.goToNextSprite();
        sunDialogue.SetTrigger("planetEnteredOrbit");
        FMODUnity.RuntimeManager.PlayOneShot("event:/Sound/New Planet Acquired");
        soundSettingsManager.onPlanetGrab();
        if ((siguientePlaneta != null) && (siguienteCollider != null) )ActivateNextPlanetANDCollider();       // Ejecuta el metodo de activacion de ambos gameobjects (collider y planeta).
        orbitacion.increaseRadius();           // Aumentamos el radio de atracción del sol para corresponder con el aumento de tamaño de la cámara.
        this.gameObject.SetActive(false);      // Desactivamos este objeto.
    }

    private void ActivateNextPlanetANDCollider()
    {
        siguientePlaneta.SetActive(true);      // Activa el GameObject del siguiente planeta.
        siguienteCollider.SetActive(true);     // Activa el Colisionador alrededor del player para incorporar al siguiente planeta.
    }
    /*IEnumerator showPause() 
    {
        yield return new WaitForSeconds(5f);
        sunDialogue.gameObject.GetComponent<sunDialogManage>().pauseSprite();
    }*/
}
