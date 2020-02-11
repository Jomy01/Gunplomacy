using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_mode : MonoBehaviour
{
    public int fuselaje = 0;
    public int motor = 0;
    public int navegacion = 0;

    public int startFujelaje = 0;
    public int startMotor = 0;
    public int startNavegacion = 0;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("mejoras_fuselaje", fuselaje);
        PlayerPrefs.SetInt("mejoras_motor", motor);
        PlayerPrefs.SetInt("mejoras_navegacion", navegacion);
        PlayerPrefs.SetInt("fuselaje", startFujelaje);
        PlayerPrefs.SetInt("motor", startMotor);
        PlayerPrefs.SetInt("navegacion", startNavegacion);
    }

    public void SetMejorasFuselaje()
    {
        if (fuselaje < 2)
        {
            fuselaje++;
            PlayerPrefs.SetInt("mejoras_fuselaje", fuselaje);
            Debug.Log(fuselaje);
            Debug.Log(motor);
            Debug.Log(navegacion);
        }
    }

    public void SetMejorasMotor()
    {
        if (motor < 2)
        {
            motor++;
            PlayerPrefs.SetInt("mejoras_motor", motor);
            Debug.Log(fuselaje);
            Debug.Log(motor);
            Debug.Log(navegacion);
        }
    }

    public void SetMejorasNavegacion()
    {
        if (navegacion < 2)
        {
            navegacion++;
            PlayerPrefs.SetInt("mejoras_navegacion", navegacion);
            Debug.Log(fuselaje);
            Debug.Log(motor);
            Debug.Log(navegacion);
        }
    }

    public void DeleteAll()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log(fuselaje);
        Debug.Log(motor);
        Debug.Log(navegacion);
        fuselaje = 0;
        motor = 0;
        navegacion = 0;
    }

}
