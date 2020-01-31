using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigos : MonoBehaviour
{
    public float vidaEnemigo = 1000;
    public float vidaEnemigoActual;
    public int golpe = 0;
    Transform parent;

    public ParticleSystem _particulasMuerte;

    // Start is called before the first frame update
    void Start()
    {
        vidaEnemigoActual = vidaEnemigo;

    }

    private void Update()
    {
        RecibeDaño(golpe);
    }

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
        Instantiate<ParticleSystem>(_particulasMuerte, transform.position, transform.rotation);
        _particulasMuerte.Play();
        Destroy(gameObject);
    }
}