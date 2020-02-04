using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MejorarNave : MonoBehaviour
{
    /// <summary>
    /// Script para que se pueda mejorar la nave del juego
    /// Hecho por Ignacio Moreno
    /// </summary>
    [Tooltip("Sprite de la primera mejora del navegacion")]
    public Sprite mejoraNavegacion1;
    [Tooltip("Sprite de la segunda mejora del navegacion")]
    public Sprite mejoraNavegacion2;
    [Tooltip("Sprite de la tercera mejora del navegacion")]
    public Sprite mejoraNavegacion3;
    [Tooltip("Sprite de la primera mejora del motor")]
    public Sprite mejoraMotor1;
    [Tooltip("Sprite de la segunda mejora del motor")]
    public Sprite mejoraMotor2;
    [Tooltip("Sprite de la tercera mejora del motor")]
    public Sprite mejoraMotor3;
    [Tooltip("Sprite de la primera mejora del fuselaje")]
    public Sprite mejoraFuselaje1;
    [Tooltip("Sprite de la segunda mejora del fuselaje")]
    public Sprite mejoraFuselaje2;
    [Tooltip("Sprite de la tercera mejora del fuselaje")]
    public Sprite mejoraFuselaje3;

    [Tooltip("Sprite de la receta de la primera mejora del navegacion")]
    public Sprite recetaMejoraNavegacion1;
    [Tooltip("Sprite de la receta de la segunda mejora del navegacion")]
    public Sprite recetaMejoraNavegacion2;
    [Tooltip("Sprite de la receta de la primera mejora del motor")]
    public Sprite recetaMejoraMotor1;
    [Tooltip("Sprite de la receta de la segunda mejora del motor")]
    public Sprite recetaMejoraMotor2;
    [Tooltip("Sprite de la receta de la primera mejora del fuselaje")]
    public Sprite recetaMejoraFuselaje1;
    [Tooltip("Sprite de la receta de la segunda mejora del fuselaje")]
    public Sprite recetaMejoraFuselaje2;

    //botones en el hud
    Button botonFuselaje;
    Button botonMotor;
    Button botonNavegacion;
    //imagenes de los botones
    Image imagenBotonFuselaje;
    Image imageBotonMotor;
    Image imageBotonNavegacion;

    //objetos en la escena
    GameObject fuselaje;
    SpriteRenderer[] fuselajes;
    SpriteRenderer motor;
    SpriteRenderer navegacion;

    //playerPrefs
    int _fuselaje;

    int _mejoraFuselaje;

    // Start is called before the first frame update
    void Start()
    {
        //se inicializan todos los distintos objetos
        botonFuselaje = GameObject.Find("boton fuselaje").GetComponent<Button>();
        botonMotor = GameObject.Find("boton motor").GetComponent<Button>();
        botonNavegacion = GameObject.Find("boton navegacion").GetComponent<Button>();

        imagenBotonFuselaje = GameObject.Find("boton fuselaje").GetComponent<Image>();
        imageBotonMotor = GameObject.Find("boton motor").GetComponent<Image>();
        imageBotonNavegacion = GameObject.Find("boton navegacion").GetComponent<Image>();

        fuselaje = GameObject.Find("fuselaje");
        fuselajes = fuselaje.GetComponentsInChildren<SpriteRenderer>();

        motor = GameObject.Find("motor").GetComponent<SpriteRenderer>();
        navegacion = GameObject.Find("navegacion").GetComponent<SpriteRenderer>();

        _fuselaje = PlayerPrefs.GetInt("fuselaje");
        _mejoraFuselaje = PlayerPrefs.GetInt("mejoras_fuselaje");

        EstadoFuselaje();

    }


     void EstadoFuselaje()
    {
        switch (_fuselaje)
        {
            case 0:
                for(int i = 0; i < fuselajes.Length; i++)
                {
                    fuselajes[i].sprite = mejoraFuselaje1;
                }
                break;
            case 1:
                for (int i = 0; i < fuselajes.Length; i++)
                {
                    fuselajes[i].sprite = mejoraFuselaje2;
                }
                break;
            case 2:
                for (int i = 0; i < fuselajes.Length; i++)
                {
                    fuselajes[i].sprite = mejoraFuselaje3;
                }
                break;
        }

    }

    void EstadoBotonFuselaje()
    {
        switch (_mejoraFuselaje)
        {
            case 0:
                botonFuselaje.interactable = false;
                imagenBotonFuselaje.sprite = recetaMejoraFuselaje1;
                break;
            case 1:
                botonFuselaje.interactable = true;
                imagenBotonFuselaje.sprite = recetaMejoraFuselaje1;
                break;
            case 2:
                imagenBotonFuselaje.sprite = recetaMejoraFuselaje2;
                if(_fuselaje == _mejoraFuselaje)
                {
                    botonFuselaje.interactable = false;
                }
                break;


        }
    }
    public void BotonFuselaje()
    {
        _mejoraFuselaje = PlayerPrefs.GetInt("mejoras_fuselaje");
        _fuselaje = _mejoraFuselaje;
        EstadoFuselaje();
        PlayerPrefs.SetInt("fuselaje",_fuselaje);
        Debug.Log(_mejoraFuselaje);
    }

    private void Update()
    {
        _mejoraFuselaje = PlayerPrefs.GetInt("mejoras_fuselaje");
        EstadoBotonFuselaje();
    }



}
