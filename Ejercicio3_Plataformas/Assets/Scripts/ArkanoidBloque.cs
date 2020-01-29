using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArkanoidBloque : MonoBehaviour
{
    public int vida = 1;
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Pelota"))
        {
            vida--;
            if(vida<=0)
            {
                Destroy(gameObject);
            }
        }
    }
}
