using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    [SerializeField]public float runSpeed = 5f;
    [SerializeField]public float jumpForce = 10f;
    private Rigidbody2D rb;
    private GroundCheck groundCheck;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        groundCheck = GetComponent<GroundCheck>();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(runSpeed, rb.linearVelocity.y);
    }

    public void OnJump(InputValue value)
    {
        if(value.isPressed && groundCheck != null && groundCheck.IsGrounded())
        {
            rb.linearVelocity = new Vector2(runSpeed, jumpForce);
        }
    }
}
