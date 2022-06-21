using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEditor;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float travelSpeed;
    public int minDistance;
    private int randomIndex;
    public Vector2 targetPosition;
    public spawnManagement grandParentManager;
    public float rotationDegreesPerSecond = 10f;
    public Sprite[] possibleSprites;
    private bool isMoving = true;

    Vector2 originalpositionv;
    void Start()
    {
        spawning spawnerData = GetComponentInParent<spawning>();
        GameObject grandparent = transform.parent.gameObject.transform.parent.gameObject;
        grandParentManager = grandparent.GetComponent<spawnManagement>();
        do
        {
            randomIndex = (int)Random.Range(0, spawnerData.spawnersArr.Length -1 );
            GameObject spawnerToGoTo = spawnerData.spawnersArr[randomIndex];
            targetPosition = new Vector2(spawnerToGoTo.transform.localPosition.x, spawnerToGoTo.transform.localPosition.y);
        } while (Vector2.Distance(this.transform.position, targetPosition) < minDistance);
        int randomSprite = (int)Random.Range(0, possibleSprites.Length);
        this.GetComponent<SpriteRenderer>().sprite = possibleSprites[randomSprite]; 
    }
    void FixedUpdate()
    {
        if (isMoving)
        {
            Vector2 newPosition;
            newPosition = transform.position;
            transform.position = new Vector3(Vector2.MoveTowards(newPosition, targetPosition, travelSpeed).x, Vector2.MoveTowards(newPosition, targetPosition, travelSpeed).y, 1);
            transform.Rotate(0, 0, rotationDegreesPerSecond * Time.deltaTime);
            if (this.transform.localPosition.magnitude < Vector2.Distance(transform.parent.localPosition, targetPosition)  + 1 && (this.transform.localPosition.magnitude > Vector2.Distance(transform.parent.localPosition, targetPosition)))
            {
                grandParentManager.amountOfMeteors--;
                Destroy(this.gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        iAmSunCollider player = collision.GetComponent<iAmSunCollider>();
        if (player == null) return;
        isMoving = false;
        Destroy(this.GetComponent<CapsuleCollider2D>());
        this.GetComponent<Animator>().SetTrigger("Died");
        FMODUnity.RuntimeManager.PlayOneShot("event:/Sound/Meteor Crash Sun", this.transform.position);
        Destroy(this.gameObject, 1f);
    }
}
