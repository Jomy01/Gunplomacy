using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GestionEter : MonoBehaviour
{
    //Slider para el eter de los mutanos
    Slider sliderMutanos;
    //Slider para el eter de los mecanos
     Slider sliderMecanos;
    //Slider para el eter de los botaniclos
     Slider sliderBotaniclos;
    //Slider para el eter de los ictioniclos
     Slider sliderIctioniclos;

    // Start is called before the first frame update
    void Start()
    {
        sliderMutanos = GameObject.Find("SliderMutano").GetComponent<Slider>();
        sliderMecanos = GameObject.Find("SliderMecano").GetComponent<Slider>();
        sliderBotaniclos = GameObject.Find("SliderBotaniclo").GetComponent<Slider>();
        sliderIctioniclos = GameObject.Find("SliderIctioniclo").GetComponent<Slider>();
        sliderMutanos.value = 0;
        sliderMecanos.value = 0;
        sliderBotaniclos.value = 0;
        sliderIctioniclos.value = 0;
    }

    // Update is called once per frame

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
