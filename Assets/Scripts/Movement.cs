using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Animations;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Vector3 mousePosition;
    public float radius;
    public Vector2 newPosition;
    public float MaxSeparation = 0.1f;
    public float maxSpeed;
    public bool isPlaying = true;
    public bool isGettingSuckedIn = false;
    public float maxDistanceSuck;
    public GameObject agujero;
    public float suckedInSpeed;
    public GameObject GameOverMenu;

    void FixedUpdate()
    {
        if (isPlaying)
        {
            Vector2 velocity = new Vector2();
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector2 toCursor = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Camera.main.transform.position;
            velocity = toCursor / MaxSeparation;
            velocity = Vector2.ClampMagnitude(velocity, 1);
            velocity = velocity * maxSpeed;
            newPosition = (transform.position + (Vector3)velocity * Time.fixedDeltaTime);
            newPosition = newPosition.normalized * Mathf.Clamp(newPosition.magnitude, 0, radius);
            if (isGettingSuckedIn) 
            {
                float distanceSunAgujero = Vector2.Distance(this.transform.position, agujero.transform.position);
                newPosition = Vector2.MoveTowards(newPosition, agujero.transform.position, suckedInSpeed / Vector2.Distance(this.transform.position, agujero.transform.position));
                if (distanceSunAgujero > maxDistanceSuck) 
                {
                    agujero = null;
                    isGettingSuckedIn = false;
                }
            }
            transform.position = newPosition;
        }   
        if (!isPlaying) 
        {
            GameOverMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        agujeroNegro place;
        if (collision.gameObject.TryGetComponent<agujeroNegro>( out place)) 
        {
            agujero = place.gameObject;
        }
        print("SUCKING");
        if (agujero == null) return;
        isGettingSuckedIn = true;
    }
    */
    public void gettingSuckedIN() 
    {
        isGettingSuckedIn = true;
    }

}
