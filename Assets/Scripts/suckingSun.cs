using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suckingSun : MonoBehaviour
{
    GameObject agujero;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        agujeroNegro place;
        if (collision.gameObject.TryGetComponent<agujeroNegro>(out place))
        {
            agujero = place.gameObject;
        }
        if (agujero == null) return;
        this.transform.parent.gameObject.GetComponent<Movement>().gettingSuckedIN();
        this.transform.parent.gameObject.GetComponent<Movement>().agujero = collision.gameObject;
    }
}
