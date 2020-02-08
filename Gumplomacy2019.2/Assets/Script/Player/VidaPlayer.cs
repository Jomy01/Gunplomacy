using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaPlayer : MonoBehaviour
{
    public static int maxVida = 6;
    public static int currentVida = 6;
    int currentVidaInformation;

    public List<Image> spriteVidas;
    public Sprite tanque_lleno;
    public Sprite tanque_medio;
    public Sprite tanque_vacio;

    // Start is called before the first frame update
    void Start()
    {
        foreach(Image spriteVida in spriteVidas){
            spriteVida.sprite = tanque_lleno;
        }
        currentVidaInformation = currentVida;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            restaVida(1);
        }
        if(currentVidaInformation != currentVida)
        {
            currentVidaInformation = currentVida;
            UpdateVidaUI();
        }
    }

    // called when the cube hits the floor
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.tag == "enemigo" || col.collider.tag == "boss")
        {
            if(col.collider.tag == "enemigo")
            {
                restaVida(1);
            }
            else
            {
                restaVida(2);
            }
        }
    }

    void UpdateVidaUI()
    {
        switch (currentVida)
        {
            case 6:
                spriteVidas[2].sprite = tanque_lleno;
                break;
            case 5:
                spriteVidas[2].sprite = tanque_medio;
                break;
            case 4:
                spriteVidas[2].sprite = tanque_vacio;
                spriteVidas[1].sprite = tanque_lleno;
                break;
            case 3:
                spriteVidas[1].sprite = tanque_medio;
                break;
            case 2:
                spriteVidas[1].sprite = tanque_vacio;
                spriteVidas[0].sprite = tanque_lleno;
                break;
            case 1:
                spriteVidas[0].sprite = tanque_medio;
                break;
            case 0:
                spriteVidas[0].sprite = tanque_vacio;
                break;
        }
    }

    void restaVida(int num)
    {
        currentVida -= num;
        if (currentVida <= 0)
        {
            GameOverMenu.isGameOver = true;
            gameObject.SetActive(false);
        }
    }
}
