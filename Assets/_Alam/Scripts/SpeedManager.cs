using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{
	/*
	 * Este script calcula la velocidad a la que deben de ir ciertos obstáculos, 
	 * basado en el tiempo de juego transcurrido
	 */

	public static float velocidadGlobal; //Velocidad a la que se mueve el obstáculo
	public float velocidadInicial;
	public float velExtraPorSegundo; //Es el extra de velocidad que se añadirá a la velocidad global cada cierto tiempo
	public float velocidadMaxima; //Es el tope de velocidad que los objetos pueden alcanzar

    void Start()
    {
		velocidadGlobal = velocidadInicial; //Con esta velocidad inician los objetos.
		
		StartCoroutine(nameof(AumentarVelocidad));
	}

	IEnumerator AumentarVelocidad()
    {
		//Si se pasa de la velocidad máxima, se sale de la corrutina
		if (velocidadGlobal >= velocidadMaxima)
			yield break;

		yield return new WaitForSecondsRealtime(1f);
		if(!Evento.hayEvento)
			velocidadGlobal += velExtraPorSegundo; //Aumentamos la velocidad global
		print(velocidadGlobal);
		StartCoroutine(nameof(AumentarVelocidad));
    }
}
