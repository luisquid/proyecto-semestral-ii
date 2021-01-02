﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MovePlayer : MonoBehaviour
{
	
	public Rigidbody2D rb;
	public float moveNegative;
	public float movePositive;
	public TextMeshProUGUI puntosTxt;
	public Sprite defull;
	
	private int puntos;
	
    // Start is called before the first frame update
    void Start()
    {
		GetComponent<SpriteRenderer>().sprite = defull;
			
        if (GameManager.skin != null) 
			GetComponent<SpriteRenderer>().sprite = GameManager.skin;

	    puntos = 0;
    }

    // Update is called once per frame
    void Update()
	{
		if (Evento.hayEvento == true)
			rb.velocity = new Vector2(0, 0);
	}
	
    
	public void MovePlayerLeft()
	{
		if (Evento.hayEvento == false)
		{
			rb.velocity = new Vector2(moveNegative, 0);
			
		}
		
	}
	
	public void MovePlayerRight()
	{
		if (Evento.hayEvento == false)
		{
			rb.velocity = new Vector2(movePositive, 0);
			
		}
	}
	// Sent when an incoming collider makes contact with this object's collider (2D physics only).
	protected void OnCollisionEnter2D(Collision2D collisionInfo)
	{
		//Si choca con las paredes, muere
		if(collisionInfo.gameObject.CompareTag("Wall") || collisionInfo.gameObject.CompareTag("Obstaculo")){

			PlayerPrefs.SetInt("Puntos", puntos + int.Parse(puntosTxt.text));
			GameOver();
			Destroy(this.gameObject);

		}

	}

	private void GameOver()
	{
		SceneManager.LoadScene("GameOver");
	}

}

