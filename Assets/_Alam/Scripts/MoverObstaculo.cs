using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverObstaculo : MonoBehaviour
{
	public float velocidad; //Velocidad a la que se mueve el obstáculo
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
			rb.velocity = Vector2.down * velocidad; //Le da la velocidad de movimiento al obstáculo
		}
		else
		{
			rb.velocity = Vector2.zero;
		}
	}
    
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Borde")) //Revisa si ya llegó hasta abajo de la pantalla
		{
			Destroy(gameObject); //Destruir el obstáculo
		}
	}
}
