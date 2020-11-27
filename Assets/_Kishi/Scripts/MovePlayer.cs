using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
	public Rigidbody rb;
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
	}
	
	public void MovePlayerRight()
	{
		rb.velocity = new Vector2(movePositive, 0);
	}
}

