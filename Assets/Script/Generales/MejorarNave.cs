using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MejorarNave : MonoBehaviour
{
    /// <summary>
    /// Script para que se pueda mejorar la nave del juego
    /// Hecho por Ignacio Moreno el 11/02/2020
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

    //variables que van vinculadas a los PlayerPref
    int _fuselaje;
    int _mejoraFuselaje;
    int _motor;
    int _mejoraMotor;
    int _navegacion;
    int _mejoraNavegacion;

    public Text textoMejora;

    // Start is called before the first frame update
    void Start()
    {
        //se inicializan los botones del canvas
        botonFuselaje = GameObject.Find("boton fuselaje").GetComponent<Button>();
        botonMotor = GameObject.Find("boton motor").GetComponent<Button>();
        botonNavegacion = GameObject.Find("boton navegacion").GetComponent<Button>();
        //se inicializan las imagenes de los botones del canvas
        imagenBotonFuselaje = GameObject.Find("boton fuselaje").GetComponent<Image>();
        imageBotonMotor = GameObject.Find("boton motor").GetComponent<Image>();
        imageBotonNavegacion = GameObject.Find("boton navegacion").GetComponent<Image>();
        //se inicializan los sprites que estan presentes en la escenas, en el caso de los fuselajes, al haber 3, se toma el nombre de un objeto vacio con los sprites en los hijos
        fuselaje = GameObject.Find("fuselaje");
        fuselajes = fuselaje.GetComponentsInChildren<SpriteRenderer>();
        motor = GameObject.Find("motor").GetComponent<SpriteRenderer>();
        navegacion = GameObject.Find("navegacion").GetComponent<SpriteRenderer>();
        //se inicializa las variables que dependes del playerpref
        _fuselaje = PlayerPrefs.GetInt("fuselaje");
        _mejoraFuselaje = PlayerPrefs.GetInt("mejoras_fuselaje");
        _motor = PlayerPrefs.GetInt("motor");
        _mejoraMotor = PlayerPrefs.GetInt("mejoras_motor");
        _navegacion = PlayerPrefs.GetInt("navegacion");
        _mejoraNavegacion = PlayerPrefs.GetInt("mejoras_navegacion");
        //Se llaman a las funciones que actualizan los botones y la escena
        EstadoFuselaje();
        EstadoMotor();
        EstadoNavegacion();
        EstadoBotonFuselaje();
        EstadoBotonMotor();
        EstadoBotonNavegacion();
        TextoMejora();
        BloquePorMejora.nivelDeMejoras = PlayerPrefs.GetInt("nivelDeMejora");

    }

    /// <summary>
    /// Actualiza los sprites del fuselaje de la escena
    /// </summary>
     void EstadoFuselaje()
    {
        switch (_fuselaje)
        {
            //se elige uno de los tres casos para cambiar al sprite adecuado
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
    /// <summary>
    /// Actualiza los botones del fuselaje de la escena
    /// </summary>
    void EstadoBotonFuselaje()
    {
        //se desactiva el boton cuando el valor de receta sea el mismo que el valor de mejora
        if (_fuselaje == _mejoraFuselaje)
        {
            botonFuselaje.interactable = false;
        }
        //se elige uno de los tres casos para cambiar al sprite adecuado
        switch (_mejoraFuselaje)
        {
            case 0:
                imagenBotonFuselaje.sprite = recetaMejoraFuselaje1;
                break;
            case 1:
                imagenBotonFuselaje.sprite = recetaMejoraFuselaje1;
                break;
            case 2:
                imagenBotonFuselaje.sprite = recetaMejoraFuselaje2;
               
                break;


        }
    }

    /// <summary>
    /// Script Que se activa con el botón de fuselaje, sirve para igualar valores de player prefs, te guarda el estado de la nave y actualiza los sprites y botones del fuselaje
    /// </summary>
    public void BotonFuselaje()
    {
        TextoMejora();
        _mejoraFuselaje = PlayerPrefs.GetInt("mejoras_fuselaje");
        _fuselaje = _mejoraFuselaje;
        EstadoFuselaje();
        EstadoBotonFuselaje();
        PlayerPrefs.SetInt("fuselaje",_fuselaje);
        Debug.Log(_mejoraFuselaje);
        BloquePorMejora.nivelDeMejoras++;
        PlayerPrefs.SetInt("nivelDeMejora", BloquePorMejora.nivelDeMejoras);
    }
    /// <summary>
    /// Actualiza los sprites del motor de la escena
    /// </summary>
    void EstadoMotor()
    {
        //se elige uno de los tres casos para cambiar al sprite adecuado
        switch (_motor)
        {
            case 0:

                    motor.sprite = mejoraMotor1;
                
                break;
            case 1:
                
                    motor.sprite = mejoraMotor2;
                
                break;
            case 2:
                
                    motor.sprite = mejoraMotor3;
                
                break;
        }

    }
    /// <summary>
    /// Actualiza los botones del motor de la escena
    /// </summary>
    void EstadoBotonMotor()
    {
        //se desactiva el boton cuando el valor de receta sea el mismo que el valor de mejora
        if (_motor == _mejoraMotor)
        {
            botonMotor.interactable = false;
        }
        //se elige uno de los tres casos para cambiar al sprite adecuado
        switch (_mejoraMotor)
        {
            case 0:;
                imageBotonMotor.sprite = recetaMejoraMotor1;
                break;
            case 1:;
                imageBotonMotor.sprite = recetaMejoraMotor1;
                break;
            case 2:
                imageBotonMotor.sprite = recetaMejoraMotor2;
                
                break;


        }
    }
    /// <summary>
    ///  Script Que se activa con el botón de motor, sirve para igualar valores de player prefs, te guarda el estado de la nave y actualiza los sprites y botones del motor
    /// </summary>
    public void BotonMotor()
    {
        TextoMejora();
        _mejoraMotor = PlayerPrefs.GetInt("mejoras_motor");
        _motor = _mejoraMotor;
        EstadoMotor();
        EstadoBotonMotor();
        PlayerPrefs.SetInt("motor", _motor);
        Debug.Log(_mejoraMotor);
        BloquePorMejora.nivelDeMejoras++;
        PlayerPrefs.SetInt("nivelDeMejora", BloquePorMejora.nivelDeMejoras);
    }

    /// <summary>
    /// Actualiza los sprites de la navegacion de la escena
    /// </summary>
    void EstadoNavegacion()
    {
        //se elige uno de los tres casos para cambiar al sprite adecuado
        switch (_navegacion)
        {
            case 0:

                navegacion.sprite = mejoraNavegacion1;

                break;
            case 1:

                navegacion.sprite = mejoraNavegacion2;

                break;
            case 2:

                navegacion.sprite = mejoraNavegacion3;

                break;
        }

    }
    /// <summary>
    /// Actualiza los botones de la navegacion de la escena
    /// </summary>
    void EstadoBotonNavegacion()
    {
        //se desactiva el boton cuando el valor de receta sea el mismo que el valor de mejora
        if (_navegacion == _mejoraNavegacion)
        {
            botonNavegacion.interactable = false;
        }
        //se elige uno de los tres casos para cambiar al sprite adecuado
        switch (_mejoraNavegacion)
        {
            case 0:
                imageBotonNavegacion.sprite = recetaMejoraNavegacion1;
                break;
            case 1:               
                imageBotonNavegacion.sprite = recetaMejoraNavegacion1;
                break;
            case 2:
                imageBotonNavegacion.sprite = recetaMejoraNavegacion2;
                
                break;


        }
    }
    /// <summary>
    /// Script Que se activa con el botón de navegacion, sirve para igualar valores de player prefs, te guarda el estado de la nave y actualiza los sprites y botones de la navegacion
    /// </summary>
    public void BotonNavegacion()
    {
        TextoMejora();
        _mejoraNavegacion = PlayerPrefs.GetInt("mejoras_navegacion");
        _navegacion = _mejoraNavegacion;
        EstadoNavegacion();
        EstadoBotonNavegacion();
        PlayerPrefs.SetInt("navegacion", _navegacion);
        Debug.Log(_mejoraNavegacion);
        BloquePorMejora.nivelDeMejoras++;
        PlayerPrefs.SetInt("nivelDeMejora", BloquePorMejora.nivelDeMejoras);
    }

    //El update estaba para hacer debug, por que se necesitaba una actualizacion inmediata de los valores, pero en el juego no hace falta que sea asi

    private void Update()
    {
        _mejoraFuselaje = PlayerPrefs.GetInt("mejoras_fuselaje");
        EstadoBotonFuselaje();

        _mejoraMotor = PlayerPrefs.GetInt("mejoras_motor");
        EstadoBotonMotor();

        _mejoraNavegacion = PlayerPrefs.GetInt("mejoras_navegacion");
        EstadoBotonNavegacion();

        TextoMejora();
        Debug.Log(BloquePorMejora.nivelDeMejoras);
    }



    public void TextoMejora()
    {
        if (BloquePorMejora.nivelDeMejoras < 3)
        {
            textoMejora.text = "faltan " + (3 - BloquePorMejora.nivelDeMejoras) + " para siguiente nivel";
        }
        else if (BloquePorMejora.nivelDeMejoras < 6)
        {
            textoMejora.text = "faltan " + (6 - BloquePorMejora.nivelDeMejoras) + " para siguiente nivel";
        }
        else textoMejora.text = "nivel maximo de mejoras";
    }


}
