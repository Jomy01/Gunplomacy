using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigos : MonoBehaviour
{
    public float vidaEnemigo = 1000;
    public float vidaEnemigoActual;

    // Start is called before the first frame update
    void Start()
    {
        vidaEnemigoActual = vidaEnemigo;
    }

    public void RecibeDaño(int daño)
    {
        vidaEnemigoActual -= daño;

        if (vidaEnemigoActual <= 0)
        {
            Muerte();
        }
    }

    void Muerte()
    {
        Destroy(gameObject);
    }
}