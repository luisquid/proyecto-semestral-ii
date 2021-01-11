using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sumarpuntos : MonoBehaviour //Alvaro
{
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        #region AGREGAR O RESTAR PUNTOS DE RECOMPENSAS
        if (collision.gameObject.CompareTag("Recompensa_10")) 
        {
            puntos.puntoCero += 10;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Recompensa_20"))
        {
            puntos.puntoCero += 20;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Deuda_5"))
        {
            puntos.puntoCero -= 50;
            //Si se le restan más puntos de los necesarios, para que no quedé en negativo
            if (puntos.puntoCero < 0)
                puntos.puntoCero = 0;
            Destroy(collision.gameObject);
        }
        #endregion
    }
}
