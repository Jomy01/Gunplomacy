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
    public bool _armaSecundaria = false;
    public bool _cogiendoArma;
    GameObject armaSuelo;
    public GameObject armaMano;
    public GameObject armaSecundaria;
    public Transform _mano;
    public GameObject _player;
    public Transform _pivot;
    public Armas armaPrincipal;

    bool puedoDisparar = true;
    GestionEter eter;

    private void Awake()
    {
        Debug.Log("CogerSoltar");
        armaPrincipal = armaMano.GetComponent<Armas>();
        eter = gameObject.GetComponent<GestionEter>();
    }
    // Update is called once per frame
    void Update()
    {
        if (_armaCerca && Input.GetKeyDown(KeyCode.T))
        {
            // Si el player está cerca y pulsa la T, cambiará el arma por la que está en el suelo
            if (_armaSecundaria)
            {
                CogerPistola();
            }
            else {

                CogerPistola();
            }

        }
      

        if (Input.GetMouseButtonDown(0))
        {
           
            if (puedoDisparar && hasEter())
            {
                armaPrincipal.Disparar();
                eter.ControlEter(armaPrincipal.consumoEter, armaPrincipal.raza);
                puedoDisparar = false;
                Invoke("PuedoDisparar", armaPrincipal.cadencia);
            }
        }
    }

    void CogerPistola()
    {
        _cogiendoArma = true;
        SoltarPistola();
        armaMano = armaSuelo;
        armaPrincipal = armaMano.GetComponent<Armas>();
        armaMano.transform.parent = _mano;
        _pivot.rotation = new Quaternion(0, 0, -180, 0);
        // Utilizo el localPosition porque necesito usar la posicion con respecto al padre
        // el position utiliza la posicion con respecto al mapa
        armaMano.transform.localPosition = Vector3.zero;
        armaMano.transform.rotation = _player.transform.rotation;
        //_armaEnMano = true;
        _cogiendoArma = false;
    }

    void SoltarPistola()
    {
        //El player deja de ser el padre del arma y por tanto, se queda en esa posición
        armaMano.transform.parent = null;
        //_armaEnMano = false;
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

    void PuedoDisparar()
    {
        puedoDisparar = true;
    }

    bool hasEter()
    {
        bool can = false;
        switch (armaPrincipal.raza)
        {
            case "Botaniclos":
                if (eter.sliderBotaniclos.value > Mathf.Abs(armaPrincipal.consumoEter))
                {
                    can = true;
                }
                break;
            case "Mutanos":
                if (eter.sliderMutanos.value > Mathf.Abs(armaPrincipal.consumoEter))
                {
                    can = true;
                }
                break;
            case "Mecanos":
                if (eter.sliderMecanos.value > Mathf.Abs(armaPrincipal.consumoEter))
                {
                    can = true;
                }
                break;
            case "Ictioniclos":
                if (eter.sliderIctioniclos.value > Mathf.Abs(armaPrincipal.consumoEter))
                {
                    can = true;
                }
                break;
        }
        return can;
    }
}
