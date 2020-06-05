using System.Collections;
using UnityEngine;

public class StartCam : MonoBehaviour
{
    [SerializeField] private Camera playerOneCam = null;
    [SerializeField] private Camera playerTwoCam = null;

    void Start()
    {

        StartCoroutine(ZoomIn());
    }

    private IEnumerator ZoomIn()
    {
        yield return new WaitForSeconds(2f);

        LeanTween.moveZ(gameObject, -10f, 1f).setOnComplete(SwapActiveCamera);
        
    }

    private void SwapActiveCamera()
    {
        playerOneCam.enabled = true;
        playerTwoCam.enabled = true;

        Destroy(this);
    }
}
