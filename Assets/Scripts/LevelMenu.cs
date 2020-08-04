using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    [SerializeField] int levelIndex;

    public void StartLevel()
    {
        print("Starting level: " + levelIndex);
        SceneManager.LoadScene(levelIndex);
    }
}
