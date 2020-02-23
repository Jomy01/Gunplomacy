using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotArmas : MonoBehaviour
{
    public static Sprite armaPrincipal;
    public static Sprite armaSecundaria;

    // Start is called before the first frame update
    void Start()
    {
        armaPrincipal = GameObject.Find("Arma_principal").GetComponent<Sprite>();
        armaSecundaria = GameObject.Find("Arma_secundaria").GetComponent<Sprite>();
    }

    public static void cambiaArmas()
    {
        Sprite spriteArmaPrincipal = armaPrincipal;
        armaPrincipal = armaSecundaria;
        armaSecundaria = spriteArmaPrincipal;
    }

    public static void nuevaArma(Sprite nuevaArma)
    {
        armaPrincipal = nuevaArma;
    }

    public static void nuevasArmas(Sprite nuevaArmaPrincipal, Sprite nuevaArmaSecundaria)
    {
        armaPrincipal = nuevaArmaPrincipal;
        armaSecundaria = nuevaArmaSecundaria;
    }
}
