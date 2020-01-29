using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cajaMonedas : MonoBehaviour
{
    public GameObject moneda;
    Transform _posSalida;
    public int monedas = 2;
    Animator _anim;
    public Sprite cajaVacia;
    SpriteRenderer _sp;

    // Start is called before the first frame update
    void Start()
    {
        _posSalida = transform.Find("Salida").transform;
        //Esto es porque la animacion la tiene el padre
        _anim = transform.parent.GetComponent<Animator>();
        _sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        //Aqui guardamos el prefab de la moneda que hemos creado
        GameObject _nuevaMoneda;
        //Fuerza que vamos a aplicar a la moneda
        Vector2 fuerza = new Vector2(Random.Range(-100, 100), 200);
        if(collision.transform.CompareTag("Player"))
        {
            _anim.SetTrigger("Activar");
            if(monedas>0)
            {
                _nuevaMoneda = Instantiate(moneda, _posSalida.position, _posSalida.rotation);
                _nuevaMoneda.GetComponent<Rigidbody2D>().AddForce(fuerza);
                monedas--;
            }
            else
            {
                _sp.sprite = cajaVacia;
            }
        }
    }
}
