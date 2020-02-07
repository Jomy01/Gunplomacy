using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VidaProta : MonoBehaviour
{
    int vidas = 6;
    public Sprite[] spriteVidas;
    public Image imagenVida;

    private void Start()
    {
        imagenVida.sprite = spriteVidas[vidas];
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bala"))
        {
            int dañoBala = collision.gameObject.GetComponent<Bala>().daño;
            vidas = vidas - dañoBala; ;
            imagenVida.sprite = spriteVidas[vidas];
            if(vidas <= 0)
            {
                PausaEscena();
                //Muerte();
            }
        }
        if(collision.gameObject.CompareTag("Enemigo"))
        {
            vidas--;
            imagenVida.sprite = spriteVidas[vidas];
            if (vidas <= 0)
            {
                PausaEscena();
                Muerte();
            }
        }
    }
    void PausaEscena()
    {
        Time.timeScale = 0;
    }
    void Muerte()
    {
        Destroy(gameObject);
    }
}
