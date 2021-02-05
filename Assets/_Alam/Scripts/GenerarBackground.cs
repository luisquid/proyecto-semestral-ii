using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarBackground : MonoBehaviour
{
	/*
	 *Este script genera manchas en el background para simular el oceano
	 * Nota: La lógica del objeto que se genera, se encuentra en el script MoverObstaculo.cs
	 */

	public GameObject[] prefabsManchas; //Array de todos los obstáculos que pueden generarse
	public float frecMinSpawn, frecMaxSpawn; //Rango de tiempo en el que pueden hacer spawn

	private float temporizador; //Lleva la cuenta regresiva para saber si se debe de generar otro objeto
	private Vector2 posicionObstaculo; //Posición donde se generará el obstáculo

	void Start()
	{
		//Generar dos manchas cuando recién inicia
		Generar(Random.Range(-2f, 0f));
		Generar(Random.Range(1f, 3f));
		temporizador = 0f;
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
				Generar(10f); //Genera los prefabs en una altura de 10f en Y
				temporizador = Random.Range(frecMinSpawn, frecMaxSpawn); //Reinicia el contador con un valor basado en el tiempo de juego
			}
		}
		#endregion
	}

	//Genera un objeto aleatorio del array de prefabs en una posición aleatoria en X
	private void Generar(float _posY)
	{
		posicionObstaculo.y = _posY; //Altura a la que aparecen los objetos
		posicionObstaculo.x = Random.Range(-2.7f, 2.7f); //Coordenada en X donde se va a generar
		int randObst = Random.Range(0, prefabsManchas.Length); //Elige un objeto del array para generarlo
		GameObject go = Instantiate(prefabsManchas[randObst], posicionObstaculo, Quaternion.identity); //Instanciar el objeto
		go.transform.localScale = Vector2.one * Random.Range(1f, 5f); //Aumenta la escala del objeto de manera uniforme
		go.transform.rotation = Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f));
	}

}
