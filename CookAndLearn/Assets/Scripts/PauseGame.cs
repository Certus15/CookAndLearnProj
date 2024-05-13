using UnityEngine;

public class PauseGame : MonoBehaviour
{
    [SerializeField]private GameObject pauseMenu;
    [SerializeField]private GameObject dragController;


    private void Start()
    {
        GamePause(true);
    }

    public void GamePause(bool isPaused)
    {
        pauseMenu.SetActive(isPaused);
        dragController.SetActive(!isPaused);
        Time.timeScale = isPaused ? 0f : 1f;
    }
}
