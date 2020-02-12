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
        LoadScene("Asalto");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NuevaPartida()
    {
        LoadScene("Asalto");
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }

}
