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
		rb.velocity = Vector2.down * velocidad; //Le da la velocidad de movimiento al obstáculo
	}
    
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Borde")) //Revisa si ya llegó hasta abajo el obstáculo
		{
			Destroy(gameObject); //Destruir el obstáculo
		}
	}
}
