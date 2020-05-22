using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class SunController : MonoBehaviour
{
    public Gradient gradient; //setup in editor
    GradientColorKey[] colorKey;
    GradientAlphaKey[] alphaKey;

    private Light2D sunLight;

    void Start()
    {
        sunLight = GetComponent<Light2D>();
        EventSystemGame.current.onSunLower += LowerGradient;
    }

    private void LowerGradient(int time)
    {
        float percentage = time / 600f;
        sunLight.color = gradient.Evaluate(1 - percentage);
    }
}
