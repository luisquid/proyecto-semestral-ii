using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarObstaculos : MonoBehaviour
{
	/*
	 * Este script sirve para generar objetos que llamamos "Obstáculos", estos objetos causan un
	 * GAME OVER si el jugador los toca.
	 * Nota: La lógica del objeto que se genera, se encuentra en el script MoverObstaculo.cs
	 */

	public GameObject[] obstaculos; //Array de todos los obstáculos que pueden generarse
	public float frecuencia; //Con qué frecuencia aparecen los obstáculos
	private float temporizador; //Lleva la cuenta regresiva para saber si se debe de generar otro objeto
	private Vector2 posicionObstaculo; //Posición donde se generará el obstáculo
	
    void Start()
    {
	    posicionObstaculo.y = 10f; //Altura a la que aparecen los objetos
	    temporizador = frecuencia; //Inicializar el temporizador
    }

	//Update chido
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
				temporizador = frecuencia; //Reinicia el contador
			}
		}
		#endregion
	}

	//Genera un objeto aleatorio "Obstaculo" del array de recompensas en una posición aleatoria en X
	private void Generar()
    {
		posicionObstaculo.x = Random.Range(-3.0f, 3.0f); //Coordenada en X donde se va a generar
		int randObst = Random.Range(0, obstaculos.Length); //Elige un objeto del array para generarlo
		Instantiate(obstaculos[randObst], posicionObstaculo, Quaternion.identity); //Instanciar el objeto
	}
}
