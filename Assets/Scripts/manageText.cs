using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class manageText : MonoBehaviour
{
    public Orbitacion player;
    void Start()
    {
        int i = player.planetsOrbiting;
        this.gameObject.GetComponent<Text>().text = i + "/7" ;
    }

}
