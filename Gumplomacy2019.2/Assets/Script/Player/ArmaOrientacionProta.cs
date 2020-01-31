using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Atunpa nuestra pistola al cursor, este scrip está reutilizado de la demo, preguntar duda a Pedro
/// Hecho por Jose Antonio Diaz 30/01
/// </summary>
public class ArmaOrientacionProta : MonoBehaviour
{
    public Transform puntero;
    public MoviminetoPlayer movimientoPlayer;

    bool flippedX = false;
    bool flippedY = false;

    Vector3 target;
    void Update()
    {
        target = puntero.position;

        float AnguloRadianes = Mathf.Atan2(transform.position.y - target.y, transform.position.x - target.x);

        float AnguloGrados = (180 / Mathf.PI) * AnguloRadianes;


        transform.rotation = Quaternion.Euler(0, 0, AnguloGrados);
        CorrectRotationWeaponAxisX();
        CorrectRotationWeaponAxisY(AnguloGrados);
    }
    void CorrectRotationWeaponAxisX()
    {
        if (!movimientoPlayer.mSr.flipX && !flippedX)
        {
            flippedX = true;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    void CorrectRotationWeaponAxisY(float AnguloGrados)
    {
        if (Mathf.Abs(AnguloGrados) > 90f && !flippedY)
        {
            Vector3 theScale = transform.localScale;
            theScale.y *= -1;
            transform.localScale = theScale;
            flippedY = true;
        }
        else if (Mathf.Abs(AnguloGrados) <= 90f && flippedY)
        {
            Vector3 theScale = transform.localScale;
            theScale.y *= -1;
            transform.localScale = theScale;
            flippedY = false;
        }
    }
}
