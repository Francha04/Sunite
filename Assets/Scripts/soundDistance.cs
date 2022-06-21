using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class soundDistance : MonoBehaviour
{
    public Transform[] allPlanets;
    public Transform currentPlanet;
    public int planetIndex;
    public float coeficientSize;
    public float currentDistance;
    // Update is called once per frame
    private void Start()
    {
        int planetIndex = 0;
        currentPlanet = allPlanets[planetIndex];
    }

    private void FixedUpdate()
    {
        currentDistance = Mathf.Clamp(Mathf.Pow(Mathf.InverseLerp(0, coeficientSize, Vector2.Distance(this.transform.position, currentPlanet.position)), -1f) / Vector2.Distance(this.transform.position, currentPlanet.position), 0f,1f);
    }

    public void onToNextPlanet()
    {
        planetIndex++;
        currentPlanet = allPlanets[planetIndex].transform;
    }
}
