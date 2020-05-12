using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private Transform target;
    private bool targetFound = false;

    public void lockTarget(Transform t)
    {
        target = t;
        targetFound = true;
    }

    void LateUpdate()
    {
        if (targetFound)
        {
            Vector3 desiredPosition = target.transform.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }

    }
}
