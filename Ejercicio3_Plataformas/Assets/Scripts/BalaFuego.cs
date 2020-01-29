using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaFuego : MonoBehaviour
{
    public float velocidad = 20;

    Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = transform.right * velocidad;
        Destroy(gameObject, 4);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
