using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoDamage : MonoBehaviour
{
    public int damage = 1;
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Enemy"))
        {
            GameController.copia.RestaVida();
        }
    }
}
