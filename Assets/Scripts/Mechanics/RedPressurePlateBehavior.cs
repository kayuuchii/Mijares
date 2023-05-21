using UnityEngine;

public class RedPressurePlateBehavior : MonoBehaviour
{
    public GameObject door; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Box")) 
        {
            door.SetActive(false); 
        }
    }
}
