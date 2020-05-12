using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public static bool isGameOver = false;

    public GameObject gameOverMenuUI;

    void Update()
    {
        if (isGameOver)
        {
            Time.timeScale = 0f;
            gameOverMenuUI.SetActive(true);
        }

    }

    public void ReturnToBase()
    {
        Debug.Log("Regresando a base...");
        isGameOver = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Preload");
    }

    public void ExitGame()
    {
        Debug.Log("Cerrando el juego...");
        //Si el juego cuenta con menu de guardado, invocar aqui
        Application.Quit();
    }
}
