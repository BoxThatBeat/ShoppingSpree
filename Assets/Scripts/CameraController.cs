using UnityEngine;

public class CameraController : MonoBehaviour
{

    //public float smoothSpeed = 0.125f;
    public Vector3 offset = new Vector3(0, 0, -1);

    private Transform target;
    private bool targetFound = false;

    public void lockTarget(Transform t)
    {
        target = t;
        targetFound = true;
    }

    private void LateUpdate()
    {
        if (targetFound)
        {
            //Vector3 desiredPosition = target.transform.position + offset;
            //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            //transform.position = smoothedPosition;

            // Always Update to Exactly Targets Position + Offset
            transform.position = new Vector3(
                target.transform.position.x + offset.x,
                target.transform.position.y + offset.y,
                target.transform.position.z + offset.z);
        }

    }
}
