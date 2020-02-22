using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour
{
    CircleCollider2D Ccollider;
    public int daño = 3;
    private void Start()
    {
        Ccollider = GetComponent<CircleCollider2D>();
    }

    void ActivarColider()
    {
        Ccollider.enabled = true;
    }

    void Destrir()
    {
        Destroy(gameObject);
    }
}
