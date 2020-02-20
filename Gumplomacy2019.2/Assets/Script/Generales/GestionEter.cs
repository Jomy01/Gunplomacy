using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GestionEter : MonoBehaviour
{
    /// <summary>
    /// Script para que funcionen los sliders del hud del éter
    /// Hecho por Ignacio Moreno
    /// </summary>
    //Slider para el eter de los mutanos
    public Slider sliderMutanos;
    //Slider para el eter de los mecanos
    public Slider sliderMecanos;
    //Slider para el eter de los botaniclos
    public Slider sliderBotaniclos;
    //Slider para el eter de los ictioniclos
    public Slider sliderIctioniclos;

    // Start is called before the first frame update
    void Start()
    {
        //Se buscan los sliders en la escena con sus nombres
        sliderMutanos = GameObject.Find("EterMutano").GetComponent<Slider>();
        sliderMecanos = GameObject.Find("EterMecano").GetComponent<Slider>();
        sliderBotaniclos = GameObject.Find("EterBotaniclo").GetComponent<Slider>();
        sliderIctioniclos = GameObject.Find("EterIctioniclo").GetComponent<Slider>();
        //Se inicializan a cero
        sliderMutanos.value = 150;
        sliderMecanos.value = 150;
        sliderBotaniclos.value = 150;
        sliderIctioniclos.value = 150;
    }

    /// <summary>
    /// Esta funcion actualiza el eter en pantalla, recibe el valor que rellena el eter y el tag del objeto recogido como argumento
    /// </summary>
    public void ControlEter(int eterValue, string type)
    {
        switch(type)
        {
            case "EterBotaniclos":
                sliderBotaniclos.value += eterValue;
                break;
            case "EterMutanos":
                sliderMutanos.value += eterValue;
                break;
            case "EterMecanos":
                sliderMecanos.value += eterValue;
                break;
            case "EterIctioniclos":
                sliderIctioniclos.value += eterValue;
                break;
        }
        
    }

}
