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
	public float velocidadExtra; //Es el extra de velocidad que se añadirá a la velocidad global cada cierto tiempo
	public float velocidadMaxima; //Es el tope de velocidad que los objetos pueden alcanzar
	public float tiempoExtra; //Esta variable decide cada cuántos tiempo aumenta la velocidad (Después del primer cambio)

	private puntos contadorTiempo; 
    private float tiempoTranscurrido;

	/*Guarda la cantidad de tiempo que tarda en aumentar la velocidad, ejemplo: 15f = Cada 15 segundos.
	 *Cuando el tiempo transcurrido es mayor a esta variable, entonces la velocidad aumenta
	 */
	private float tiempoParaAumentar; 

    void Start()
    {
        contadorTiempo = GameObject.FindGameObjectWithTag("Contador").GetComponent<puntos>();
		tiempoParaAumentar = 20f; //El primer aumento de velocidad se producirá a partir de este segundo
		velocidadGlobal = 2f; //Con esta velocidad inician los objetos.
    }

    // Update is called once per frame
    void Update()
    {
		#region VELOCIDAD GLOBAL DE OBJETOS

		tiempoTranscurrido = contadorTiempo.conteoTiempo;

		//Cada cierto tiempo aumenta la velocidad global, hasta un máximo de 5f de velocidad.
		if (tiempoTranscurrido >= tiempoParaAumentar && velocidadGlobal < velocidadMaxima)
		{
			//print("Amenté a " + velocidadGlobal + " de velocidad.");
			velocidadGlobal += velocidadExtra; //Aumentamos la velocidad global
			tiempoParaAumentar += tiempoExtra; //Aumentamos el tiempo necesario para el incremento de velocidad
		}
		
		#endregion
	}
}
