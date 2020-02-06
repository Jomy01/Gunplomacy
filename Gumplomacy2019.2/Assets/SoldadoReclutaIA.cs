using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldadoReclutaIA : MonoBehaviour
{
    Rigidbody2D mRb;
    public SpriteRenderer mSr;
    Animator mA;

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
    
    int puntoGuardia = 0;
    Vector3 siguientePunto;
    float distancia;
    public int delayPatrulla;
    bool actualizandoPunto = false;

    DisparoIAEnemiga scriptDisparo;
    float target;

    void Start()
    {
        mRb = GetComponent<Rigidbody2D>();
        mSr = GetComponent<SpriteRenderer>();
        scriptDisparo = GetComponent<DisparoIAEnemiga>();
        mA = GetComponent<Animator>();
    }

    void Update()
    {
        DetectarPlayer();
        if(!detectandoPlayer && !actualizandoPunto)
        {
            Patrullando();
            Flip();
        }
        if(detectandoPlayer)
        {
            scriptDisparo.Disparar();
            Movimiento();
            Flip();
        }
    }

    void Patrullando()
    {
        scriptDisparo.DejarDeDisparar();
        siguientePunto = puntosDeGuardia[puntoGuardia].position;
        distancia = Vector2.Distance(transform.position, siguientePunto);
        target = siguientePunto.x;
        if (distancia > 0.5f)
        {
            mA.SetBool("Corriendo", true);
            transform.position = Vector2.MoveTowards(transform.position, siguientePunto, velocidadPatrulla * Time.deltaTime);
        }
        else
        {
            mA.SetBool("Corriendo", false);
            actualizandoPunto = true;
            Invoke("ActualizarPuntoGuardia", delayPatrulla);
        }
    }

    void ActualizarPuntoGuardia()
    {
        puntoGuardia++;
        if (puntoGuardia == puntosDeGuardia.Length)
        {
            puntoGuardia = 0;
        }
        siguientePunto = puntosDeGuardia[puntoGuardia].position;
        distancia = Vector2.Distance(transform.position, siguientePunto);
        actualizandoPunto = false;
    }
    /// <summary>
    /// Detectaremos al player comparando la distancia que hay entre el enemigo y el player y usando la visión, esto activará un booleano para activar el estado de èrsecución.
    /// </summary>
    void DetectarPlayer()
    {
        target = player.position.x;
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
        if (target > transform.position.x)
        {
            mSr.flipX = false;
        }
        if (target < transform.position.x)
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
            mA.SetBool("Corriendo", true);
            transform.position = Vector2.MoveTowards(transform.position, player.position, velocidad * Time.deltaTime);
        }
        //Hulle
        else if (Vector2.Distance(transform.position, player.position) < distanciaRetirada)
        {
            mA.SetBool("Corriendo", true);
            transform.position = Vector2.MoveTowards(transform.position, player.position, -velocidad * Time.deltaTime);
        }
        //Para
        else
        {
            mA.SetBool("Corriendo", false);
        }
    }
}
