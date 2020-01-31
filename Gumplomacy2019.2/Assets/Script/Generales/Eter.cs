using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eter : MonoBehaviour
{
    /// <summary>
    /// Cada eter llevará un tag para cada uno de ellos para indicar de que raza es cada uno
    /// EterMutanos si es de la raza mutanos
    /// EterMecanos si es de la raza mecanos
    /// EterIctioniclos si es de la raza ictioniclos
    /// EterBotaniclos si es de la raza botaniclos
    /// TODO Es necesario actualizar el nombre de donde se consigue la GestionEter
    /// </summary>

    [Tooltip("Indica cuanto éter rellena cada célula")]
    public int eterValue = 1;
    GestionEter gestionEter;

    private void Start()
    {
       gestionEter = GameObject.Find("gameController").GetComponent<GestionEter>();
    }

    /// <summary>
    /// Cuando el jugador pasa por encima del eter, este se destruye
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            gestionEter.ControlEter(eterValue,transform.tag);
            Destroy(gameObject);
        }
    }
}

