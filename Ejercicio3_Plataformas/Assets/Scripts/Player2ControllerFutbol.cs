using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2ControllerFutbol : MonoBehaviour
{
    public float fuerza = 500;
    Vector2 _movimiento; //Para guardar las pulsaciones del teclado

    Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _movimiento = Vector2.zero;
        //Si pulso la flecha hacia arriba
        if (Input.GetKey(KeyCode.W))
        {
            _movimiento.y = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _movimiento.y = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _movimiento.x = 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _movimiento.x = -1;
        }

        _rb.AddForce(_movimiento * fuerza);

    }


}
