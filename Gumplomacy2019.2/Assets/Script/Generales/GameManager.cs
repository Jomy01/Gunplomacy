using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Canvas topCanvas;



    // Start is called before the first frame update
    void Start()
    {
        topCanvas = GameObject.Find("CanvasMenuSuperior").GetComponent<Canvas>();
        Asalto();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Asalto()
    {
        LoadScene("Asalto");
    }

    //Aun no implementado
    //public void Opciones()
    //{
    //    LoadScene("Opciones");
    //}

    public void Mejoras()
    {
        LoadScene("Mejoras");
    }



    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }

}
