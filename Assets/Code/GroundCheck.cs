using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public Transform checkPoint;
    public LayerMask groundLayer;
    [SerializeField] public float rayDistance = 0.15f;

    public bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(checkPoint.position, Vector2.down, rayDistance, groundLayer);
        return hit.collider != null;
    }
    void OnDrawGizmos()
    {
        if(checkPoint == null) return;
        Gizmos.color = IsGrounded() ? Color.green : Color.red;
        Gizmos.DrawLine(checkPoint.position,checkPoint.position + Vector3.down * rayDistance);
    }
}