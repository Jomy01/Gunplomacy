using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEnemigos : MonoBehaviour
{
    float numeroRandom;

    GameObject player;

    public int numeroEnemigos;
    public GameObject[] enemigos;

    [Header("PROBABILIDAD")]
    public float Soldado;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<GameObject>();
    }
    private void Update()
    {
            DetectarPlayer();
    }

    void DetectarPlayer()
    {
        float distanciaAlPlayer;
        distanciaAlPlayer = Vector3.Distance(player.transform.position, transform.position);
        if (distanciaAlPlayer < 20)
        {
            GenerarEnemigoAhora();
        }
    }

    void GenerarEnemigoAhora()
    {
        for (int i = 0; i < numeroEnemigos; i++)
        {
            numeroRandom = Random.Range(0, 100);
            if (numeroRandom > 100 - Soldado)
            {
                Instantiate(enemigos[1], transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(enemigos[0], transform.position, Quaternion.identity);
            }
        }
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 20);
    }
}
