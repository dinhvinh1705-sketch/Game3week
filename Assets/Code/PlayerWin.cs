using UnityEngine;

public class PlayerWin : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerController playerController;
    private bool hasWon = false;
    [SerializeField] public GameManager gameManager;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(hasWon)
        {
            return;
        }
        if(other.CompareTag("Goal"))
        {
            hasWon = true;
            if(playerController != null)
            {
                playerController.enabled = false;
            }
            if(rb != null)
            {
                rb.linearVelocity = Vector2.zero;
                rb.simulated = false;
            }
            if(gameManager != null)
            {
                gameManager.ShowWin();
            }
        }
    }
}
