using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDialogue : MonoBehaviour
{
    public GameObject dialogueCanvas;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dialogueCanvas.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        dialogueCanvas.SetActive(false);
    }
}
