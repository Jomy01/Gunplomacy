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

    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
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

}
