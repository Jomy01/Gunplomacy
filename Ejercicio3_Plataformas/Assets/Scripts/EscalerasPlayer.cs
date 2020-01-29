using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscalerasPlayer : MonoBehaviour
{
    Rigidbody2D _rb;
    public float velocidad = 2;
    public bool escalera = false;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            _rb.velocity = Vector2.left * velocidad;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _rb.velocity = Vector2.right * velocidad;
        }
        if(Input.GetKey(KeyCode.UpArrow) && escalera)
        {
            _rb.velocity = Vector2.up * velocidad;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Escalera"))
        {
            escalera = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Escalera"))
        {
            escalera = false;
        }
    }
}
