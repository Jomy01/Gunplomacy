using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_mode : MonoBehaviour
{
    int _fuselaje = 0;
    int _motor = 0;
    int _navegacion = 0;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("mejoras_fuselaje", _fuselaje);
        PlayerPrefs.SetInt("mejoras_motor", _motor);
        PlayerPrefs.SetInt("mejoras_navegacion", _navegacion);
        PlayerPrefs.SetInt("fuselaje", 0);
        PlayerPrefs.SetInt("motor", 0);
        PlayerPrefs.SetInt("navegacion", 0);
    }

    public void SetMejorasFuselaje()
    {
        if (_fuselaje < 2)
        {
            _fuselaje++;
            PlayerPrefs.SetInt("mejoras_fuselaje", _fuselaje);
            Debug.Log(_fuselaje);
            Debug.Log(_motor);
            Debug.Log(_navegacion);
        }
    }

    public void SetMejorasMotor()
    {
        if (_motor < 2)
        {
            _motor++;
            PlayerPrefs.SetInt("mejoras_motor", _motor);
            Debug.Log(_fuselaje);
            Debug.Log(_motor);
            Debug.Log(_navegacion);
        }
    }

    public void SetMejorasNavegacion()
    {
        if (_navegacion < 2)
        {
            _navegacion++;
            PlayerPrefs.SetInt("mejoras_navegacion", _navegacion);
            Debug.Log(_fuselaje);
            Debug.Log(_motor);
            Debug.Log(_navegacion);
        }
    }

    public void DeleteAll()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log(_fuselaje);
        Debug.Log(_motor);
        Debug.Log(_navegacion);
        _fuselaje = 0;
        _motor = 0;
        _navegacion = 0;
    }

}
