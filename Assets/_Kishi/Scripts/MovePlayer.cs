using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //libreria para agregar GUI
using UnityEngine.SceneManagement; //Libreria para manejo de escenas 

public class MovePlayer : MonoBehaviour //Kishi
{
	
	public Rigidbody2D rb;

	public float moveNegative; //Para que dos variables??????
	public float movePositive;

	public TextMeshProUGUI puntosTxt;

	public Sprite defull;
	
	private int puntos;
	private puntos contadorTiempo;
	private float tiempoTranscurrido;
	
    // Start is called before the first frame update
    void Start()
    {
		//GetComponent<SpriteRenderer>().sprite = defull; //Agregamos la imagen del personaje
			
        if (GameManager.skin != null) 
			GetComponent<SpriteRenderer>().sprite = GameManager.skin;
		//print(GameManager.skin);
	    puntos = 0;
	    contadorTiempo = GameObject.FindGameObjectWithTag("Contador").GetComponent<puntos>();
    }

    // Update is called once per frame
    void Update()
	{
		if (Evento.hayEvento == true)
			rb.velocity = new Vector2(0, 0);
			
		tiempoTranscurrido = contadorTiempo.conteoTiempo;

		if (tiempoTranscurrido >=60f)
		{
			movePositive = 5;
			moveNegative = -5;
		}
		else if (tiempoTranscurrido >= 350f)
		{
			 movePositive = 4;
			 moveNegative = -4;
		}

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
		if(collisionInfo.gameObject.CompareTag("Wall") || collisionInfo.gameObject.CompareTag("Obstaculo"))
		{
			PlayerPrefs.SetInt("Puntos", puntos + int.Parse(puntosTxt.text)); //Guardamos partida
			GameOver();
			Destroy(this.gameObject);
		}
	}

	private void GameOver() //cargamos la escena de muerte
	{
		SceneManager.LoadScene("GameOver");
	}

}//end Class

