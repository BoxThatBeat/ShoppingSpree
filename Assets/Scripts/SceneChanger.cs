using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    public string SceneName;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine("LoadStore");
        }
    }
    IEnumerator LoadStore()
    {
        float fadeTime = GameManager.Instance.GetComponent<FadeEffect>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(SceneName);
    }
}
