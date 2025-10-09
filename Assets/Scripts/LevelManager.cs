using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNewLevel(BuildIndex:1);
        }    

    }

    public void LoadNewLevel(int BuildIndex)
    {
        SceneManager.LoadScene(BuildIndex);
    }
}    