using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// script genérico para reproducri los sonidos de cualqueir enemigo
/// Cuenta con un rango de detección para ejecutar el sonido de respirar
/// </summary>
public class AudioEnemy : MonoBehaviour
{

    //duplicar la línea de sonidoAtaque si el enemigo tiene más de un ataque
    public AudioClip sonidoAtaque;
   // public AudioClip sonidoMovimiento;
    public AudioClip sonidoMuerte;
    public AudioClip sonidoRespirar;

    AudioSource _sourceEnemy;

    bool _ejecutandoSonido = false;
    bool _playercerca = false;
    public bool detectandoPlayer;

    public Transform player;

    public float rangoDeteccion;

    //creamos una copia static del script para poder acceder a él
    public static AudioEnemy copia;

    // Start is called before the first frame update
    void Start()
    {
        _sourceEnemy = GetComponent<AudioSource>();
        copia = this;
       // InvokeRepeating("SonidoRespirar", 3f, Random.Range(5f, 20f));
        player = GameObject.Find("Player").GetComponent<Transform>();

    }

    void Update()
    {
        DetectarPlayer();
        if (detectandoPlayer)
        {
            SonidoRespirar();
        }
    }

    public void SonidoAtaque()
    {
        //para cambiar el pitch
        // _sourceEnemy.pitch = Random.Range(0.8f, 1.2f);
        _sourceEnemy.PlayOneShot(sonidoAtaque);
        //dejamos el pitch a 1
        // _sourceEnemy.pitch = 1;
    }

    /// <summary>
    /// quitamos el sonido de movimiento ya que habrá demasiados enemigos ejecutando sus sonidos a la vez
    /// </summary>
   /* public void SonidoMovimiento()
    {
        //para cambiar el pitch
       // _sourceEnemy.pitch = Random.Range(0.8f, 1.2f);
        _sourceEnemy.PlayOneShot(sonidoMovimiento);
        //dejamos el pitch a 1
        //_sourceEnemy.pitch = 1;
    }*/

    public void SonidoMuerte()
    {
        _sourceEnemy.PlayOneShot(sonidoMuerte);

    }

    public void SonidoRespirar()
    {
        if (!_ejecutandoSonido)
        {

            _sourceEnemy.PlayOneShot(sonidoRespirar);

            _ejecutandoSonido = true;
            Invoke("VolverSonido", Random.Range(1, 5));
        }
    }

    void VolverSonido()
    {
        _ejecutandoSonido = false;
    }

    void DetectarPlayer()
    {

        if (Vector2.Distance(transform.position, player.position) < rangoDeteccion)
        {
            detectandoPlayer = true;
        }
        else if (Vector2.Distance(transform.position, player.position) > rangoDeteccion)
        {
            detectandoPlayer = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangoDeteccion);

    }
}