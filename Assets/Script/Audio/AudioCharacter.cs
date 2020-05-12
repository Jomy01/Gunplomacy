using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//para gestionar los audios del Player
public class AudioCharacter : MonoBehaviour
{

    public AudioClip sonidoMovimiento;
    public AudioClip sonidoMuerte;
    public AudioClip sonidoDamage;
    public AudioClip sonidoDisparo1;
    //por si tiene distintas armas/modos de disparo
    public AudioClip sonidoDisparo2;
    public AudioClip sonidoDisparo3;
    
    AudioSource _sourceCharacter;

    //creamos una copia static del script para poder acceder a él
    public static AudioCharacter copia;
    // Start is called before the first frame update
    void Start()
    {
        _sourceCharacter = GetComponent<AudioSource>();
        copia = this;
    }
   
    
    public void SonidoMovimiento()
    {
        //desde donde se llame le metemos el loop con audioSource.loop = true mientras se esté moviendo y Stop() cuando se detenga
        _sourceCharacter.pitch = Random.Range(0.9f, 1.1f);
        _sourceCharacter.PlayOneShot(sonidoMovimiento);

    }
    public void SonidoMuerte()
    {

        _sourceCharacter.pitch = 1;
        _sourceCharacter.PlayOneShot(sonidoMuerte);
    }
    //¿hay que ponerlo en el enemigo?
    public void SonidoDamage()
    {
        _sourceCharacter.PlayOneShot(sonidoDamage);
    }

    public void SonidoDisparo1()
    {
        _sourceCharacter.PlayOneShot(sonidoDisparo1);
    }

    public void SonidoDisparo2()
    {
        _sourceCharacter.PlayOneShot(sonidoDisparo2);
    }

    public void SonidoDisparo3()
    {
        _sourceCharacter.PlayOneShot(sonidoDisparo3);
    }
    
}
