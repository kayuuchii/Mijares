using UnityEngine;

public class DisappearingPlatforms : MonoBehaviour
{
    public float disappearTime = 5f; 
    public float reappearTime = 2f; 
    public GameObject platform;

    private bool isPlayerOnPlatform = false; 
    private float disappearTimer = 0f; 
    private float reappearTimer = 0f; 

    void Update()
    {
        
        if (isPlayerOnPlatform)
        {
            disappearTimer += Time.deltaTime;

            if (disappearTimer >= disappearTime)
            {
                platform.GetComponent<Renderer>().enabled = false;
                platform.GetComponent<Collider2D>().enabled = false;
                disappearTimer = 0f;
            }
        }
        else
        {
            if (!platform.GetComponent<Renderer>().enabled && !platform.GetComponent<Collider2D>().enabled)
            {
                reappearTimer += Time.deltaTime;

                if (reappearTimer >= reappearTime)
                {
                    platform.GetComponent<Renderer>().enabled = true;
                    platform.GetComponent<Collider2D>().enabled = true;
                    reappearTimer = 0f;
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            isPlayerOnPlatform = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            isPlayerOnPlatform = false;
        }
    }
}
