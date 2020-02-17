using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmaLuz : MonoBehaviour
{
    Light luz;
    // Start is called before the first frame update
    void Start()
    {
        luz = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if(AlarmaGlobal.alarma)
        {
            luz.color = Color.red;
        }
    }
}
