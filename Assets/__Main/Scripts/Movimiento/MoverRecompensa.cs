using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverRecompensa : MonoBehaviour//Alam
{
	private Rigidbody2D rb; //Rigidbody2D del obstáculo

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{
		//Si no hay un evento activo el objeto sigue en movimiento, sino, su velocidad es 0 en X y Y
		if (!Evento.hayEvento)
		{
			rb.velocity = Vector2.down * SpeedManager.velocidadGlobal; //Le da la velocidad de movimiento al objeto
		}
		else
		{
			rb.velocity = Vector2.zero;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		
		if(other.gameObject.CompareTag("Player"))
		{
			//Lógica para cuando el jugador toque la recompensa
		}
		else if(other.gameObject.CompareTag("Borde")) //Revisa si ya llegó hasta abajo de la pantalla
		{
			Destroy(gameObject); //Destruir este objeto
		}
		
	}
	
	void OnTriggerStay2D(Collider2D other)
	{
		//En caso de que se genere sobre un obstáculo, lo moverá a una posición aleatoria nueva, hasta que sea válida
		if(other.gameObject.CompareTag("Obstaculo")) 
		{
			transform.position = new Vector2(Random.Range(-3.0f, 3.0f), 10f); //Lo mueve a otra posición
		}
	}
}
