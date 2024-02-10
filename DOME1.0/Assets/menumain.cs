using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menumain : MonoBehaviour
{
    
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void Restart()
    {
        SceneManager.LoadSceneAsync(1);

    }
    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(0);

    }
    public void Instr()
    {
        SceneManager.LoadSceneAsync(8);
    }
}
