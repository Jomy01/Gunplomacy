using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// IA del comandante
/// Hecho por Jose Antonio Diaz 30/01
/// </summary>
public class ComandanteIA : MonoBehaviour
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
        if (target > transform.position.x)
        {
            MySprite.flipX = false;
        }
        if (target < transform.position.x)
        {
            MySprite.flipX = true;
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
            MyAnimator.SetBool("Corriendo", true);
            transform.position = Vector2.MoveTowards(transform.position, player.position, velocidad * Time.deltaTime);
        }
        //Hulle
        else if (Vector2.Distance(transform.position, player.position) < distanciaRetirada)
        {
            MyAnimator.SetBool("Corriendo", true);
            transform.position = Vector2.MoveTowards(transform.position, player.position, -velocidad * Time.deltaTime);
        }
        //Para
        else
        {
            MyAnimator.SetBool("Corriendo", false);
        }
    }

    void MovimientoInicio()
    {
        MyAnimator.SetBool("Corriendo", true);
        transform.position = Vector2.MoveTowards(transform.position, posicionInicial, velocidad * Time.deltaTime);
        float distanciaPuntoInicil = Vector3.Distance(transform.position, posicionInicial);
        if(distanciaPuntoInicil <= 1f)
        {
            MyAnimator.SetBool("Corriendo", false);
        }
    }
}
