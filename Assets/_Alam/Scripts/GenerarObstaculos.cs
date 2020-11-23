using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarObstaculos : MonoBehaviour
{
	public GameObject[] obstaculos;
	public float frecuencia;
	private float temporizador;
	private Vector2 posicionObstaculo;
	
    // Start is called before the first frame update
    void Start()
    {
	    print("Hola buenas");
	    posicionObstaculo.y = 7f;
	    temporizador = frecuencia;
    }

    // Update is called once per frame
    void Update()
	{
		temporizador -= Time.deltaTime; //Disminuye el temporizador
		if(temporizador <= 0f)
		{
			posicionObstaculo.x = Random.Range(-3.0f, 3.0f);
			int randObst = Random.Range(0, obstaculos.Length);
			Instantiate(obstaculos[randObst], posicionObstaculo, Quaternion.identity);
			temporizador = frecuencia;
		}
    }
}
