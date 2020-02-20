﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigos : MonoBehaviour
{
    public float vidaEnemigo;
    public float vidaEnemigoActual;
    public int golpe = 0;
    public Transform origenParticulas;
    public GameObject prefabCadaver;


    public ParticleSystem _particulasMuerte;

    // Start is called before the first frame update
    void Awake()
    {
        vidaEnemigoActual = vidaEnemigo;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("BalaProta"))
        {
            RecibeDaño(golpe);
        }

    }

    //Para Testeo
    //private void Update()
    //{
    //    RecibeDaño(golpe);
    //}

    public void RecibeDaño(int daño)
    {
        vidaEnemigoActual -= daño;

        if (vidaEnemigoActual <= 0)
        {
            Muerte();
        }
        else
        {
            daño = 0;
        }
    }

    void Muerte()
    {
        /*PARA EJECUTAR EL SONIDO DE MUERTE DEL PERSONAJE
        AudioEnemy.copia.SonidoMuerte();
        */
        //Instantiate<ParticleSystem>(_particulasMuerte, origenParticulas.position, origenParticulas.rotation);
        //_particulasMuerte.Play();
        Instantiate(prefabCadaver, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}