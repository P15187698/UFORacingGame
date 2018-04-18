using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour {

    public void StartGame()
    {
        SceneManager.LoadScene("Earth"); // takes you to scene 2 (first level)
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // takes you to scene 0 (main menu)
    }

    public void NextLevel()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextScene);
    }

    public void ExitApp()
    {
        Application.Quit();
    }

    // level select button function
    public void LoadEarth()
    {
        SceneManager.LoadScene("Earth"); // takes you to scene 2 (first level)
    }

    public void LoadMoon()
    {
        SceneManager.LoadScene("Moon");
    }
}
