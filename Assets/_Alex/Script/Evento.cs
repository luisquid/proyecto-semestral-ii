using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Evento : MonoBehaviour //Alexander
{
    //Guarda el valor "true" cuando hay un evento activo (Quick time event)
    public static bool hayEvento = false; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si el objeto colisiona con el jugador, entonces añade la escena que tiene el Quick Time Event
        if (collision.CompareTag("Player"))
        {
            hayEvento = true;
            SceneManager.LoadScene("Evento",LoadSceneMode.Additive); //Añade la escena del Evento
        }
    }
}
