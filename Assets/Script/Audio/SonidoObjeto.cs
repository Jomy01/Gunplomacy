using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// script para los objetos que generen un sonido al interactuar con ellos
/// HAY QUE CREAR LOS DISTINTOS SONIDOS E INCLUIRLOS COMO HIJOS DE LA CAMARA, CADA UNO CON SU AUDIOSOURCE
/// </summary>
public class SonidoObjeto : MonoBehaviour
{
    //para incluir el valor de eter del objeto, p ej
    public int valor = 1;
    AudioSource _sourceObjeto;
    void Start()
    {
        //buscamos un objeto llamado "sonidoLOQUESEA" y le cogemos el audiosource
        _sourceObjeto = GameObject.Find("sonidoELOBJETOQUESEA").GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            //accedemos a la funcion suma de eter y le damos qué valor sumarr
            //DONDEQUIERAQUEESTE.SUMAETER(valor);
            _sourceObjeto.pitch = Random.Range(1.2f, 1.5f);
            _sourceObjeto.Play();
            Destroy(gameObject);
        }
    }

}