using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsaultManager : MonoBehaviour
{
    /// <summary>
    /// Este script sirve para cargar los distintos niveles en el menu de asalto
    /// </summary>
    

    public static int levelID;

    Camera cam;

    CanvasElements canvas;


    GameObject cExit;
    GameObject panel;



    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        SceneManager.UnloadSceneAsync("Asalto");
    }

    private void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        canvas = GameObject.Find("CanvasAsalto").GetComponent<CanvasElements>();

        cExit = canvas.exit;
        panel = canvas.holo;
    }




    public void CargarNivel(int nivelID)
    {
        switch(nivelID)
            {
            //Nave Crucero Mutanos
            case 0:
                LoadScene("Batalla_Mutanos_Crucero");
                break;
            case 1:
                LoadScene("Batalla_Mutanos_Expedicion");
                break;
            case 2:
                LoadScene("Batalla_Mutanos_NaveGuerra");
                break;
            case 3:
                LoadScene("Batalla_Mecanos_Crucero");
                break;
            case 4:
                LoadScene("Batalla_Mecanos_Expedicion");
                break;
            case 5:
                LoadScene("Batalla_Mecanos_NaveGuerra");
                break;
            case 6:
                LoadScene("Batalla_Botaniclos_Crucero");
                break;
            case 7:
                LoadScene("Batalla_Botaniclos_Expedicion");
                break;
            case 8:
                LoadScene("Batalla_Botaniclos_NaveGuerra");
                break;
            case 9:
                LoadScene("Batalla_Ictioniclos_Crucero");
                break;
            case 10:
                LoadScene("Batalla_Ictioniclos_Expedicion");
                break;
            case 11:
                LoadScene("Batalla_Ictioniclos_NaveGuerra");
                break;


        }
    }

    public void Atras()
    {

        Zoom.zoom = false;
        cam.transform.position = new Vector3(0,0,-10);
        cam.GetComponent<Camera>().orthographicSize = 5f;
        cExit.SetActive(false);
        panel.SetActive(false);

    }
}
