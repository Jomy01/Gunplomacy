using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio; //Para poder trabajar con los SnapShot

public class ActivaMusica : MonoBehaviour
{
    public AudioMixerSnapshot musicaIn; // Musica que vamos a activar cuando entre en el trigger
    public AudioMixerSnapshot musicaOut; // Muisca que vamos a activar cuando salga del trigger

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            musicaIn.TransitionTo(1f);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            musicaOut.TransitionTo(1f);
        }
    }
}
