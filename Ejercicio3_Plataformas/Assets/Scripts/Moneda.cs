using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Moneda : MonoBehaviour
{
    //La moneda de oro sumara 10 monedas
    public int valor = 10;

    AudioSource sourceMonedas;

    void Start()
    {
        sourceMonedas = GameObject.Find("SonidoMonedas").GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            GameController.copia.SumaMonedas(valor);
            sourceMonedas.Play();
            Destroy(gameObject);
        }
    }
}
