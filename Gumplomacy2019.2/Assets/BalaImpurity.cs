using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaImpurity : MonoBehaviour
{
    public Transform player;
    Rigidbody2D mRb;
    public float velocidad;


    public int daño;
    Vector3 targer;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        mRb = GetComponent<Rigidbody2D>();
    }

    public void Persecucion_Player()
    {
        transform.parent = null;

        targer = player.position - transform.position;
        mRb.velocity = targer * velocidad * Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
