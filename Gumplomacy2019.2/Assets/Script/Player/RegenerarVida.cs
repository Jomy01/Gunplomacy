using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenerarVida : MonoBehaviour
{
    public static float secondsToHeal = 1f;
    public static float increaseSpeedToHeal = 0.1f;
    public static int eterConsumed = -25;
    public static string razaEter = "EterMutanos";

    bool isCoroutineStarted = false;
    GestionEter eter;

    private void Start()
    {
        eter = gameObject.GetComponent<GestionEter>();
    }
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isCoroutineStarted)
        {
            isCoroutineStarted = true;
            StartCoroutine(heal());
        }
    }

    IEnumerator heal()
    {
        while (Input.GetKey(KeyCode.E) && VidaPlayer.currentVida != VidaPlayer.maxVida && canHeal())
        {
            yield return new WaitForSeconds(secondsToHeal);
            secondsToHeal -= increaseSpeedToHeal;
            VidaPlayer.currentVida++;
            //Disminuir numero de balas con cada recuperacion
            eter.ControlEter(eterConsumed, razaEter);
        }
        isCoroutineStarted = false;
    }

    bool canHeal()
    {
        bool can = false;
        switch (razaEter)
        {
            case "EterBotaniclos":
                if(eter.sliderBotaniclos.value > Mathf.Abs(eterConsumed))
                {
                    can = true;
                }
                break;
            case "EterMutanos":
                if (eter.sliderMutanos.value > Mathf.Abs(eterConsumed))
                {
                    can = true;
                }
                break;
            case "EterMecanos":
                if (eter.sliderMecanos.value > Mathf.Abs(eterConsumed))
                {
                    can = true;
                }
                break;
            case "EterIctioniclos":
                if (eter.sliderIctioniclos.value > Mathf.Abs(eterConsumed))
                {
                    can = true;
                }
                break;
        }
        return can;
    }
}
