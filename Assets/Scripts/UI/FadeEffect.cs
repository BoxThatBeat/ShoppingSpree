using UnityEngine;

public class FadeEffect : MonoBehaviour
{
    public Texture2D fadeImage;
    public float fadeSpeed = 0.8f;

    private int drawDepth = -1000; //always render on top
    public float alpha = 1.0f;
    private int fadeDir = -1;

    private void OnGUI()
    {
        //fade the alpha value by adding the direction (pos or neg 1) by the speed and deltatime to convert to secs
        alpha += fadeDir * fadeSpeed * Time.deltaTime;

        //force(clamp) the number between 0 and 1
        alpha = Mathf.Clamp01(alpha);

        //set color of our GUI all colors the same but alpha to new alpha
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);

        GUI.depth = drawDepth; //make the black texture reder on top

        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeImage);


    }

    //Set the direction of the alpha fade:
    public float BeginFade(int dir)
    {
        fadeDir = dir;
        return (fadeSpeed);
    }

    //automate the fade to occur when a scene is loaded
    private void OnLevelWasLoaded()
    {
        BeginFade(-1);
    }
}
