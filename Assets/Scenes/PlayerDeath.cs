using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private bool isDead = false;
    private Rigidbody2D rb;
    private PlayerController playerController;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(isDead) return;
        if(other.CompareTag("Spike"))
        {
            Die();
        }
    }
    void Die()
    {
        isDead = true;
        if(playerController != null)
        {
            playerController.enabled = false;
        }
        if(rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.simulated = false;
        }
        Debug.Log("Game Over!");
    }
}
