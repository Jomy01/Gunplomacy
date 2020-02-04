using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldadoReclutaIA : MonoBehaviour
{
    Rigidbody2D mRb;
    SpriteRenderer mSr;

    [Tooltip("Velocidad a la que se mueve el enemigo mientras te persigue")]
    public float velocidad;
    [Tooltip("Velocidad a la que se mueve el enemigo mientras patrulla")]
    public float velocidadPatrulla;
    [Tooltip("Distancia a la que el personaje se para delante del player")]
    public float distanciaStop;
    [Tooltip("Distancia a la que el enemigo empieza a huir del player")]
    public float distanciaRetirada;
    [Tooltip("Booleano que nos dice si el player a sido detectado")]
    public bool detectandoPlayer;
    [Tooltip("Tango de vision de detección del player")]
    public float vision;
    [Tooltip("Ponemos el player")]
    public Transform player;

    public Transform[] puntosDeGuardia;
    bool heLlegado = false;

    DisparoIAEnemiga scriptDisparo;

    void Start()
    {
        mRb = GetComponent<Rigidbody2D>();
        mSr = GetComponent<SpriteRenderer>();
        scriptDisparo = GetComponent<DisparoIAEnemiga>();
    }

    void Update()
    {
        DetectarPlayer();
        if(!detectandoPlayer)
        {
            Patrullando();
        }
        if(detectandoPlayer)
        {
            //scriptDisparo.Disparar();
            Movimiento();
            Flip();
        }
    }

    void Patrullando()
    {
        int puntoGuardia = 0;
        Vector3 siguientePunto = puntosDeGuardia[puntoGuardia].position;
        float distancia = Vector2.Distance(transform.position, siguientePunto);
        if (distancia > 0.5f)
        {
            transform.position = Vector2.MoveTowards(transform.position, siguientePunto, velocidadPatrulla * Time.deltaTime);
        }
        else
        {
            puntoGuardia++;
            siguientePunto = puntosDeGuardia[puntoGuardia].position;
            distancia = Vector2.Distance(transform.position, siguientePunto);
        }
        if(puntoGuardia == puntosDeGuardia.Length)
        {
            puntoGuardia = 0;
        }
        Debug.Log(distancia);
    }
    /// <summary>
    /// Detectaremos al player comparando la distancia que hay entre el enemigo y el player y usando la visión, esto activará un booleano para activar el estado de èrsecución.
    /// </summary>
    void DetectarPlayer()
    {
        if (Vector2.Distance(transform.position, player.position) < vision)
        {
            detectandoPlayer = true;
        }
        else if (Vector2.Distance(transform.position, player.position) > vision)
        {
            detectandoPlayer = false;
        }
    }
    /// <summary>
    /// Simplemente nos dibuja circulos en la interfat de uniti para ver la distancia de la visión, la retirada...
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, vision);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, distanciaRetirada);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, distanciaStop);
    }

    /// <summary>
    /// Hace flip al sprite según donde este el player, aciendo así quede mirando hacia el siempre que lo tenga detectado
    /// </summary>
    void Flip()
    {
        if (player.position.x > transform.position.x)
        {
            mSr.flipX = false;
        }
        if (player.position.x < transform.position.x)
        {
            mSr.flipX = true;
        }
    }
    /// <summary>
    /// Utilizamos todas las distancias declaradas para hacer que nos siga, que hulla o que esté quieto
    /// </summary>
    void Movimiento()
    {
        //Persigue
        if (Vector2.Distance(transform.position, player.position) > distanciaStop)
        {
            //MyAnimator.SetBool("Corriendo", true);
            transform.position = Vector2.MoveTowards(transform.position, player.position, velocidad * Time.deltaTime);
        }
        //Hulle
        else if (Vector2.Distance(transform.position, player.position) < distanciaRetirada)
        {
            //MyAnimator.SetBool("Corriendo", true);
            transform.position = Vector2.MoveTowards(transform.position, player.position, -velocidad * Time.deltaTime);
        }
        //Para
        else
        {
            //MyAnimator.SetBool("Corriendo", false);
        }
    }
}
