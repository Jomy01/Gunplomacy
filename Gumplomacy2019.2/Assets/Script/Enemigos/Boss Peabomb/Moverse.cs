using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moverse : MonoBehaviour
{
    Rigidbody2D mRb;
    public SpriteRenderer mSr;
    Animator mA;

    [Tooltip("Velocidad a la que se mueve el enemigo")]
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
    

    Vector3 posicionInicial;
    Animator MyAnimator;
    public SpriteRenderer MySprite;
   
    float target;
    bool actualizandoPunto = false;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        mRb = GetComponent<Rigidbody2D>();
        mSr = GetComponent<SpriteRenderer>();
        
        mA = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        DetectarPlayer();
        if (!detectandoPlayer && !actualizandoPunto)
        {
            Patrullando();
            Flip();
        }
        if (detectandoPlayer)
        {
            
            Movimiento();
            Flip();
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
            MyAnimator.SetBool("Ataque", true);
            transform.position = Vector2.MoveTowards(transform.position, player.position, velocidad * Time.deltaTime);
        }
        //Hulle
        else if (Vector2.Distance(transform.position, player.position) < distanciaRetirada)
        {
            MyAnimator.SetBool("Ataque", true);
            transform.position = Vector2.MoveTowards(transform.position, player.position, -velocidad * Time.deltaTime);
        }
        //Para
        else
        {
            MyAnimator.SetBool("Ataque", false);
        }
    }

    void MovimientoInicio()
    {
        MyAnimator.SetBool("Ataque", true);
        transform.position = Vector2.MoveTowards(transform.position, posicionInicial, velocidad * Time.deltaTime);
        float distanciaPuntoInicil = Vector3.Distance(transform.position, posicionInicial);
        if (distanciaPuntoInicil <= 1f)
        {
            MyAnimator.SetBool("Ataque", false);
        }
    }
    void Patrullando()
    {

        siguientePunto = puntosDeGuardia[puntoGuardia].position;
        distancia = Vector2.Distance(transform.position, siguientePunto);
        target = siguientePunto.x;
        if (distancia > 0.5f)
        {
            mA.SetBool("Ataque", true);
            transform.position = Vector2.MoveTowards(transform.position, siguientePunto, velocidadPatrulla * Time.deltaTime);
        }
        else
        {
            mA.SetBool("Ataque", false);
            actualizandoPunto = true;
            Invoke("ActualizarPuntoGuardia", delayPatrulla);
        }
    }
}
