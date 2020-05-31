using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float zoomInAmount = 0f;
    [SerializeField] private float zoomSpeed = 0f;
    [SerializeField] private int player = 0;

    private Camera cam;
    private Transform target;
    private Vector3 offset = new Vector3(0, 0, -1);

    private bool targetFound = false;
    private bool targetRunning = false;

    private float zoomedInLevel;
    private float zoomedOutLevel;
    public float zoomPercentage = 0;


    private void Start()
    {
        cam = GetComponent<Camera>();
        zoomedOutLevel = cam.orthographicSize;
        zoomedInLevel = cam.orthographicSize - zoomInAmount;
        EventSystemGame.current.onPlayerRunStateChanged += ZoomControl;
    }

    private void ZoomControl(int playerId, bool running)
    {
        if (playerId == player)
        {
            targetRunning = running;
        }
    }


    public void lockTarget(Transform t)
    {
        target = t;
        targetFound = true;
    }

    private void LateUpdate()
    {
        if (targetFound)
        {
            // Always Update to Exactly Targets Position + Offset
            transform.position = new Vector3(
                target.transform.position.x + offset.x,
                target.transform.position.y + offset.y,
                target.transform.position.z + offset.z);
        }

        //always be inbetween these two points
        cam.orthographicSize = Mathf.Lerp(zoomedOutLevel, zoomedInLevel, zoomPercentage);

        if (targetRunning)
        {
            if (zoomPercentage <= 1f)
            {
                zoomPercentage += zoomSpeed;
            }

        }
        else
        {
            if (zoomPercentage >= 0f)
            {
                zoomPercentage -= zoomSpeed;
            }
        }

            

    }

    private void OnDestroy()
    {
        EventSystemGame.current.onPlayerRunStateChanged -= ZoomControl;
    }
}
