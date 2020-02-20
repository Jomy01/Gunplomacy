﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_Impurity : MonoBehaviour
{
    SpriteRenderer mSpR;
    Transform player;

    public GameObject OrbeRoratorio;
    public GameObject OrbeAtaque;
    public float velocidadRotacion;
    [Tooltip("Veces Por Segundo")]
    public float Velocidad_Ataque;

    float cadencia = 0f;
    bool bola1 = false;
    bool bola2 = false;
    Transform pivotOrbeRota;
    Transform pivotAtaque;
    VidaEnemigos vida;

    Vector3 posicionRota1;
    Vector3 posicionRota2;
    Vector3 posicionRota3;
    Vector3 posicionRota4;
    Vector3 posicionAtaque;

    float target;

    private void Awake()
    {
        pivotOrbeRota = transform.GetChild(0).GetComponent<Transform>();
        pivotAtaque = transform.GetChild(1).GetComponent<Transform>();
        player = GameObject.Find("Player").GetComponent<Transform>();
        mSpR = GetComponent<SpriteRenderer>();
        vida = GetComponent<VidaEnemigos>();
    }
    void Start()
    {
        
        pivotOrbeRota.localRotation = Quaternion.Euler(0, 0, 0);

        posicionRota1 = new Vector3(pivotOrbeRota.position.x + 0.77f * 3, pivotOrbeRota.position.y, pivotOrbeRota.position.z);
        posicionRota2 = new Vector3(pivotOrbeRota.position.x, pivotOrbeRota.position.y + 0.77f * 3, pivotOrbeRota.position.z);
        posicionRota3 = new Vector3(pivotOrbeRota.position.x - 0.77f * 3, pivotOrbeRota.position.y, pivotOrbeRota.position.z);
        posicionRota4 = new Vector3(pivotOrbeRota.position.x, pivotOrbeRota.position.y - 0.77f * 3, pivotOrbeRota.position.z);
        posicionAtaque = pivotAtaque.position;

        Instantiate(OrbeRoratorio, posicionRota2, Quaternion.identity, pivotOrbeRota);
        Instantiate(OrbeRoratorio, posicionRota4, Quaternion.identity, pivotOrbeRota);
    }

    // Update is called once per frame
    void Update()
    {
        RotacionOrbes();
        CreacionOrbes();
        Ataque();
        Flip();
    }

    /// <summary>
    /// Maneja la velocidad y el sentido de los orbes
    /// </summary>
    void RotacionOrbes()
    {
            pivotOrbeRota.RotateAround(pivotOrbeRota.position, Vector3.forward, velocidadRotacion * Time.deltaTime);
    }
    /// <summary>
    /// Nos dice cuando se introducirán nuevos orbes
    /// </summary>
    void CreacionOrbes()
    {
        if(vida.vidaEnemigoActual <= vida.vidaEnemigo/2 && !bola1)
        {
            NuevoOrbe(posicionRota1);
            bola1 = true;
        }
        if(vida.vidaEnemigoActual <= vida.vidaEnemigo/4 && !bola2)
        {
            NuevoOrbe(posicionRota3);
            bola2 = true;
        }
    }
    /// <summary>
    /// Instancia un nuevo orbe
    /// </summary>
    /// <param posicion= Vector3"donde se introducirá el nuevo orbe"></param>
    void NuevoOrbe(Vector3 posicion)
    {
        pivotOrbeRota.localRotation = Quaternion.Euler(0, 0, 0);
        Instantiate(OrbeRoratorio, posicion, Quaternion.identity, pivotOrbeRota);
        Invoke("ActivarRotacion", 1f);
    }

    void Ataque()
    {        
        if (Time.time > cadencia)
        {
            cadencia = Time.time  + 1f/Velocidad_Ataque;
            Instantiate(OrbeAtaque, posicionAtaque, Quaternion.identity, transform);
        }
    }

    void Flip()
    {
        target = player.position.x;
        if (target > transform.position.x)
        {
            mSpR.flipX = false;
        }
        if (target < transform.position.x)
        {
            mSpR.flipX = true;
        }
    }
}
