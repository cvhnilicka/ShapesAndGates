using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        print("start game");
        SceneManager.LoadScene(2);
    }

    public void ExitGame()
    {
        print("exit game");
        Application.Quit();
    }

    public void LoadLevelsMenu()
    {
        SceneManager.LoadScene(1);
    }

}
