using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    public enum ColorLlave { vacio, koala, StarWar, Dragon, Alas, Demons }
    public ColorLlave llave;
    public bool _cercaDeLaPuerta = false;
    GameObject _canvasPuerta;
    Animator _animPuerta;

    void Start()
    {
        _animPuerta = GetComponent<Animator>();
        if (llave == ColorLlave.vacio)
        {
            _animPuerta.SetBool("abrir", true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2") && _cercaDeLaPuerta)
        {
            if (Inventario.copia.PuedoUsarLaLlave(llave))
            {
                _animPuerta.SetBool("abrir", true);
                llave = ColorLlave.vacio;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            _cercaDeLaPuerta = true;
            _canvasPuerta.SetActive(true);
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
