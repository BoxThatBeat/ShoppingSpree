using UnityEngine;

public class KeepObject : MonoBehaviour
{
    public GameObject rootObj;

    private void Awake()
    {
        DontDestroyOnLoad(rootObj);
    }
}
