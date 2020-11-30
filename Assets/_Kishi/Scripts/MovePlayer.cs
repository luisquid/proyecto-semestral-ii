using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
	public Rigidbody2D rb;
	public float moveNegative;
	public float movePositive;
    // Start is called before the first frame update
    void Start()
    {
	    
    }

    // Update is called once per frame
    void Update()
	{
    	
    }
	
    
	public void MovePlayerLeft()
	{
		rb.velocity = new Vector2(moveNegative, 0);
		Debug.Log("Izquieda");
	}
	
	public void MovePlayerRight()
	{
		rb.velocity = new Vector2(movePositive, 0);
		Debug.Log("Derecha");
	}
	// Sent when an incoming collider makes contact with this object's collider (2D physics only).
	protected void OnCollisionEnter2D(Collision2D collisionInfo)
	{
		if(collisionInfo.gameObject.CompareTag("Wall")){
			rb.velocity = new Vector2(0, 0);
		}
		if(collisionInfo.gameObject.CompareTag("Obstaculo")){
			Destroy(this.gameObject);
		}
	}
	
}

