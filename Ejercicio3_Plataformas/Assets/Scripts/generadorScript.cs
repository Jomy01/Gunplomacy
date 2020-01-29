using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generadorScript : MonoBehaviour
{
    public GameObject[] asteroide;
    public float timepoEspera = 3;
    Vector3 posicion;
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Time.time > timer)
        {
            posicion = new Vector3(transform.position.x + Random.Range(-7, 7), transform.position.y, 0);
            Instantiate(asteroide[Random.Range(0,asteroide.Length)], posicion, transform.rotation);
            timer = Time.time + timepoEspera;
        }
    }
}
