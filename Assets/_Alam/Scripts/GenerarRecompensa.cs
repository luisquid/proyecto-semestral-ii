using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarRecompensa : MonoBehaviour
{
	public GameObject[] recompensas;
	public float frecuencia;
	private float temporizador;
	private Vector2 posicionRecompensa;
	
    void Start()
    {
	    posicionRecompensa.y = 10f;
	    temporizador = frecuencia;
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
    
	public void Generar(){
		posicionRecompensa.x = Random.Range(-3.0f, 3.0f);
		int randObst = Random.Range(0, recompensas.Length);
		Instantiate(recompensas[randObst], posicionRecompensa, Quaternion.identity);
		temporizador = frecuencia;
	}
	
	
}
