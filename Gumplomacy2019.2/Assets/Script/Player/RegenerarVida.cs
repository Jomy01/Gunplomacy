using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenerarVida : MonoBehaviour
{
    public static float secondsToHeal = 1f;
    public static float increaseSpeedToHeal = 0.1f;

    bool isCoroutineStarted = false;

    // Update is called once per frame
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
        while (Input.GetKey(KeyCode.E) && VidaPlayer.currentVida != VidaPlayer.maxVida)
        {
            yield return new WaitForSeconds(secondsToHeal);
            secondsToHeal -= increaseSpeedToHeal;
            VidaPlayer.currentVida++;
            //Disminuir numero de balas con cada recuperacion

            Debug.Log("Vida: " + VidaPlayer.currentVida);
        }
        isCoroutineStarted = false;
    }
}
