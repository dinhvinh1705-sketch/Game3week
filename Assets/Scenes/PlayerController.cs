using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    [SerializeField]public float runSpeed = 5f;
    [SerializeField]public float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool canJump = true;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(runSpeed, rb.linearVelocity.y);
    }

    public void OnJump(InputValue value)
    {
        if(value.isPressed && canJump)
        {
            rb.linearVelocity = new Vector2(runSpeed, jumpForce);
        }
        canJump = false;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
    }
}
