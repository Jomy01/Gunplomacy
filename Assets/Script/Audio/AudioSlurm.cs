using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//para gestionar los audios del Player
public class AudioSlurm : MonoBehaviour
{

    public AudioClip sonidoMovimiento;
    public AudioClip sonidoMuerte;
    public AudioClip sonidoAtaque;
    Animator animator;
    bool activacionSonidoMorir;
    bool activacionSonidoMov;
    AudioSource _sourceSlurm;

    //creamos una copia static del script para poder acceder a él
    public static AudioSlurm copia;
    // Start is called before the first frame update
    void Start()
    {
        _sourceSlurm = GetComponent<AudioSource>();
        copia = this;
        activacionSonidoMorir = animator.GetBool("Morir");
        activacionSonidoMov = animator.GetBool("mover");
    }

    private void Update()
    {

    }

    public void SonidoMovimiento()
    {
        if (activacionSonidoMov)
        {
        //desde donde se llame le metemos el loop con audioSource.loop = true mientras se esté moviendo y Stop() cuando se detenga
        _sourceSlurm.pitch = Random.Range(0.9f, 1.1f);
        _sourceSlurm.PlayOneShot(sonidoMovimiento);
        }

       
    }
    public void SonidoMuerte()
    {
        if (activacionSonidoMorir)
        {
        _sourceSlurm.pitch = 1;
        _sourceSlurm.PlayOneShot(sonidoMuerte);
        }

    }
    // Cuando realice el ataque selecionara el sonido de ataque
    public void SonidoAtaque()
    {

        _sourceSlurm.PlayOneShot(sonidoAtaque);

    }

    

}
