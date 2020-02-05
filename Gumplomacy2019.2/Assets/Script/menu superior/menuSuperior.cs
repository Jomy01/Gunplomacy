using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuSuperior : MonoBehaviour
{
    // Start is called before the first frame update
    public void Inicio()
    {
        SceneManager.LoadScene("inicio");
    }
    public void Asalto()
    {
        SceneManager.LoadScene("asalto");
    }
    public void Mejoras()
    {
        SceneManager.LoadScene("mejoras");
    }
    public void Opciones()
    {
        SceneManager.LoadScene("opciones");
    }
}
