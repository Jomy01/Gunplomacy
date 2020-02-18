using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// script genérico para reproducri los sonidos de cualqueir enemigo
/// </summary>
public class AudioEnemy : MonoBehaviour
{

    //duplicar la línea de sonidoAtaque si el enemigo tiene más de un ataque
    public AudioClip sonidoAtaque;
    public AudioClip sonidoMovimiento;
    public AudioClip sonidoMuerte;

    AudioSource _sourceEnemy;

    //creamos una copia static del script para poder acceder a él
    public static AudioEnemy copia;

    // Start is called before the first frame update
    void Start()
    {
        _sourceEnemy = GetComponent<AudioSource>();
        copia = this;

    }

    public void SonidoAtaque()
    {
        //para cambiar el pitch
        _sourceEnemy.pitch = Random.Range(0.8f, 1.2f);
        _sourceEnemy.PlayOneShot(sonidoAtaque);
        //dejamos el pitch a 1
        _sourceEnemy.pitch = 1;
    }

    public void SonidoMovimiento()
    {
        //para cambiar el pitch
        _sourceEnemy.pitch = Random.Range(0.8f, 1.2f);
        _sourceEnemy.PlayOneShot(sonidoMovimiento);
        //dejamos el pitch a 1
        _sourceEnemy.pitch = 1;
    }

    public void SonidoMuerte()
    {
       _sourceEnemy.PlayOneShot(sonidoMuerte);
        
    }

}
