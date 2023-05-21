using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public GameObject projectilePrefab; // reference to the projectile prefab
    public float projectileSpeed = 10f; // speed of the projectile
    public float fireRate = 0.5f; // rate of fire in seconds
    private float nextFireTime = 0f; // time until the next shot can be fired

    // Update is called once per frame
    void Update()
    {
        // check if the left mouse button is clicked and if enough time has passed since the last shot
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            // update the next fire time
            nextFireTime = Time.time + fireRate;

            // get the position of the mouse cursor in world space
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // create a new projectile object at the player's position and rotation
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            // get the direction from the player to the mouse cursor
            Vector2 direction = (mousePosition - transform.position).normalized;

            // get the rigidbody component of the projectile object
            Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();

            // set the velocity of the projectile to be in the direction of the mouse cursor
            projectileRb.velocity = direction * projectileSpeed;
        }
    }
}
