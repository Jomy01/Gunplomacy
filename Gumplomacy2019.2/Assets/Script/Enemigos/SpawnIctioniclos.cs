using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIctioniclos : MonoBehaviour
{
    public GameObject[] ictioniclos;
    public float tiempoespera = 3;

    Vector3 posicion;

    float timer = 0;

    void Update()
    {
        if (Time.time > timer)
        {
            posicion = new Vector3(transform.position.x + Random.Range(-12, 12), transform.position.y + Random.Range(-12, 12));
            Instantiate(ictioniclos[0], posicion, transform.rotation);
            posicion = new Vector3(transform.position.x + Random.Range(-12, 12), transform.position.y + Random.Range(-12, 12));
            Instantiate(ictioniclos[1], posicion, transform.rotation);
            
            timer = Time.time + tiempoespera;
        }
    }

}
