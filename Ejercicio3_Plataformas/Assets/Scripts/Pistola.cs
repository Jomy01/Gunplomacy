using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Si pulsamos la tecla T la pistola se va a teletransportar a nuestra mano
public class Pistola : MonoBehaviour
{
    bool _playerCerca = false;
    bool _pistolaEnMano = false;

    Transform _mano; // Para poder tener acceso a la posicion de la mano
    Transform _player; // Para coger la rotacion que tiene y girar la pistola
    Transform _puntoSalida;

    public GameObject bala;
    // Start is called before the first frame update
    void Start()
    {
        _mano = GameObject.Find("ManoDerecha").transform; //Buscamos el objeto manoderecha y le extraemos el Transform
        _player = GameObject.Find("Player").transform;
        _puntoSalida = transform.Find("SalidaBala").transform; // Se pone con un transform porque puede haber muchas pistolas y por tanto, varios salidaBala
        // poniendo el transform busca exclusivamente en los hijos del objeto
    }

    // Update is called once per frame
    void Update()
    {
        if(_playerCerca && !_pistolaEnMano && Input.GetKeyDown(KeyCode.T))
        {
            // Si estamos cerca, cogeremos la pistola en caso de que pulsemos la T
            CogerPistola();
        }
        else if(_pistolaEnMano && Input.GetKeyDown(KeyCode.T))
        {
            SoltarPistola();
        }

        if(_pistolaEnMano && Input.GetButtonDown("Fire1"))
        {
            Disparar();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.transform.CompareTag("Player"))
        {
            _playerCerca = true;
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.transform.CompareTag("Player"))
        {
            _playerCerca = false;
        }
    }

    void CogerPistola()
    {
        transform.parent = _mano;
        
        // Utilizo el localPosition porque necesito usar la posicion con respecto al padre
        // el position utiliza la posicion con respecto al mapa
        transform.localPosition = Vector3.zero;
        transform.rotation = _player.rotation;

        _pistolaEnMano = true;
    }
    void SoltarPistola()
    {
        transform.parent = null;
        _pistolaEnMano = false;
    }

    void Disparar()
    {
        Instantiate(bala, _puntoSalida.position, _puntoSalida.rotation);
    }
}
