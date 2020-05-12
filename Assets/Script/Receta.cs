using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receta : MonoBehaviour
{
        public string nombrePlayerPref;
        public int playerPref = 0;


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {            
                PlayerPrefs.SetInt(nombrePlayerPref, playerPref);
                Destroy(gameObject);
            }
        }
    }
