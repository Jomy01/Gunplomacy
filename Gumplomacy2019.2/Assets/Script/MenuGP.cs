using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuGP : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void NuevaPartida()
    {
        SceneManager.LoadScene("Partida");
        Debug.Log("Comenzar partida");
    }

    //¿cómo funciona el sistema de guardado y cómo se llama a la partida salvada?
    /*public void Continuar()
    {
        SceneManager.LoadScene("PartidaSalvada");
    }
    */

    public void Opciones()
    {
        SceneManager.LoadScene("Opciones");

    }

    public void Salir()
    {
        Application.Quit();

    }


}
