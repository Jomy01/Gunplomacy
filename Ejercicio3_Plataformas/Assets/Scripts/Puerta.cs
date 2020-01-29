using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    // Con public enum defines un nuevo tipo de variable que va a tomar unicamente los valores
    // que pongas entre en los paréntesis unicamente
    public enum ColorLLave { vacio, naranja, verde ,azul}; //Creamos un nuevo tipo de dato

    public ColorLLave llave; //Creamos una variable del tipo de dato creado arriba
    public Transform destino; //Transform del destino del teletransporte
    Transform _player; //Transform del player para poder teletransportarse
    bool _cercaDeLaPuerta = false;
    GameObject _canvasPuerta; // El canvas con el texto de la puerta
    Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").transform;
        _canvasPuerta = transform.Find("CanvasPuerta").gameObject; // Buscamos el canvas dentro del objeto padre
        _canvasPuerta.SetActive(false); // Por defecto el texto no aparece en pantalla
        _anim = GetComponent<Animator>();
        if(llave ==ColorLLave.vacio)
        {
            _anim.SetBool("Abre", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire2") && _cercaDeLaPuerta)
        {// Si la llave es vacio podemos usar el teletransporte
            if (llave==ColorLLave.vacio) 
            {
                _player.position = destino.position;
            } // Si no vemos si podemos usar una llave del inventario
            else if(Inventario.copia.PuedoUsarLaLLave(llave))
            { // Aqui tendremos que activar la animacion de abrir
              // e indicar que esta puerta ya no necesita llave
                _anim.SetBool("Abre", true);
                llave = ColorLLave.vacio;
            }
            
        }

        
    }

    //Cuando el Player entra en la puerta
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            _cercaDeLaPuerta = true; // Activamos la variable cerca
            _canvasPuerta.SetActive(true); // Mostramos el texto del canvas
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            _cercaDeLaPuerta = false;
            _canvasPuerta.SetActive(false);
        }
    }
}
