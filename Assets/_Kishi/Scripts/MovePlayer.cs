using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MovePlayer : MonoBehaviour
{
	public Rigidbody2D rb;
	public float moveNegative;
	public float movePositive;
	public TextMeshProUGUI puntosTxt;
	
	private int puntos;
	
    // Start is called before the first frame update
    void Start()
    {
	    puntos = PlayerPrefs.GetInt("Puntos");
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
		//Si choca con las paredes, muere
		if(collisionInfo.gameObject.CompareTag("Wall") || collisionInfo.gameObject.CompareTag("Obstaculo")){ 
			
			PlayerPrefs.SetInt("Puntos", puntos + int.Parse(puntosTxt.text));
			print(PlayerPrefs.GetInt("Puntos"));
			Destroy(this.gameObject);
		}

	}
	
}

