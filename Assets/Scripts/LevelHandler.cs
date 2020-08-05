using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour
{

    private int numLevels;

    // Start is called before the first frame update
    void Start()
    {
        numLevels = SceneManager.sceneCountInBuildSettings;
    }
    public void LoadNextLevel()
    {
        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextIndex >= numLevels)
        {
            nextIndex = 0;
        }
        SceneManager.LoadScene(nextIndex);

    }

}
