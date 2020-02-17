using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_Impurity : MonoBehaviour
{
    public GameObject OrbeRoratorio;
    public float velocidadRotacion;

    bool creandoOrbe;
    Transform pivotOrbe;
    VidaEnemigos vida;
    Vector3 posicion1;
    Vector3 posicion2;
    Vector3 posicion3;
    Vector3 posicion4;

    private void Awake()
    {
        pivotOrbe = transform.GetChild(0).GetComponent<Transform>();
        vida = GetComponent<VidaEnemigos>();
    }
    void Start()
    {
        pivotOrbe.localRotation = Quaternion.Euler(0, 0, 0);

        posicion1 = new Vector3(pivotOrbe.position.x + 0.77f * 3, pivotOrbe.position.y, pivotOrbe.position.z);
        posicion2 = new Vector3(pivotOrbe.position.x, pivotOrbe.position.y + 0.77f * 3, pivotOrbe.position.z);
        posicion3 = new Vector3(pivotOrbe.position.x - 0.77f * 3, pivotOrbe.position.y, pivotOrbe.position.z);
        posicion4 = new Vector3(pivotOrbe.position.x, pivotOrbe.position.y - 0.77f * 3, pivotOrbe.position.z);

        Instantiate(OrbeRoratorio, posicion2, Quaternion.identity, pivotOrbe);
        Instantiate(OrbeRoratorio, posicion4, Quaternion.identity, pivotOrbe);
    }

    // Update is called once per frame
    void Update()
    {
        RotacionOrbes();
        CreacionOrbes();
    }
    void RotacionOrbes()
    {
        if(!creandoOrbe)
        {
            pivotOrbe.RotateAround(pivotOrbe.position, Vector3.forward, velocidadRotacion * Time.deltaTime);
        }
        if (creandoOrbe)
        {
            pivotOrbe.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
    void CreacionOrbes()
    {
        if(vida.vidaEnemigoActual < vida.vidaEnemigoActual/2)
        {
            NuevoOrbe(posicion1);
        }
        if(vida.vidaEnemigoActual < vida.vidaEnemigoActual / 4)
        {
            NuevoOrbe(posicion3);
        }
    }
    void NuevoOrbe(Vector3 posicion)
    {
        creandoOrbe = true;
        Instantiate(OrbeRoratorio, posicion, Quaternion.identity, pivotOrbe);
        Invoke("ActivarRotacion", 1f);
    }
    void ActivarRotacion()
    {
        creandoOrbe = false;
    }
}
