using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //Para poder cambiar de escena

public class Porteria : MonoBehaviour
{

    public Text puntos; // Texto donde vamos a mostrar los goles en la UI
    int goles = 0; //Guardamos los goles de esta porteria

    private void Update()
    {
        if(goles >= 5)
        { //Para pasar a la siguiente escena, ANTES HAY QUE AÑADIRLA EN BUILD SETTINGS
            SceneManager.LoadScene("Nave");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Pelota"))
        {
            goles++;
            puntos.text = goles.ToString();
        }
    }
}
