using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePressurePlateBehavior : MonoBehaviour
{
    public GameObject door; 

    private bool isTriggered = false; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Box")) 
        {
            isTriggered = true;
            door.SetActive(false); 
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Box")) 
        {
            isTriggered = false;
        }
    }

    private void Update()
    {
        if (!isTriggered && !door.activeSelf) 
        {
            door.SetActive(true); 
        }
    }
}
