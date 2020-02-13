using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zoom : MonoBehaviour
{ 
    //Añadido por ignacio para poder cargar niveles
    [Tooltip("Cada nave presentara un Id distinto para poder cargar el nivel correspondiente")]
    [Range(0, 11)]
    public int LevelId = 0;

    Vector3 posInicialNave;
    Vector3 posInicialCam;
    Vector3 posPanel;

    float sizeOriginal;
    //public Camera Cam;
    public Camera cam;

    //public GameObject cExit;
    //public GameObject Panel;
    public CanvasElements canvas;

    GameObject cExit;
    GameObject panel;

    public static bool zoom = false;

    [TextArea]
    public string textoNave;
    public Text textoPanel;

    private void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        canvas = GameObject.Find("CanvasAsalto").GetComponent<CanvasElements>();

        cExit = canvas.exit;
        panel = canvas.holo;
        



        posInicialNave = transform.localScale;
        sizeOriginal = cam.GetComponent<Camera>().orthographicSize;
        posInicialCam = cam.transform.position;
        posPanel = panel.transform.position;

    }
    private void OnMouseOver()
    {
        if (!zoom)
        { 
        transform.localScale = new Vector3(10, 10, 0); 
        }
      
    }
    private void OnMouseExit()
    {
        transform.localScale = posInicialNave;
    }
    private void OnMouseDown()
    {
        if (!zoom)
        {
            cExit.SetActive(true);
            panel.SetActive(true);
            zoom = true;

            AsaultManager.levelID = LevelId;

            canvas.texto.text = textoNave;

            transform.localScale = posInicialNave;
            cam.transform.position = new Vector3(transform.position.x + 1.5f, transform.position.y, -10);
            cam.GetComponent<Camera>().orthographicSize = 1.25f;
        }


    }

    public void Atras()
    {

        zoom = false;
        cam.transform.position = posInicialCam;
        cam.GetComponent<Camera>().orthographicSize = sizeOriginal;
        cExit.SetActive(false);
        panel.SetActive(false);

    }
}
