using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //<<<<---- Para reiniciar la escena o cambiar de nivel
//HAY QUE AÑADIR LA ESCENA AL BUILDING SETTINGS DENTRO DE FILE 
//Tambien puedo cambiarle el numero para ordenar las escenas como yo quiera 
using TMPro; // <<<<---- No olvidar para poder usar TextMeshPro

public class GameController : MonoBehaviour
{
    //static sirve para poder acceder a monedas desde cualquier sitio sin necesidad de GetComponent ni nada
    int monedas = 0;
    int diamantes = 0;
    int vidas = 3;
    
    //Preparamos una variable static del sistema tipo que este script para guardar una copia de si mismo
    public static GameController copia;

    public TextMeshProUGUI textMonedas;
    public TextMeshProUGUI textDiamantes;

    Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        //Busco el Gameobject con el nombre panelvidas y extraerle el componente animator
        //Esto no debe fallar a no ser que no encuentre el gameobject que debe buscar
        _anim = GameObject.Find("PanelVidas").GetComponent<Animator>();
        _anim.SetInteger("Vidas", vidas);

        //Preguntamos si no hemos hecho antes una copia del script
        if (copia==null)
        {
            copia = this; //Nos guardamos una copia del propio script
        }
    }

    public void SumaMonedas(int cantidad)
    {
        monedas += cantidad;
        textMonedas.text = monedas.ToString();
        // Ahora actualizaremos la UI
    }

    public void SumaDiamantes(int cantidad)
    {
        diamantes += cantidad;
        textDiamantes.text = diamantes.ToString();
    }

    public void RestaVida()
    {
        if(vidas>0) vidas--;

        //TO DO: Actualizar la UI
        
        Debug.Log(vidas);
        if(vidas<1)
        {
            Debug.Log("Has muerto matao!");
            SceneManager.LoadScene(0);
        }
        _anim.SetInteger("Vidas", vidas);
    }

    public void SumaVida()
    {
        if (vidas < 3) vidas++;
        else vidas = 3;
        _anim.SetInteger("Vidas", vidas);
    }
}
