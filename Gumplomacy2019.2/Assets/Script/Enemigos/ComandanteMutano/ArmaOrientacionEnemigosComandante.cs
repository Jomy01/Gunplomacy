using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Scrip generico para los enemigos que hará que el arma apunte al prota y cuando no tenga detectado al prota tenga una posición 
/// dependiendo el flipX del enemigo, este scrip está reutilizado de la demo, preguntar duda a Pedro
///Hecho por Jose Antonio Diaz 30/01
///</summary>

public class ArmaOrientacionEnemigosComandante : MonoBehaviour
{
    [Tooltip("Ponemos al player aquí, el arma seguira a este objetivo")]
    public Transform player;
    [Tooltip("Colocamos el scrip de la IA del enemigo aquí")]
    public ComandanteIA scripIaComandante;
    [Tooltip("Colocamos el SpriteRenderer del enemigo aquí")]
    public SpriteRenderer spriteEnemigo;

    bool flippedX = false;
    bool flippedY = false;

    Vector3 target;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }
    void Update()
    {
        //Si el player está detectado
        if (scripIaComandante.detectandoPlayer)
        {
            target = player.position;

            float AnguloRadianes = Mathf.Atan2(transform.position.y - target.y, transform.position.x - target.x);

            float AnguloGrados = (180 / Mathf.PI) * AnguloRadianes;


            transform.rotation = Quaternion.Euler(0, 0, AnguloGrados);
            CorrectRotationWeaponAxisX();
            CorrectRotationWeaponAxisY(AnguloGrados);
        }
    }

    void CorrectRotationWeaponAxisX()
    {
        if (!scripIaComandante.MySprite.flipX && !flippedX)
        {
            flippedX = true;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    void CorrectRotationWeaponAxisY(float AnguloGrados)
    {
        if (Mathf.Abs(AnguloGrados) > 90f && !flippedY)
        {
            Vector3 theScale = transform.localScale;
            theScale.y *= -1;
            transform.localScale = theScale;
            flippedY = true;
        }
        else if (Mathf.Abs(AnguloGrados) <= 90f && flippedY)
        {
            Vector3 theScale = transform.localScale;
            theScale.y *= -1;
            transform.localScale = theScale;
            flippedY = false;
        }
    }
}

