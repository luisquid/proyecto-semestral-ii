using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarObstaculos : MonoBehaviour
{
	public GameObject[] obstaculos; //Array de todos los obstáculos que pueden salir
	public float frecuencia; //Con qué frecuencia aparecen los obstáculos
	private float temporizador; //Lleva la cuenta regresiva para saber si se debe de generar otro objeto
	private Vector2 posicionObstaculo;
	
    void Start()
    {
	    //print("Hola buenas");
	    posicionObstaculo.y = 10f; //Altura a la que aparecen los objetos
	    temporizador = frecuencia; //Inicializar el temporizador
    }

	//Update chido
	void Update()
	{
		if (Evento.evento == false)
		{
			temporizador -= Time.deltaTime; //Disminuye el temporizador
											//Cuando el temporizador llega a 0 se generará un objeto
			if (temporizador <= 0f)
			{
				posicionObstaculo.x = Random.Range(-3.0f, 3.0f); //Coordenada en X donde se va a generar
				int randObst = Random.Range(0, obstaculos.Length); //Elige un objeto del array para generarlo
				Instantiate(obstaculos[randObst], posicionObstaculo, Quaternion.identity); //Instancía el objeto
				temporizador = frecuencia; //Reinicia el contador
			}
		}
	}
}
