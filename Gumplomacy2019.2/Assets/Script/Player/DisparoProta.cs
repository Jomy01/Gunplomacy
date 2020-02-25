using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoProta : MonoBehaviour
{
    Armas armaEquipada;
    bool puedoDisparar = true;
    GestionEter eter;



    private void Awake()
    {
        Debug.Log("DisparoProta");
        eter = gameObject.GetComponent<GestionEter>();
        armaEquipada = GetComponent<CogerSoltarArma>().armaPrincipal;
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (puedoDisparar && hasEter())
            {
                armaEquipada.Disparar();
                eter.ControlEter(armaEquipada.consumoEter, armaEquipada.raza);
                puedoDisparar = false;
                Invoke("PuedoDisparar", armaEquipada.cadencia);
            }
        }
    }

    void PuedoDisparar()
    {
        puedoDisparar = true;
    }

    bool hasEter()
    {
        bool can = false;
        switch (armaEquipada.raza)
        {
            case "Botaniclos":
                if (eter.sliderBotaniclos.value > Mathf.Abs(armaEquipada.consumoEter))
                {
                    can = true;
                }
                break;
            case "Mutanos":
                if (eter.sliderMutanos.value > Mathf.Abs(armaEquipada.consumoEter))
                {
                    can = true;
                }
                break;
            case "Mecanos":
                if (eter.sliderMecanos.value > Mathf.Abs(armaEquipada.consumoEter))
                {
                    can = true;
                }
                break;
            case "Ictioniclos":
                if (eter.sliderIctioniclos.value > Mathf.Abs(armaEquipada.consumoEter))
                {
                    can = true;
                }
                break;
        }
        return can;
    }
}
