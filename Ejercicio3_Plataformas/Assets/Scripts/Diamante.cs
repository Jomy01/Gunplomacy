using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamante : MonoBehaviour
{
    public int valor = 1;

    AudioSource sourceDiamantes;

    void Start()
    {
        sourceDiamantes = GameObject.Find("SonidoDiamantes").GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            GameController.copia.SumaDiamantes(valor);
            sourceDiamantes.Play();
            Destroy(gameObject);
        }
    }
}
