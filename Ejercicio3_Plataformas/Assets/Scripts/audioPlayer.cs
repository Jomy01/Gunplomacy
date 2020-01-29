using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioPlayer : MonoBehaviour
{
    public AudioClip sonidoSalto;
    public AudioClip sonidoCaida;
    AudioSource sourcePlayer;

    public static audioPlayer copia;
    // Start is called before the first frame update
    void Start()
    {
        sourcePlayer = GetComponent<AudioSource>();
        copia = this;
    }

    /// <summary>
    ///A esta funcion se le llama desde la animacion de salto del player 
    public void SonidoSalto()
    {
        Debug.Log("Sonido Salto");
        sourcePlayer.pitch = Random.Range(0.8f, 1.2f);
        sourcePlayer.PlayOneShot(sonidoSalto);
    }
    public void SonidoCaida()
    {
        sourcePlayer.pitch = 1;
        sourcePlayer.PlayOneShot(sonidoCaida);
    }
}
