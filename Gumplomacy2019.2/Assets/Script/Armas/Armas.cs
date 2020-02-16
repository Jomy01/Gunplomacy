using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armas : MonoBehaviour
{
    /// <summary>
    /// Este script va a tener las características del disparo del mutano 
    /// Va a ser el que se va a usar como referencia para programar el resto de armas
    /// Hecho por Toño Gimeno 29/01 
    /// </summary>

    [Tooltip("El número de balas que suelta por segundo")]
    public float cadencia = 5;
    [Tooltip("Cuánto daño hace cada bala")]
    public int daño = 2;
    [Tooltip("Raza a la que pertenece el arma")]
    public string raza;
    [Tooltip("Eter que consume la utilizacion del arma")]
    public int consumoEter;

    float proximoDisparo = 0;
    [Tooltip("Salida de la bala del arma")]
    public Transform _puntoSalida;

    public GameObject bala;

    public void Disparar()
    {
        if (Time.time >proximoDisparo)
        { 
        Instantiate(bala, _puntoSalida.position, _puntoSalida.rotation);
            proximoDisparo = Time.time + cadencia;
        }
    }
}
