using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArkanoidPelota : MonoBehaviour
{
    Rigidbody2D _rb;
    public float fuerza = 100f;
    Vector2 direccion;
    bool salida = false;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !salida)
        {
            direccion.x = Random.Range(-1f, 1f);
            direccion.y = 1f;
            _rb.AddForce(direccion * fuerza);

            salida = true;
        }
    }
}
