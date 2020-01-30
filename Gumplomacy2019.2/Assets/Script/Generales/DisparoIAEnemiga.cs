using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoIAEnemiga : MonoBehaviour
{
    public Armas arma;
    bool puedoDisparar = false;

    void Update()
    {
        if(puedoDisparar)
        {
            arma.Disparar();
        }
    }

    public void Disparar()
    {
        puedoDisparar = true;
    }

    public void DejarDeDisparar()
    {
        puedoDisparar = false;
    }
}
