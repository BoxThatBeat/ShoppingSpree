using UnityEngine;

public class FadeEffect : MonoBehaviour
{
    public Texture2D fadeImage;

    public int player;
    public float fadeSpeed = 0.8f;
    public float alpha = 1.0f;
    private int fadeDir = -1;
    private int drawDepth = -1000; //always render on top

    private void Start()
    {
        EventSystemGame.current.onFadeEffect += BeginFade;
    }

    private void OnGUI()
    {
        //fade the alpha value by adding the direction (pos or neg 1) by the speed and deltatime to convert to secs
        alpha += fadeDir * fadeSpeed * Time.deltaTime;

        //force(clamp) the number between 0 and 1
        alpha = Mathf.Clamp01(alpha);

        //set color of our GUI all colors the same but alpha to new alpha
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);

        GUI.depth = drawDepth; //make the black texture reder on top

        if (player == 1)
            GUI.DrawTexture(new Rect(0, 0, Screen.width /2, Screen.height), fadeImage);
        else if (player == 2)
            GUI.DrawTexture(new Rect(Screen.width / 2, 0, Screen.width / 2, Screen.height), fadeImage);
        else
            GUI.DrawTexture(new Rect(Screen.width, 0, Screen.width, Screen.height), fadeImage);
    }

    //Set the direction of the alpha fade:
    private void BeginFade(int id, float speed)
    {
        if (id == player)
        { 
            alpha = 1;
            fadeDir = -1;
            fadeSpeed = speed;
        }
    }

    private void OnDisable()
    {
        EventSystemGame.current.onFadeEffect -= BeginFade;
    }
}
