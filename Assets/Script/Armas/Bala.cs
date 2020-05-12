using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float velocidad = 20;
    public int daño;
    Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = transform.right * -velocidad;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if((gameObject.tag == "BalaProta" && collision.gameObject.tag != "ArmaProtagonista" && collision.gameObject.tag != "Player") || gameObject.tag != "BalaProta")
        {
            Destroy(gameObject);
        }
    }
}
