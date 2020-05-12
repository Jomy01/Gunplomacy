using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;//para poder usar snapshots

public class ActivaMusicaSalaBoss : MonoBehaviour
{
    public AudioMixerSnapshot musicaBoss; //musica que suena al entrar en la sala del Boss HAY QUE PONER UN TRIGGER EN LA PUERTA
    public AudioMixerSnapshot musicaNave; // musica a activar al salir del trigger

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            musicaBoss.TransitionTo(1f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            musicaNave.TransitionTo(1F);
        }
    }
}