using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoVida : MonoBehaviour
{
    public int vidas = 1;
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("bala"))
        {
            vidas--;
            if(vidas==0)
            {
                //Aqui tendriamos que activar la animacion de muerte
                // Crear un sistema de particulas y destruirlo a los X segundos
                Destroy(gameObject);
            }
        }
    }
   
}
