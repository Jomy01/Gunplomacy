using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIctioniclos : MonoBehaviour
{
    public GameObject[] ictioniclos;
    public float tiempoespera = 3;

    Vector3 posicion;

    float timer = 1;

    void Update()
    {
        if (Time.time > timer)
        {
            posicion = new Vector3((transform.position.x), transform.position.y + Random.Range(-1, 1));
            Instantiate(ictioniclos[0], posicion, transform.rotation);
            posicion = new Vector3((transform.position.x), transform.position.y + Random.Range(-1, 1));
            Instantiate(ictioniclos[1], posicion, transform.rotation);
            posicion = new Vector3((transform.position.x), transform.position.y + Random.Range(-1, 1));
            Instantiate(ictioniclos[2], posicion, transform.rotation);

            timer = Time.time + tiempoespera;
        }
    }

}
