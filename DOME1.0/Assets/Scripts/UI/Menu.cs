using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
        
    }
    public void Restart()
    {
        SceneManager.LoadSceneAsync(1);

    }
    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(0);

    }
    public void Quit()
    {
        SceneManager.LoadSceneAsync(1);

    }
}
