using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDestroy : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            if (gameObject.tag == "projectile")
            {
                Destroy(gameObject); 
            }
        }
        else if (collision.gameObject.tag == "ground")
        { 
            if (gameObject.tag == "projectile")
            {
                Destroy(gameObject);
            }
        }
    }
}
