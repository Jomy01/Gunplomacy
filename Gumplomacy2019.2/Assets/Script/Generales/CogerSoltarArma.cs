using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerSoltarArma : MonoBehaviour
{
    /// <summary>
    /// Este script va a tener las cosas generales de cada arma tales como la cadencia, el daño, o la munición
    /// Hecho por Toño Gimeno 29/01 
    /// Modificaciones: el scrip funcionaba bien pero al coger el arpa según donde estaba el puntero y miraba el persobnaje esta no se posicionaba bien
    /// está casi solucionado
    /// Modificado por Jose Antonio Diaz 04/02
    /// </summary>
    //Se pondrá en verdadero si el personaje coge un arma
    bool _armaCerca = false;
    public bool _armaEnMano = false;
    public bool _cogiendoArma;
    GameObject armaSuelo;
    public GameObject armaMano;

    public Transform _mano;
    public GameObject _player;
    public Transform _pivot;
    

    // Update is called once per frame
    void Update()
    {
        if (_armaCerca && Input.GetKeyDown(KeyCode.T) || _armaEnMano && Input.GetKeyDown(KeyCode.T))
        {
            // Si el player está cerca y pulsa la T, cambiará el arma por la que está en el suelo
            if (_armaEnMano)
            {
                SoltarPistola();
            }
            else { CogerPistola(); }

        }
        if (Input.GetButtonDown("Fire1"))
        {
            armaMano.GetComponent<Armas>().Disparar();
        }
    }

    void CogerPistola()
    {
        _cogiendoArma = true;
        armaMano = armaSuelo;
        armaMano.transform.parent = _mano;
        _pivot.rotation = new Quaternion(0, 0, -180, 0);
        // Utilizo el localPosition porque necesito usar la posicion con respecto al padre
        // el position utiliza la posicion con respecto al mapa
        armaMano.transform.localPosition = Vector3.zero;
        armaMano.transform.rotation = _player.transform.rotation;
        _armaEnMano = true;
        _cogiendoArma = false;
    }

    void SoltarPistola()
    {
        //El player deja de ser el padre del arma y por tanto, se queda en esa posición
        armaMano.transform.parent = null;
        _armaEnMano = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Arma"))
        {
            _armaCerca = true;
            armaSuelo = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Arma"))
        {
            _armaCerca = false;
        }
    }
}
