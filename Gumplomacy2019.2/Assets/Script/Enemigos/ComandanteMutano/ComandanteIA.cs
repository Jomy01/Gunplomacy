using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComandanteIA : MonoBehaviour
{
    public float velocidad;
    public float distanciaStop;
    public float distanciaRetirada;
    public bool detectandoPlayer;
    public float vision;
    public float vida;
    public bool atacando;


    Animator MyAnimator;
    SpriteRenderer MySprite;
    public Transform player;
    DisparoIAEnemiga scriptDisparo;



    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        MyAnimator = GetComponent<Animator>();
        MySprite = GetComponent<SpriteRenderer>();
        scriptDisparo = GetComponent<DisparoIAEnemiga>();
    }

    // Update is called once per frame
    void Update()
    {
        DetectarPlayer();
        Vida();
        if (detectandoPlayer)
        {
            scriptDisparo.Disparar();
            Movimiento();
            Flip();
        }
        if (!detectandoPlayer)
        {
            MyAnimator.SetBool("Corriendo", false);
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
        if (player.position.x > transform.position.x)
        {
            MySprite.flipX = false;
        }
        if (player.position.x < transform.position.x)
        {
            MySprite.flipX = true;
        }
    }

    void Atacando()
    {

    }
    void Movimiento()
    {
        if (Vector2.Distance(transform.position, player.position) > distanciaStop)
        {
            MyAnimator.SetBool("Corriendo", true);
            transform.position = Vector2.MoveTowards(transform.position, player.position, velocidad * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < distanciaRetirada)
        {
            MyAnimator.SetBool("Corriendo", true);
            transform.position = Vector2.MoveTowards(transform.position, player.position, -velocidad * Time.deltaTime);
        }
        else
        {
            MyAnimator.SetBool("Corriendo", false);
        }
    }

    void Vida()
    {
        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("balaProta"))
        {
            vida = vida - 1;
        }
    }
}
