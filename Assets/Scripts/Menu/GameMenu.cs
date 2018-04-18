using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour {

    public static bool gamePaused = false;
    public static bool gameFinished = false;
    public GameObject pauseMenu;
    public GameObject finishMenu;
    public GameObject HUD;

    public AudioSource engineSound;
    public AudioSource AISound;

    void Awake()
    {
        gameFinished = false; // on awake set the game finished state to false
        Time.timeScale = 1f; // reset game speed to normal allowing everything to be active again
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // using keyboard input to open a pause menu
        {
            if (gamePaused) // if gamePaused boolean is true then you can press escape to return to the game
            {
                ResumeGame();
            }
            else
            {
                PauseGame(); // if the boolean is set to false then when you press escape it will display the pause menu
            }
        }

        if (gameFinished) // if the game finish is set to true then display the race finish menu
        {
            FinishGame();
        }
    }

    public void ResumeGame() // when resumed, unfreeze gameplay and set gamePaused to false
    {
        pauseMenu.SetActive(false); // deactivate the pause menu
        HUD.SetActive(true); // display hud again once pause menu has closed
        engineSound.Play(); //continue playing sound effects again
        AISound.Play();
        Time.timeScale = 1f; // sets game speed back to normal
        gamePaused = false; // set game paused state to false 
    }

    void PauseGame() // when paused, bring up pause menu and freeze gameplay
    {
        pauseMenu.SetActive(true); // activate the pause menu
        HUD.SetActive(false); // and hide the hud
        engineSound.Pause(); // pause sound effects
        AISound.Pause();
        Time.timeScale = 0f; // freezes the game time
        gamePaused = true; //set game paused boolean to true so that when you press escape the menu will close
    }

    void FinishGame()
    {
        finishMenu.SetActive(true); // display a menu once the player has completed the race track
        HUD.SetActive(false); // disable the hud so only the finish menu is displayed
        engineSound.Pause(); // pause sound effects
        AISound.Pause();
        Time.timeScale = 0f; // freeze game time so nothing is active
        gameFinished = true; // set the game finished state to true
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f; // sets game speed back to normal
        SceneManager.LoadScene("MainMenu"); // go to main menu scene on button click
        
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
