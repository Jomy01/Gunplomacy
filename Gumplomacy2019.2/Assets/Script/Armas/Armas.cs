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
    [Tooltip("Cuántas balas tiene cada cargador")]
    public int municion = 20;
    [Tooltip("Cuánto daño hace cada bala")]
    public int daño = 2;

    [Tooltip("Salida de la bala del arma")]
    public Transform _puntoSalida;

    public GameObject bala;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Disparar()
    {
        if(Time.time>cadencia)
        Instantiate(bala, _puntoSalida.position, _puntoSalida.rotation);
    }
}
