using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Hecho por Jose Antonio Diaz Llamas
/// 20/02/2020
/// Todabia no está terminado pero funciona
/// </summary>
public class RepartirPuntos : MonoBehaviour
{
    Transform[] puntos;

    public float xM , xm;
    public float yM, ym;

    float x;
    float y;

    int z = 1;

    float distanciaEntrePuntos;

    Vector3 posicionPuntos;
    Vector3 posicionPuntos2;
    Vector3 puntoN;
    Vector3 puntoA;
    void Start()
    {
        puntos = new Transform[transform.childCount];
        InvokeRepeating("rPuntos", 0, 10);
    }
    void rPuntos()
    {
        for (int i = 0; i < puntos.Length; i++)
        {
            puntos[i] = transform.GetChild(i);
            x = Random.Range(xm, xM + 1);
            y = Random.Range(ym, yM + 1);
            posicionPuntos = new Vector3(x, y, transform.position.z);
            puntos[i].localPosition = posicionPuntos;
            puntoN = puntos[i].localPosition;

            while (z <= i)
            {
                puntoA = puntos[z - 1].localPosition;
                distanciaEntrePuntos = Vector2.Distance(puntoN, puntoA);
                while (distanciaEntrePuntos < 10)
                {
                    x = Random.Range(xm, xM + 1);
                    y = Random.Range(ym, yM + 1);
                    posicionPuntos = new Vector3(x, y, transform.position.z);
                    puntos[i].localPosition = posicionPuntos;
                    puntoN = puntos[i].localPosition;
                    distanciaEntrePuntos = Vector2.Distance(puntoN, puntoA);
                    z = 1;
                }
                z++;
            }

        }
    }
    private void OnDrawGizmos()
    {
        for(int i = 0; i < puntos.Length; i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(puntos[i].position, 3);
        }
    }
}
