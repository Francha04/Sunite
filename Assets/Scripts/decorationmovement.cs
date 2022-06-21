using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class decorationmovement : MonoBehaviour
{
    public Vector2 targetLocation;
    public float speed;
    public bool shouldBeMoving;
    public float timeBeforeStart;
    Vector2 originalPosition;

    private void FixedUpdate()
    {
        originalPosition = transform.position;
        StartCoroutine("stallForThreeSeconds");
        if (shouldBeMoving)
        {
            Vector2 newPosition;
            newPosition = Vector2.MoveTowards(this.transform.position, targetLocation, speed);
            transform.position = newPosition;
        }
    }

    IEnumerator stallForThreeSeconds() 
    {
        yield return new WaitForSeconds(timeBeforeStart);
        shouldBeMoving = true;
    }
}
