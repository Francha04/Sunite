using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activator : MonoBehaviour
{
    public float timeBeforeMove = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("activateMovement");   
    }

    IEnumerator activateMovement()
    {
        this.gameObject.GetComponent<Movement>().enabled = false;
        yield return new WaitForSeconds(timeBeforeMove);
        this.gameObject.GetComponent<Movement>().enabled = true;

    }
}
