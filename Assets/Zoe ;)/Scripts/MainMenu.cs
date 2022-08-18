using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //exits the build
    public void QuitGame()
    {
        Application.Quit();
    }

    //loads the next scene in the build index
    public void LoadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //loads the scene titled Main Menu Scene
    public void ExitToMenu()
    {
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
    }
}
