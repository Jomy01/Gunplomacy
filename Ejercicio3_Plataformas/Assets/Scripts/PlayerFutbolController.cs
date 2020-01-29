using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFutbolController : MonoBehaviour
{
    public float fuerza = 5;
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
        if(Input.GetKey(KeyCode.UpArrow))
        {
            _movimiento.y = 1;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            _movimiento.y = -1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _movimiento.x = 1;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _movimiento.x = -1;
        }

        _rb.velocity = _movimiento * fuerza;
       
    }

    
}
