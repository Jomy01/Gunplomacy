using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Scrip generico para los enemigos que hará que el arma apunte al prota y cuando no tenga detectado al prota tenga una posición dependiendo el flipX del enemigo
///Hecho por Jose Antonio Diaz 30/01
///</summary>
public class ArmaOrientacionEnemigos : MonoBehaviour
{
    [Tooltip("Ponemos al player aquí, el arma seguira a este objetivo")]
    public Transform player;
    [Tooltip("Colocamos el scrip de la IA del enemigo aquí")]
    public ComandanteIA scripIaComandante;
    [Tooltip("Colocamos el SpriteRenderer del enemigo aquí")]
    public SpriteRenderer spriteEnemigo;

    void Update()
    {
        //Si el player está detectado
        if (scripIaComandante.detectandoPlayer)
        {
            transform.right = player.position - transform.position;
        }
        //SI no detecta al player
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

