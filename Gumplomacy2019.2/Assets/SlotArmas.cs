using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotArmas : MonoBehaviour
{
    public static Image armaPrincipal;
    public static Image armaSecundaria;

    // Start is called before the first frame update
    void Awake()
    {
        armaPrincipal = GameObject.Find("Arma_principal").GetComponent<Image>();
        armaSecundaria = GameObject.Find("Arma_secundaria").GetComponent<Image>();
    }

    public static void cambiaArmas()
    {
        Sprite spriteArmaPrincipal = armaPrincipal.sprite;
        armaPrincipal.sprite = armaSecundaria.sprite;
        armaSecundaria.GetComponent<Image>().sprite = spriteArmaPrincipal;
    }

    public static void nuevaArma(Sprite nuevaArma)
    {
        armaPrincipal.sprite = nuevaArma;
    }

    public static void nuevasArmas(Sprite nuevaArmaPrincipal, Sprite nuevaArmaSecundaria)
    {
        armaPrincipal.sprite = nuevaArmaPrincipal;
        armaSecundaria.sprite = nuevaArmaSecundaria;
    }
}
