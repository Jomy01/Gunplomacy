using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luz : MonoBehaviour
{
    public float segEspera = 2;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.enabled = false;
        StartCoroutine(DelayedAnimation());

    }


    IEnumerator DelayedAnimation()
    {
        yield return new WaitForSeconds(segEspera);
        animator.enabled = true;
        animator.Play("Luz Fundida");
    }
}
