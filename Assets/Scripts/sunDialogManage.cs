using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sunDialogManage : MonoBehaviour
{
    public Sprite[] possibleDialogues;
    public int dialogueIndex;
    public SpriteRenderer thisSpriteRenderer;
    public float timeBeforePause;
    void Start()
    {
        dialogueIndex = 0;
    }

    public void goToNextSprite() 
    {
        print("HEY");
        dialogueIndex = dialogueIndex + 1;
        thisSpriteRenderer.sprite = possibleDialogues[dialogueIndex];
        //this.GetComponent<SpriteRenderer>().sprite = possibleDialogues[dialogueIndex];
    }
    public void pauseSprite() 
    {
        print("hey");
       thisSpriteRenderer.sprite = possibleDialogues[0];
        this.GetComponent<Animator>().SetTrigger("planetEnteredOrbit");
        StartCoroutine("backToNormalSprite");
    }
    IEnumerator backToNormalSprite() 
    {
        yield return new WaitForSeconds(2f);
        this.GetComponent<SpriteRenderer>().sprite = possibleDialogues[dialogueIndex];
    }
    IEnumerator showPause() 
    {
        yield return new WaitForSeconds(timeBeforePause);
        pauseSprite();
    }
}
