using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public Transform player;
    public float cameraSpeed;

    private float _cameraOffset;

    private void Start()
    {
        _cameraOffset = transform.position.z;
        transform.position = player.position + Vector3.forward * _cameraOffset;
    }

    private void FixedUpdate()
    {
        var targetPosition = player.position + Vector3.forward * _cameraOffset;
        var smoothedPosition = Vector3.Lerp(transform.position, targetPosition, cameraSpeed);
        transform.position = smoothedPosition;
    }
}
