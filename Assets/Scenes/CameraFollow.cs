using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 5f;
    public Vector3 offset = new Vector3(0f, 1f, -10f);
    void LateUpdate()
    {
        if(player == null) return;
        Vector3 targetPosition = new Vector3( player.position.x 
                                            + offset.x, transform.position.y, offset.z);
        transform.position = Vector3.Lerp(transform.position, 
                                          targetPosition, smoothSpeed*Time.deltaTime);
    }
}
