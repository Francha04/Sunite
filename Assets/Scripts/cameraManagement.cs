using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraManagement : MonoBehaviour
{
    public Vector3 myPos;               // La posici´´onn de la cámara.
    public Transform myPlay;            // La posición del player.
    public Orbitacion orbitacionSol;    // El script que maneja la orbitación. Para acceder a la cantidad de planetas orbitando.
    public Camera camaraDeJuego;
    public float aumentoPorPlaneta;
    void Start()
    {
        
    }
    void Update() // Sigue al player.
    {
        Vector3 newCameraPos = new Vector3(myPlay.position.x, myPlay.position.y, myPlay.position.z);  // Agarramos la posicion del player.
        transform.position = (myPlay.position) + myPos;  // Transformamos nuestra posicion segun la del player + nuestra posicion en z.
    }
    public void moveBack() 
    {
        camaraDeJuego = GetComponent<Camera>();                                            // Guardamos el componente camara en la variable.
        camaraDeJuego.orthographicSize = camaraDeJuego.orthographicSize + 0.5f + 0.1f * orbitacionSol.planetsOrbiting / 2;  // Aumentamos su tamaño.
    }
}
    