using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmasJugador : MonoBehaviour
{
    //Contiene las dos armas que poseera el jugador durante la partida
    public GameObject armaPrincipal;
    public GameObject armaSecundaria;
    bool armaCerca = false;
    GameObject armaSuelo;
    bool hasArmaSecundaria = false;

    public Transform _mano;
    public Transform _pivot;

    // Start is called before the first frame update
    void Start()
    {
        SlotArmas.nuevaArma(armaPrincipal.GetComponent<SpriteRenderer>().sprite);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.mouseScrollDelta.y != 0)
        {
            cambiaArma();
        }
        if (armaCerca && Input.GetKeyUp(KeyCode.Q) )
        {
            
            cogerArmaDelSuelo(armaSuelo);
        }
    }

    void cambiaArma()
    {
        if (hasArmaSecundaria)
        {
            Debug.Log("Cambia arma");
            GameObject arma = Instantiate(armaPrincipal);

            intercambiarValoresArma(armaPrincipal, armaSecundaria);

            intercambiarValoresArma(armaSecundaria, arma);

            SlotArmas.cambiaArmas();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Arma")
        {
            armaCerca = true;
            armaSuelo = collision.gameObject;
           
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Arma")
        {
            armaCerca = false;
            armaSuelo = null;

        }
    }

    void cogerArmaDelSuelo(GameObject armaNueva)
    {
        if(!hasArmaSecundaria)
        {
            intercambiarValoresArma(armaSecundaria, armaNueva);

            hasArmaSecundaria = true;
            Destroy(armaNueva);
        }
        else
        {
            GameObject arma = Instantiate(armaPrincipal);
            intercambiarValoresArma(armaPrincipal, armaNueva);

            intercambiarValoresArma(armaNueva, arma);
        }
        SlotArmas.nuevasArmas(armaPrincipal.GetComponent<SpriteRenderer>().sprite, armaSecundaria.GetComponent<SpriteRenderer>().sprite);
    }

    void intercambiarValoresArma(GameObject armaBase, GameObject armaNueva)
    {
        armaBase.GetComponent<SpriteRenderer>().sprite = armaNueva.GetComponent<SpriteRenderer>().sprite;

        armaBase.GetComponent<BoxCollider2D>().size = armaNueva.GetComponent<BoxCollider2D>().size;

        armaBase.GetComponent<Armas>().cadencia = armaNueva.GetComponent<Armas>().cadencia;
        armaBase.GetComponent<Armas>().daño = armaNueva.GetComponent<Armas>().daño;
        armaBase.GetComponent<Armas>().raza = armaNueva.GetComponent<Armas>().raza;
        armaBase.GetComponent<Armas>().consumoEter = armaNueva.GetComponent<Armas>().consumoEter;
    }
}

