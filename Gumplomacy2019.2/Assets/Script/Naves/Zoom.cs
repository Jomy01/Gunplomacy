using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    Vector3 posInicialNave;
    Vector3 posInicialCam;
    public Camera Cam;
    float sizeOriginal;
    public GameObject cExit;
    public static bool zoom = false;

    private void Start()
    {
        posInicialNave = transform.localScale;
        sizeOriginal = Cam.GetComponent<Camera>().orthographicSize;
        posInicialCam = Cam.transform.position;
    }
    private void OnMouseOver()
    {
        if (!zoom) { 
        transform.localScale = new Vector3(10, 10, 0);
            
        }
      
    }
    private void OnMouseExit()
    {
        transform.localScale = posInicialNave;
    }
    private void OnMouseDown()
    {
        cExit.SetActive(true);
        transform.localScale = posInicialNave;
        Cam.transform.position = new Vector3(transform.position.x + 1.5f, transform.position.y, -10);
        Cam.GetComponent<Camera>().orthographicSize = 1.25f;
        zoom = true;
    }

    public void Atras()
    {

        zoom = false;
        Cam.transform.position = posInicialCam;
        Cam.GetComponent<Camera>().orthographicSize = sizeOriginal;
        cExit.SetActive(false);
    }
}
