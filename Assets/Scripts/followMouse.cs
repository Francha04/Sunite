using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class followMouse : MonoBehaviour
{
    public Vector3 mousePositionF;
    public float moveSpeed = 0.1f;
    public float radius;
    public Vector3 newPositionFace;
    public Transform parentPosition;
    public Vector2 center = new Vector2(Screen.width/2, Screen.height/2);
    void Update()
    {        
        mousePositionF = Input.mousePosition;
        mousePositionF = Camera.main.ScreenToWorldPoint(mousePositionF);
        //Debug.Log(mousePositionF);
        mousePositionF = mousePositionF - parentPosition.position;
        mousePositionF.x = Mathf.Clamp(mousePositionF.x, -radius, radius);
        mousePositionF.y = Mathf.Clamp(mousePositionF.y, -radius, radius);      
        newPositionFace.x = Mathf.Clamp(newPositionFace.x, -radius, radius);
        newPositionFace.y = Mathf.Clamp(newPositionFace.y, -radius, radius);
        mousePositionF = new Vector3(mousePositionF.x, mousePositionF.y, -1f);
        this.transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, mousePositionF, Time.deltaTime * moveSpeed);
    }
}
