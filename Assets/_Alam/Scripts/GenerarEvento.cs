using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarEvento : MonoBehaviour
{
	/*
	 * Este script sirve para generar objetos que llamamos "eventos", los cuales hacen que el jugador
	 * entre en un QUICK TIME EVENT al momento de tocar el objeto que genera este script.
	 * Nota: La lógica del objeto que se genera, se encuentra en el script MoverRecompensa.cs
	 */ 

	public GameObject evento; //Prefab del objeto que al ser tocado genera un "quick time event" 

	private float temporizador; //El tiempo que toma en generar cada evento
	private Vector2 posicionEvento; //La posición donde será generado

	void Start()
	{
		posicionEvento.y = 10f; //Lo posiciona fuera de la pantalla, en la parte superior
		temporizador = Random.Range(20f, 30f); //Inicializa el temporizador por primera vez (valor random)
	}

	// Update is called once per frame
	void Update()
	{
        #region GENERAR EVENTO
        //Si no hay un evento activo, el temporizador sigue la cuenta regresiva hasta generar otro evento
        if (!Evento.hayEvento)
		{
			temporizador -= Time.deltaTime; //Disminuye el temporizador
			if (temporizador <= 0f)
			{
				Generar();
				temporizador = Random.Range(40f, 60f);
			}
		}
		#endregion
	}

	//Genera un objeto "evento" en una posición aleatoria en X.
	public void Generar()
	{
		posicionEvento.x = Random.Range(-3.0f, 3.0f);
		Instantiate(evento, posicionEvento, Quaternion.identity);
	}

}
