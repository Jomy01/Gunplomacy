using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoProta : MonoBehaviour
{
    public Armas scripArma;
    bool puedoDisparar = true;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(puedoDisparar)
            {
                scripArma.Disparar();
                puedoDisparar = false;
                Invoke("PuedoDisparar", scripArma.cadencia);
            }
        }
    }

    void PuedoDisparar()
    {
        puedoDisparar = true;
    }
}
