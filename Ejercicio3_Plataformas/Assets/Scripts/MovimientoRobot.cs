using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoRobot : MonoBehaviour
{
    Rigidbody2D _rb;
    Vector2 _movimiento;
    public float speed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        _rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            _rb.velocity=new Vector2(-speed, _rb.velocity.y);
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            _rb.velocity=new Vector2(speed, _rb.velocity.y);
        }
        
    }
}
