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
    /// </summary>

    [Tooltip("Indica cuanto éter rellena cada célula")]
    public int eterValue = 1;

    Collider2D _col;

    void Start()
    {
        _col = GetComponent<Collider2D>();   
    }

    /// <summary>
    /// Cuando el jugador pasa por encima del eter, este se destruye
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}

