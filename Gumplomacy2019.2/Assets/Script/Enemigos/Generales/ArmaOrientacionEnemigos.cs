using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Scrip generico para los enemigos que hará que el arma apunte al prota y cuando no tenga detectado al prota tenga una posición 
/// dependiendo el flipX del enemigo, este scrip está reutilizado de la demo, preguntar duda a Pedro
///Hecho por Jose Antonio Diaz 30/01
///</summary>

public class ArmaOrientacionEnemigos : MonoBehaviour
{
    [Tooltip("Ponemos al player aquí, el arma seguira a este objetivo")]
    public Transform player;
    [Tooltip("Colocamos el scrip de la IA del enemigo aquí")]
    public SoldadoReclutaIA scripIASolRec;
    [Tooltip("Colocamos el SpriteRenderer del enemigo aquí")]
    public SpriteRenderer spriteEnemigo;

    bool flippedX = false;
    bool flippedY = false;

    bool volverInicio;

    Vector3 target;
    Quaternion posicionInicial;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        scripIASolRec = GetComponentInParent<SoldadoReclutaIA>();
        spriteEnemigo = GetComponentInParent<SpriteRenderer>();
        posicionInicial = transform.rotation;
    }
    void Update()
    {
        //Si el player está detectado
        if (scripIASolRec.detectandoPlayer)
        {
            volverInicio = true;
            if(volverInicio)
            {
                if(spriteEnemigo.flipX)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                if(!spriteEnemigo.flipX)
                {
                    transform.localScale = new Vector3(-1, -1, 1);
                }
                volverInicio = false;
            }

            target = player.position;

            float AnguloRadianes = Mathf.Atan2(transform.position.y - target.y, transform.position.x - target.x);

            float AnguloGrados = (180 / Mathf.PI) * AnguloRadianes;


            transform.rotation = Quaternion.Euler(0, 0, AnguloGrados);
            CorrectRotationWeaponAxisX();
            CorrectRotationWeaponAxisY(AnguloGrados);
        }
        else
        {
            transform.rotation = posicionInicial;
            volverInicio = true;
            if (spriteEnemigo.flipX)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }

    void CorrectRotationWeaponAxisX()
    {
        if (!scripIASolRec.mSr.flipX && !flippedX)
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

