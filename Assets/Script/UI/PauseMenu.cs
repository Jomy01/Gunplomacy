using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;

    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                Continue();
            }
            else
            {
                Pause();
            }
        }
        
    }

    public void Continue()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void ReturnToBase()
    {
        Debug.Log("Regresando a base...");
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
