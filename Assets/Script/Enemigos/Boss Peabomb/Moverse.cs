using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// IA del comandante
/// Hecho por Jose Antonio Diaz 30/01
/// Editado Por Miguel
/// </summary>
public class Moverse : MonoBehaviour
{
    [Tooltip("Velocidad a la que se mueve el enemigo")]
    public float velocidad;
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

    Vector3 posicionInicial;
    Animator MyAnimator;
    public SpriteRenderer MySprite;
    DisparoIAEnemiga scriptDisparo;

    float target;

    void Start()
    {
        posicionInicial = transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        MyAnimator = GetComponent<Animator>();
        MySprite = GetComponent<SpriteRenderer>();
        scriptDisparo = GetComponent<DisparoIAEnemiga>();
    }

    // Update is called once per frame
    void Update()
    {
        DetectarPlayer();
        Flip();
        if (detectandoPlayer)
        {
            target = player.position.x;
            scriptDisparo.Disparar();
            Movimiento();
        }
        if (!detectandoPlayer)
        {
            target = posicionInicial.x;
            MovimientoInicio();
            scriptDisparo.DejarDeDisparar();
        }
    }
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
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, vision);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, distanciaRetirada);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, distanciaStop);
    }
    void Flip()
    {
        if (target > transform.position.x)
        {
            MySprite.flipX = false;
        }
        if (target < transform.position.x)
        {
            MySprite.flipX = true;
        }
    }
    void Movimiento()
    {
        //Persigue
        if (Vector2.Distance(transform.position, player.position) > distanciaStop)
        {
            MyAnimator.SetBool("Iddle", true);
            transform.position = Vector2.MoveTowards(transform.position, player.position, velocidad * Time.deltaTime);
        }
        //Hulle
        else if (Vector2.Distance(transform.position, player.position) < distanciaRetirada)
        {
            MyAnimator.SetBool("Iddle", true);
            transform.position = Vector2.MoveTowards(transform.position, player.position, -velocidad * Time.deltaTime);
        }
        //Para
        else
        {
            MyAnimator.SetBool("Iddle", false);
        }
    }

    void MovimientoInicio()
    {
        MyAnimator.SetBool("Iddle", true);
        transform.position = Vector2.MoveTowards(transform.position, posicionInicial, velocidad * Time.deltaTime);
        float distanciaPuntoInicil = Vector3.Distance(transform.position, posicionInicial);
        if (distanciaPuntoInicil <= 1f)
        {
            MyAnimator.SetBool("Iddle", false);
        }
    }
}
