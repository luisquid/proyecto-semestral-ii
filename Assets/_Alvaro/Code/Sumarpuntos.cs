using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sumarpuntos : MonoBehaviour //Alvaro
{
    GameObject Personaje;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Recompensa_20")) 
        {
            Puntos.puntoCero += 20;
            Destroy(collision.gameObject);
        
        }
    }
}
