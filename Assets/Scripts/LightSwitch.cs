using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightSwitch : MonoBehaviour
{
    Light2D[] lightsInChildren;

    // Start is called before the first frame update
    void Start()
    {
        SetupChildren();
        EventSystemGame.current.onLightsOn += turnLightsOn;
    }

    public void SetupChildren()
    {
        lightsInChildren = GetComponentsInChildren<Light2D>(true); //get an array of all 2D lights in the children
    }

    private void turnLightsOn()
    {
        for (int i = 0; i < lightsInChildren.Length; i++)
        {
            lightsInChildren[i].enabled = true;
        }
    }

    private void OnDisable()
    {
        EventSystemGame.current.onLightsOn -= turnLightsOn;
    }

}
