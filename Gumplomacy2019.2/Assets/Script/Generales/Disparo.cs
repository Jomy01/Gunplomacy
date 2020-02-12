using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    /// <summary>
    /// Este script va a tener las cosas generales de cada arma tales como la cadencia, el daño, o la munición
    /// Hecho por Toño Gimeno 29/01 
    /// </summary>
    //Se pondrá en verdadero si el personaje coge un arma
    bool _armaCerca = false;

    GameObject armaSuelo;
    public GameObject armaMano;

    public Transform _mano;
    public Transform _player;
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_armaCerca && Input.GetKeyDown(KeyCode.T))
        {
            // Si el player está cerca y pulsa la T, cambiará el arma por la que está en el suelo
            SoltarPistola();
            CogerPistola();
        }
        if (Input.GetButtonDown("Fire1"))
        {
            armaMano.GetComponent<Armas>().Disparar();
        }
    }

    void CogerPistola()
    {
        armaMano = armaSuelo;
        armaMano.transform.parent = _mano;

        // Utilizo el localPosition porque necesito usar la posicion con respecto al padre
        // el position utiliza la posicion con respecto al mapa
        armaMano.transform.localPosition = Vector3.zero;
        armaMano.transform.rotation = _player.rotation;
    }

    void SoltarPistola()
    {
        //El player deja de ser el padre del arma y por tanto, se queda en esa posición
        armaMano.transform.parent = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Arma"))
        {
            _armaCerca = true;
            armaSuelo = collision.gameObject;
        }
    }

}
