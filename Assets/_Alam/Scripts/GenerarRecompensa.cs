using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarRecompensa : MonoBehaviour
{
	/*
	 * Este script sirve para generar objetos que llamamos "Recompensa", cuando el jugador toca
	 * estos objetos, gana una cantidad de puntos en la partida, dependiendo del valor de la recompensa
	 * Nota: La lógica del objeto que se genera, se encuentra en el script MoverRecompensa.cs
	 */

	public GameObject[] recompensas; //Array de todos los obstáculos que pueden generarse
	public float frecuencia; //Con qué frecuencia aparecen los obstáculos
	private float temporizador; //Lleva la cuenta regresiva para saber si se debe de generar otro objeto
	private Vector2 posicionRecompensa; //Posición donde se generará el obstáculo

	void Start()
    {
	    posicionRecompensa.y = 10f; //Altura a la que aparecen los objetos
		temporizador = frecuencia; //Inicializar el temporizador
	}

    // Update is called once per frame
    void Update()
    {
		#region GENERAR EVENTO
		//Si no hay un evento activo, el temporizador sigue la cuenta regresiva hasta generar otro objeto
		if (!Evento.hayEvento)
		{
			temporizador -= Time.deltaTime; //Disminuye el temporizador

			//Cuando el temporizador llega a 0 se generará un objeto
			if (temporizador <= 0f)
			{
				Generar();
				temporizador = frecuencia;
			}
		}
        #endregion
    }

	//Genera un objeto aleatorio "Recompensa" del array de recompensas en una posición aleatoria en X
	public void Generar(){
		posicionRecompensa.x = Random.Range(-3.0f, 3.0f);
		int randObst = Random.Range(0, recompensas.Length);
		Instantiate(recompensas[randObst], posicionRecompensa, Quaternion.identity);
	}
	
	
}
