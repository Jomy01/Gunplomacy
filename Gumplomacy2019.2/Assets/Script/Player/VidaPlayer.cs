using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaPlayer : MonoBehaviour
{
    public int numVida = 6;

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

        numVida = spriteVidas.Count * 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            numVida--;
            if (numVida <= 0)
            {
                //GAME OVER
                //Crear escena o animacion equivalente para el game over
                gameObject.SetActive(false);
            }
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
                numVida--;
            }
            else
            {
                numVida = numVida - 2;
            }

            if(numVida <= 0)
            {
                //GAME OVER
                //Crear escena o animacion equivalente para el game over
                gameObject.SetActive(false);
            }
            UpdateVidaUI();
        }
    }

    void UpdateVidaUI()
    {
        switch (numVida)
        {
            case 5:
                spriteVidas[2].sprite = tanque_medio;
                break;
            case 4:
                spriteVidas[2].sprite = tanque_vacio;
                break;
            case 3:
                spriteVidas[1].sprite = tanque_medio;
                break;
            case 2:
                spriteVidas[1].sprite = tanque_vacio;
                break;
            case 1:
                spriteVidas[0].sprite = tanque_medio;
                break;
            case 0:
                spriteVidas[0].sprite = tanque_vacio;
                break;
        }
    }
}
