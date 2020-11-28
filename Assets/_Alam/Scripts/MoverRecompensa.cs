using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverRecompensa : MonoBehaviour
{
	public float velocidad; //Velocidad a la que se mueve el obstáculo
	private Rigidbody2D rb; //Rigidbody2D del obstáculo
	
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		
	}

	void FixedUpdate()
	{
		rb.velocity = Vector2.down * velocidad; //Le da la velocidad de movimiento al objeto
	}
    
	void OnTriggerEnter2D(Collider2D other)
	{
		
		if(other.gameObject.CompareTag("Player"))
		{
			//Lógica para cuando el jugador toque la recompensa
		}
		else if(other.gameObject.CompareTag("Borde")) //Revisa si ya llegó hasta abajo
		{
			Destroy(gameObject); //Destruir este objeto
		}
		
	}
	
	// Sent each frame where another object is within a trigger collider attached to this object (2D physics only).
	void OnTriggerStay2D(Collider2D other)
	{
		//En caso de que se genere sobre un obstáculo
		if(other.gameObject.CompareTag("Obstaculo")) 
		{
			Debug.Log("Me moví", gameObject);
			transform.position = new Vector2(Random.Range(-3.0f, 3.0f), 10f); //Lo mueve a otra posición
		}
	}
}
