using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu = null; //menu UI elements

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel") || Input.GetButtonDown("JCancel1") || Input.GetButtonDown("JCancel2"))
        {
            if (GameManager.Instance.GameIsPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameManager.Instance.GameIsPaused = false;
    }

    private void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameManager.Instance.GameIsPaused = true;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        GameManager.Instance.LoadCity();
    }

    public void SwitchToMainMenu()
    {
        Time.timeScale = 1f;
        GameManager.Instance.GameIsPaused = false;
        GameManager.Instance.LoadMainMenu();
    }

    public void Quit()
    {
        Time.timeScale = 1f;
        GameManager.Instance.QuitGame();
    }
}
