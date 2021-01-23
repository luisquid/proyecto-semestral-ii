using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarObstaculos : MonoBehaviour//Alam
{
	/*
	 * Este script sirve para generar objetos que llamamos "Obstáculos", estos objetos causan un
	 * GAME OVER si el jugador los toca.
	 * Nota: La lógica del objeto que se genera, se encuentra en el script MoverObstaculo.cs
	 */

	public GameObject[] obstaculos; //Array de todos los obstáculos que pueden generarse
	private float temporizador; //Lleva la cuenta regresiva para saber si se debe de generar otro objeto
	public float frecuenciaMinDeSpawn; //Con qué frecuencia aparecen los obstáculos
	private Vector2 posicionObstaculo; //Posición donde se generará el obstáculo
	private puntos contadorTiempo; //Contiene el objeto que tiene el contador de puntos y tiempo
	private float tiempoTranscurrido; //Guarda el tiempo transcurrido desde que se empieza la partida


	void Start()
    {
		posicionObstaculo.y = 10f; //Altura a la que aparecen los objetos
		contadorTiempo = GameObject.FindGameObjectWithTag("Contador").GetComponent<puntos>(); //Encontrar el contador de puntos con el tag
	    temporizador = Random.Range(frecuenciaMinDeSpawn, FrecuenciaMaxDeSpawn()); //Inicializar el temporizador
    }

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
				temporizador = Random.Range(frecuenciaMinDeSpawn, FrecuenciaMaxDeSpawn()); //Reinicia el contador con un valor basado en el tiempo de juego
			}
		}
		#endregion
	}

	//Genera un objeto aleatorio "Obstaculo" del array de recompensas en una posición aleatoria en X
	private void Generar()
    {
		posicionObstaculo.x = Random.Range(-2.75f, 2.75f); //Coordenada en X donde se va a generar
		int randObst = Random.Range(0, obstaculos.Length); //Elige un objeto del array para generarlo
		Instantiate(obstaculos[randObst], posicionObstaculo, Quaternion.identity); //Instanciar el objeto
	}

	float FrecuenciaMaxDeSpawn()
    {
		tiempoTranscurrido = contadorTiempo.conteoTiempo;
		float frecuencia;

		if (tiempoTranscurrido <= 15f)
		{
			frecuencia = 1.75f;
		}
		else if (tiempoTranscurrido <= 30f)
		{
			frecuencia = 1.5f;
		}
		else if (tiempoTranscurrido <= 45f)
		{
			frecuencia = 1.4f;
		}
		else
		{
			frecuencia = 1f;
		}


		return frecuencia;
	}
}
