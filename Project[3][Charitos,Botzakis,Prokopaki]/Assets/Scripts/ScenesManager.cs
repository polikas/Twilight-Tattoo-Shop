using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ScenesManager : MonoBehaviour
{
    public void loadGameplay()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void loadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void loadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void loadWinScene()
    {
        SceneManager.LoadScene("WinScene");     
    }
}
