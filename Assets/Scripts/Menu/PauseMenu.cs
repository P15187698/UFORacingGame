using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool gamePaused = false;
    public GameObject pauseMenu;
    public GameObject HUD;

    public AudioSource engineSound;
    public AudioSource AISound;

	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
	}

    public void ResumeGame() // when resumed, un freeze gameplay and set gamePaused to false
    {
        pauseMenu.SetActive(false); // deactivate the pause menu
        HUD.SetActive(true);
        engineSound.Play();
        AISound.Play();
        Time.timeScale = 1f; // sets game speed back to normal
        gamePaused = false;
    }

    void PauseGame() // when paused, bring up pause menu and freeze gameplay
    {
        pauseMenu.SetActive(true); // activate the pause menu
        HUD.SetActive(false);
        engineSound.Pause();
        AISound.Pause();
        Time.timeScale = 0f; // freezes the game time
        gamePaused = true;
    }

    public void loadMenu()
    {
        Time.timeScale = 1f; // sets game speed back to normal
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
