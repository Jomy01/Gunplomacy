using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzAleatoria : MonoBehaviour
{
    Light intensidad;

    float tiempoTranscurrido;
    float tiemporepeticiones = 0;
    float intensidadNueva;

    public float primerValorTiempo = 0.1f;
    public float segundoValorTiempo = 0.3f;

    void Start()
    {
        intensidad = GetComponent<Light>();
    }

    private void Update()
    {
        tiempoTranscurrido += Time.deltaTime;

        if (tiempoTranscurrido >= tiemporepeticiones)
        {
            tiemporepeticiones = Random.Range(primerValorTiempo, segundoValorTiempo);
            intensidadNueva = Random.Range(5.0f, 15.0f);
            tiempoTranscurrido = 0;
            RandomLigth();
        }
    }


    void RandomLigth()
    {
        if(intensidad.intensity > 0)
        {
            intensidad.intensity = 0;
        }
        else if(intensidad.intensity == 0)
        {
            intensidad.intensity = intensidadNueva;
        }
    }
}
