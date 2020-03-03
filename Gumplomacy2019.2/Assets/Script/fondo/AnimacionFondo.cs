using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionFondo : MonoBehaviour
{
    public float velocidadDeFondo;
    Material miMaterial;

    void Start()
    {
        miMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        miMaterial.mainTextureOffset = miMaterial.mainTextureOffset + Vector2.right * velocidadDeFondo * Time.deltaTime;
    }
}
