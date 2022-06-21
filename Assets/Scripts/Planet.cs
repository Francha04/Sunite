using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public GameObject player;          // El jugador (el Sol).
    public float rotateSpeed;          // La velocidad a la que rota el planeta alrededor del jugador.                       
    private Vector3 coords = new Vector3(0f, 0f, -1f);  // Las coordenadas del rotate
    public bool isOrbit = false;                         // Boolean que guarda si esta orbitando ya en el jugador o no.
    public bool isApproaching = false;                   // Boolean que guarda si esta aproximandose al jugador o no.
    public float approachSpeedCoeficient = 0.9f;         // Coeficiente para manejar la velocidad.
    public float distanciaRomperApproach;                // La distancia necesaria entre el player y el planeta para que el planeta deje de acercarse.
    private float approachSpeed;                         // Contenedor para la velocidad que se calcula cada frame.
    private Vector2 newPosition;                         // La posicion a la que se movera frame por frame.

    private void FixedUpdate()
    {
        if (isOrbit)
        {
            transform.RotateAround(player.transform.position, coords, rotateSpeed);      // Esta funcion hace que rote constantemente alrededor del player.
        }
        else if (isApproaching) 
        {
            Vector2 targetPosition = new Vector2(player.transform.position.x, player.transform.position.y);         // La posicion del player.
            approachSpeed = Vector2.Distance(this.transform.position, targetPosition) / approachSpeedCoeficient;    // Definimos Approach Speed. Calculando la distancia entre el planeta y el player, y luego dividiendola por un coeficiente arbitrario.
            newPosition = Vector2.Lerp(transform.position, targetPosition, approachSpeed);                          // Interpola la posicion actual con la del player según el valor de Approach Speed.
            transform.position = newPosition;                                                 
            if (Mathf.Abs(Vector2.Distance(this.transform.position, targetPosition)) > distanciaRomperApproach)     // Deja de acercarse si el player se aleja mucho.
                {
                    isApproaching = false;
                }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Meteor meteor = collision.GetComponent<Meteor>();
        agujeroNegro agujero = null;
        if (collision is CapsuleCollider2D)
        {
            agujero = collision.GetComponent<agujeroNegro>();
        }
        if ((meteor == null) && (agujero == null)) return;
        if (isOrbit || isApproaching)
        {
            BeenHit();
        }
    }
    public void BeenHit() 
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Sound/Meteor Crash Planet", this.transform.position);
        FMODUnity.RuntimeManager.PlayOneShot("event:/Sound/Lose");
        Movement playerMovement = player.GetComponent<Movement>();
        playerMovement.isPlaying = false;
        Destroy(this);
    }
}
