using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{

    
    public static LevelController instanse;
    public GameObject pauseMenu;

    public GameObject levelFallCanvas;
    public GameObject levelSuccessCanvas;

    public Image starResultImg;



    private void Start()
    {
        if (instanse == null)
        {
            instanse = this;
        }

    }
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
    public void LevelSuccess()
    {
        Time.timeScale = 0;
        starResultImg.sprite = GameManager.instanse.TwoStarSprite;
        levelSuccessCanvas.SetActive(true);

    }
    public void LevelFall()
    {

        Time.timeScale = 0;
        levelFallCanvas.SetActive(true);

    }
    public void RestartLevelGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        levelFallCanvas.SetActive(false);

    }
}
