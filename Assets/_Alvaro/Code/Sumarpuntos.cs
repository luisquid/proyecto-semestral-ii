using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sumarpuntos : MonoBehaviour //Alvaro
{
    /*
     Asiganos valor a los puntos y restamos puntos esto de forma Play en el juego
     */

    public int valorPuntos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Alexander Lo manejo orientado por objetos ya que debe llevarlo el mismo  objeto
        if (collision.gameObject.CompareTag("Player"))
        {
            puntos.contadorPuntos += valorPuntos;

            if (puntos.contadorPuntos < 0)
                puntos.contadorPuntos = 0;

            Destroy(gameObject);

            
        }
    }
}
