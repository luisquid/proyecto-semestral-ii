using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarEvento : MonoBehaviour
{
	public GameObject evento;

	private float temporizador;
	private Vector2 posicionRecompensa;

	void Start()
	{
		posicionRecompensa.y = 10f;
		temporizador = Random.Range(2.0f, 5.0f);
	}

	// Update is called once per frame
	void Update()
	{
		if (Evento.evento == false)
		{
			temporizador -= Time.deltaTime; //Disminuye el temporizador
			if (temporizador <= 0f)
			{
				Generar();
			}
		}
	}

	public void Generar()
	{
		posicionRecompensa.x = Random.Range(-3.0f, 3.0f);
		Instantiate(evento, posicionRecompensa, Quaternion.identity);
		temporizador = Random.Range(40f, 60f);
	}

}
