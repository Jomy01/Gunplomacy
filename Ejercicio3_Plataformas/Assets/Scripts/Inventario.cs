using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public static Inventario copia; //Para poder acceder desde cualquier script

    //Variables para saber si tenemos alguna llave
    bool llaveVerde = false;
    bool llaveNaranja = false;
    bool llaveAzul = false;

    //Animator de las tres llaves para poder mostrar en la UI
    Animator _animNaranja;
    Animator _animVerde;
    Animator _animAzul;

    // Start is called before the first frame update
    void Start()
    {
        copia = this;
        //Buscamos los objetos de la UI y extraemos su Animator
        //Tnemos que usar los nombres de los objetos en la escena
        _animAzul = GameObject.Find("LLaveAzulUI").GetComponent<Animator>();
        _animNaranja = GameObject.Find("LLaveNaranjaUI").GetComponent<Animator>();
        _animVerde = GameObject.Find("LLaveVerdeUI").GetComponent<Animator>();
    }

    /// <summary>
    /// Le pasamos el nombre de la llave para activar su animacion en la UI
    /// y activar el bool en el inventario.
    /// </summary>
    /// <param name="color">Nombre de la llave</param>
    public void CogeLLave(string color)
    {
        if(color=="LLaveNaranja")
        {
            llaveNaranja = true;
            _animNaranja.SetBool("Activa", true);
        }
        if (color == "LLaveAzul")
        {
            llaveAzul = true;
            _animAzul.SetBool("Activa", true);
        }
        if (color == "LLaveVerde")
        {
            llaveVerde = true;
            _animVerde.SetBool("Activa", true);
        }
    }
    public bool PuedoUsarLaLLave(Puerta.ColorLLave llave)
    {
        bool puedoUsar = false; //Esta variable me dice si puedo abrir la puerta

        switch(llave) //Consultamos el valor de llave
        {
            case Puerta.ColorLLave.azul: //si es azul
                if(llaveAzul) // vemos si tenemos esa llave
                { // Si tenemos la llave podemos usarla
                    puedoUsar = true; 
                }
                break;

            case Puerta.ColorLLave.verde:
                if (llaveVerde)
                {
                    puedoUsar = true;
                }
                break;
            case Puerta.ColorLLave.naranja:
                if (llaveNaranja)
                {
                    puedoUsar = true;
                }
                break;
        }
        return puedoUsar;
    }
}
