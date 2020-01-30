using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaOrientacionEnemigos : MonoBehaviour
{
    public Transform player;
    public ComandanteIA scripIaComandante;
    public SpriteRenderer spriteEnemigo;

    void Update()
    {
        if (scripIaComandante.detectandoPlayer)
        {
            transform.right = player.position - transform.position;
        }
        else if (!scripIaComandante.detectandoPlayer)
        {
            if(spriteEnemigo.flipX)
            {
                transform.rotation = new Quaternion(0, 0, -180, 0);
            }
            if (!spriteEnemigo.flipX)
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);
            }
        }

    }
}

