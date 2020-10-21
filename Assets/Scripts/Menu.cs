using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartGame(Boolean fighter)
    {
        if (fighter)
        {
            Debug.Log("Start Game as fighter");
            SceneManager.LoadScene("Level1_fighter");
        }
        else
        {
            Debug.Log("Start Game as bomber");
            SceneManager.LoadScene("Level1_bomber");
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
