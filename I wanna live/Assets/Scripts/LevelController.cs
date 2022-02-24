using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    
    
    public GameObject pauseMenu;

    public void ResumeGame()
    {

        pauseMenu.SetActive(false);
        Time.timeScale = 1;

    }

    public void PauseGame()
    {

        pauseMenu.SetActive(true);
        Time.timeScale = 0;

    }

    public void RestartLevelGame()
    {
        Time.timeScale = 1;       
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    
    }
}
