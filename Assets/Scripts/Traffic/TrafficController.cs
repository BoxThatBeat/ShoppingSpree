using System.Collections;
using UnityEngine;

public class TrafficController : MonoBehaviour
{

    public TrafficLight[] traficLightsX;
    public TrafficLight[] traficLightsY;

    public TrafficSettings settings;

    private bool readyToChange = true;

    private void Start()
    {
        traficLightsX[0].currentState = lightColor.red;
        traficLightsX[1].currentState = lightColor.red;
    }

    // Update is called once per frame
    private void Update()
    {
        if (readyToChange)
            StartCoroutine(ChangeLights());
    }

    private IEnumerator ChangeLights()
    {

        traficLightsX[0].SwitchLight();
        traficLightsX[1].SwitchLight();
        traficLightsY[0].SwitchLight();
        traficLightsY[1].SwitchLight();

        readyToChange = false;
        yield return new WaitForSeconds(settings.transitionPeriod);
        readyToChange = true;
    }
}
