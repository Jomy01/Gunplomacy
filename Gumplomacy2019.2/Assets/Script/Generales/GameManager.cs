using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Canvas topCanvas;

    string _activeSceneName = "Asalto";

    // Start is called before the first frame update
    void Start()
    {
        topCanvas = GameObject.Find("CanvasMenuSuperior").GetComponent<Canvas>();
        LoadScene("Asalto");
        Zoom.zoom = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Asalto()
    {
        if (_activeSceneName != "Asalto" )
        {
            LoadScene("Asalto");
            Zoom.zoom = false;
            UnloadScene(_activeSceneName);
            _activeSceneName = "Asalto";
        }
        
    }

    //Aun no implementado
    //public void Opciones()
    //{
    //    LoadScene("Opciones");
    //}


    public void Mejoras()
    {
        if (_activeSceneName != "Mejoras")
        {
            LoadScene("Mejoras");
            UnloadScene(_activeSceneName);
            _activeSceneName = "Mejoras";
        }
    }


    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }

    void UnloadScene(string sceneName)
    {
        SceneManager.UnloadSceneAsync(sceneName);
    }

}
