using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class SunController : MonoBehaviour
{
    Gradient gradient;
    GradientColorKey[] colorKey;
    GradientAlphaKey[] alphaKey;

    private Light2D sunLight;

    void Start()
    {
        sunLight = GetComponent<Light2D>();
        EventSystemGame.current.onSunLower += LowerGradient;

        gradient = new Gradient();

        // Populate the color keys at the relative time 0 and 1 (0 and 100%)
        colorKey = new GradientColorKey[2];
        colorKey[0].color = Color.white;
        colorKey[0].time = 1.0f;
        colorKey[1].color = Color.yellow;
        colorKey[1].time = 0.6f;
        colorKey[2].color = new Color(203, 237, 255);
        colorKey[2].time = 0.0f;

        // Populate the alpha  keys at relative time 0 and 1  (0 and 100%)
        alphaKey = new GradientAlphaKey[2];
        alphaKey[0].alpha = 1.0f;
        alphaKey[0].time = 0.0f;
        alphaKey[1].alpha = 1.0f;
        alphaKey[1].time = 1.0f;

        gradient.SetKeys(colorKey, alphaKey);      
    }

    private void LowerGradient(int time)
    {
        float percentage = time / 300f;
        sunLight.color = gradient.Evaluate(percentage);
    }
}
