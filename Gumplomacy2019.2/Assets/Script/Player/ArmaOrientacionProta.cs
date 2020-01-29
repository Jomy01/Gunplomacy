using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaOrientacionProta : MonoBehaviour
{
    public Transform puntero;

    void Update()
    {
        transform.right = puntero.position - transform.position;
    }
}
