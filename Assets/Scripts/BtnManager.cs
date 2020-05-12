using UnityEngine;

public class BtnManager : MonoBehaviour
{
    public void QuitBtn()
    {
        Application.Quit();
    }

    public void StartBtn()
    {
        GameManager.Instance.StartCoroutine("LoadCity");
    }
}
