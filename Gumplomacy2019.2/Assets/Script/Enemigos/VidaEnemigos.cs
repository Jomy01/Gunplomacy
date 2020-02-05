using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigos : MonoBehaviour
{
    public float vidaEnemigo = 1000;
    public float vidaEnemigoActual;
    public int golpe = 0;
    public Transform origenParticulas;


    public ParticleSystem _particulasMuerte;

    // Start is called before the first frame update
    void Start()
    {
        vidaEnemigoActual = vidaEnemigo;

    }

    private void OnCollisionEnter2D(Collider collision)
    {
       RecibeDaño(golpe);
    }

    //Para Testeo
    //private void Update()
    //{
    //    RecibeDaño(golpe);
    //}

    public void RecibeDaño(int daño)
    {
        vidaEnemigoActual -= daño;

        if (vidaEnemigoActual <= 0)
        {
            Muerte();
        }
    }

    void Muerte()
    {
        Instantiate<ParticleSystem>(_particulasMuerte, origenParticulas.position, origenParticulas.rotation);
        _particulasMuerte.Play();
        Destroy(gameObject);
    }
}