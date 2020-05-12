using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject Target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private void Awake()
    {
        //makes the player script not be destroyed on loading a level
        DontDestroyOnLoad(transform.gameObject);

        
    }

    public void lockTarget()
    {
        Target = GameManager.Instance.playerOne;
    }

    void LateUpdate()
    {
        
        Vector3 desiredPosition = Target.transform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

    }
}
