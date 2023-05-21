using UnityEngine;

public class MovingObject : MonoBehaviour
{

    public float speed = 10f; 
    public float distanceLimit = 10f; 

    private Vector3 initialPosition; 
    private Vector3 leftLimitPosition; 
    private Vector3 rightLimitPosition;
    private bool isMovingRight = true; 

    void Start()
    {
        initialPosition = transform.position; 
        leftLimitPosition = initialPosition - Vector3.right * distanceLimit / 2; 
        rightLimitPosition = initialPosition + Vector3.right * distanceLimit / 2; 
    }

    void Update()
    {
        if (isMovingRight)
        { 
            if (transform.position.x < rightLimitPosition.x)
            { 
                transform.position += Vector3.right * speed * Time.deltaTime; 
            }
            else
            { 
                isMovingRight = false; 
            }
        }
        else
        {
            if (transform.position.x > leftLimitPosition.x)
            { 
                transform.position += Vector3.left * speed * Time.deltaTime; 
            }
            else
            { 
                isMovingRight = true; 
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        { 
            collision.gameObject.transform.SetParent(transform); 
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        { 
            collision.gameObject.transform.SetParent(null); 
        }
    }
}

