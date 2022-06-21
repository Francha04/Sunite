using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followMouseinCanvas : MonoBehaviour
{
    public Vector3 mousePositionF;
    public float moveSpeed = 0.1f;
    public float radius;
    public Vector3 newPositionFace;
    public Transform parentPosition;
    public Vector2 center;
    void FixedUpdate()
    {
        mousePositionF = Input.mousePosition;
        //mousePositionF = Camera.main.ScreenToWorldPoint(mousePositionF);
        mousePositionF = mousePositionF - parentPosition.position;
        mousePositionF.x = Mathf.Clamp(mousePositionF.x, -radius, radius);
        mousePositionF.y = Mathf.Clamp(mousePositionF.y, -radius, radius);
        newPositionFace.x = Mathf.Clamp(newPositionFace.x, -radius, radius);
        newPositionFace.y = Mathf.Clamp(newPositionFace.y, -radius, radius);
        mousePositionF = new Vector3(mousePositionF.x, mousePositionF.y, -1f);
        this.transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, mousePositionF, Time.deltaTime * moveSpeed);
    }
}
