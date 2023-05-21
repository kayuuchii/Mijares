using UnityEngine;

public class PlayerHitsHazard : MonoBehaviour
{
    public int damageAmount = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object colliding with the enemy/spike is the player
        PlayerHealth playerHealth = collision.collider.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            // Deal damage to the player
            playerHealth.TakeDamage(damageAmount);
        }
    }
}