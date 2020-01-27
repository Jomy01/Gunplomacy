using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// este escrip se modificará con el tiempo, ahora tendremos un drop aleatorio de 5 objetos los cuales
/// 1 saldrá con un 50% de posiblidades 3 saldrán con 15% y 1 con un 5% 
/// Hecho por jose antonio 20/01 v.1
/// </summary>
public class Drop : MonoBehaviour
{
    public GameObject[5] objetos;
    public bool drop;
    int numeroAleatorio;


    void Update()
    {
        if(drop)
        {
            numeroAleatorio = Random.Range(0, 100);
            if(numeroAleatorio <= 50)
            {
                Instantiate(objetos[1], transform.position, Quaternion.identity);
            }
            if (numeroAleatorio > 50 && numeroAleatorio < 65)
            {
                Instantiate(objetos[2], transform.position, Quaternion.identity);
            }
            if (numeroAleatorio >= 65 && numeroAleatorio < 80)
            {
                Instantiate(objetos[3], transform.position, Quaternion.identity);
            }
            if (numeroAleatorio >= 80 && numeroAleatorio < 95)
            {
                Instantiate(objetos[4], transform.position, Quaternion.identity);
            }
            if (numeroAleatorio >= 95 && numeroAleatorio < 100)
            {
                Instantiate(objetos[5], transform.position, Quaternion.identity);
            }
        }
    }
}
