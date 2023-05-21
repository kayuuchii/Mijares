using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] GameObject gameOverUI;
    [SerializeField] GameObject MenuUI;
    public int maxHealth = 100;
    public float invulnerabilityTime = 1.5f;
    public Text healthText;

    private int currentHealth;
    private bool isInvulnerable = false;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthText();
    }

    public void TakeDamage(int damage)
    {
        if (!isInvulnerable)
        {
            currentHealth -= damage;
            AudioManager.instance.Play("PlayerTakeDamage");
            UpdateHealthText();
            if (currentHealth <= 0)
            {
                AudioManager.instance.Play("PlayerDie");
                Die();
            }
            else
            {
                isInvulnerable = true;
                Invoke(nameof(EndInvulnerability), invulnerabilityTime);
            }
        }
    }

    private void EndInvulnerability()
    {
        isInvulnerable = false;
    }

    private void Die()
    {
        Camera.main.transform.parent = null;
        Destroy(gameObject);
        gameOverUI.SetActive(true);
        MenuUI.SetActive(false);
    }

    private void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth.ToString();
        }
    }
}
