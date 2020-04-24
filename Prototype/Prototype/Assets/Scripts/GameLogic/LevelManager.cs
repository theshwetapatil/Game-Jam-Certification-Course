using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
   public void NextScene()
    {
        int level = SceneManager.GetActiveScene().buildIndex;
        
        level++;

        if (level >= SceneManager.sceneCountInBuildSettings)
        {
            level = 0;
        }

        SceneManager.LoadScene(level);
    }

    public void PrevScene()
    {
        int level = SceneManager.GetActiveScene().buildIndex;

        level--;

        if (level <= 0)
        {
            level = SceneManager.sceneCountInBuildSettings - 1;
        }

        SceneManager.LoadScene(level);
    }

    public void Retry()
    {
        int level = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(level);
    }

    public void WrapTo(int index)
    {
        SceneManager.LoadScene(index);
    }
}
