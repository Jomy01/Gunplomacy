using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D _rb;
    float _ejeX;
    float _ejeY;
    // ------ Para detectar el suelo -----//
    [Header("Detector Suelo")] 
    public bool _tocandoSuelo = false;

    [Tooltip("Capa con los objetos que se consideran cielo")]
    public LayerMask capaSuelo;
    public Transform pies;

    [Tooltip("Distancia a la que se detecta el suelo")]
    public float radio;
    [Space]
    // ------ Movimiento del Player -----//
    [Header("Movimiento")]
    public float velocidad = 5;
    public float fuerzaSalto = 6;
    [Space]
    // ------ Gestion de saltos -----//
    [Header("Salto")]
    public int numeroSaltos = 2;
    int _saltosDisponibles;

    // ------ Gestion de animacion -----//
    Animator _anim;
    bool miraDerecha = true;

    // ------ Sistema de particulas -----//
    ParticleSystem _particulasSuelo;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _saltosDisponibles = numeroSaltos;
        _anim = GetComponent<Animator>();
        //Accedemos al primer hijo con sistema de particulas y lo metemos en _particulasSuelo
        _particulasSuelo = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        //Me registra las teclas para el movimiento 
        _ejeX = Input.GetAxis("Horizontal");
        _ejeY = Input.GetAxis("Vertical");
        //Crea un circulo y si toca algo, te devuelve el true o false en caso contrario
        //Se le pasa por parametros(donde coloco el circulo, el radio, y con que tiene que tocar)
        _tocandoSuelo = Physics2D.OverlapCircle(pies.position,radio,capaSuelo);

        GestionSalto();
        //He puesto _rb.velocity.y en vez de ejeY para que la gravedad afecte al personaje
        //Le digo que coja la componente Y del rigidbody y de esa manera
        //El personaje cae cuando baja de una plataforma y no se queda flotando 
        //Solo aplicamos cambios al X. dejamos _rb.velocity.y en el eje Y para dejar que actue la gravedad 

        _rb.velocity = new Vector2(_ejeX * velocidad, _rb.velocity.y);

        GestionAnimaciones();
    }

    void GestionSalto()
    {
        //No hace falta ponerle llaves porque lleva una sola condicion
        if (_tocandoSuelo) _saltosDisponibles = numeroSaltos;

        if (Input.GetButtonDown("Jump") && _saltosDisponibles > 0)
        {
            _saltosDisponibles--;
            _rb.velocity = Vector2.up * fuerzaSalto;
            _anim.SetTrigger("Saltar");
            if (_tocandoSuelo) EmiteParticulas();
        }

    }
    //Para hacer que la emision de particulas se realice en el fotograma deseado, voy a animation gorundPlayer y en el fotograma que quiero 
    // que suelte las particulas, le doy a add event y le añado ésta función
    void EmiteParticulas()
    {
        _particulasSuelo.Play();
    }
    void GestionAnimaciones()
    {
        _anim.SetBool("enSuelo", _tocandoSuelo);
        _anim.SetFloat("Velocidad", Mathf.Abs(_rb.velocity.x));

        if (_ejeX < 0 && miraDerecha)
        {
            transform.Rotate(0, 180, 0);
            miraDerecha = false;
        } else if(_ejeX>0&&!miraDerecha)
        {
            transform.Rotate(0, 180, 0);
            miraDerecha = true;
        }
    }
}
