using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbitacion : MonoBehaviour
{
    public int planetsOrbiting = 0;                        // Inicializamos la variable que contara cuantos planetas ya orbitan al Player
    public float aumentoRadio = 1.3f;                      // Variable que controla cuanto aumenta el radio de atraccion del player cada
                                                           // vez que incorpora un planeta.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Planet planeta = collision.GetComponent<Planet>();    // Agarramos el objeto de tipo Planet con el que colisionamos  y lo guardamos.
        if (planeta == null) return;                          // Validacion de que sea un planeta.
        if (planeta.isApproaching || planeta.isOrbit) return; // Validacion de que no este ya orbitando.
        planeta.isApproaching = true;                         // Una vez pasada la validacion, le decimos que comience a acercarse.
        GameObject exclamacion = planeta.gameObject.transform.GetChild(0).gameObject;
        exclamacion.GetComponent<Animator>().SetBool("hasBeenTriggered", true);
    }
    public void increaseRadius()                             // Metodo que aumenta el radio de atraccion del circulo segun nuestra variable.
    {
        CircleCollider2D atractor = this.GetComponent<CircleCollider2D>(); // Agarramos el CircleCollider2D y lo guardamos en "atractor".
        atractor.radius = atractor.radius + aumentoRadio;                  // Aumentamos el radio del CircleCollider segun nuestra variable.
        if (planetsOrbiting == 7) 
        {
            atractor.radius = 2f;
        }
    }
}
