using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nave : MonoBehaviour
{
    public float fuerza = 100;
    Rigidbody2D _rb;
    public float giro = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            _rb.AddForce(transform.up * fuerza);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _rb.AddTorque(giro); //Hace girar un grado hacia la izquierda
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _rb.AddTorque(-giro); // Hace girar un grado hacia la derecha
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Roca"))
        {
            SceneManager.LoadScene("Nave");
        }
    }
}
