﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //libreria para agregar GUI
using UnityEngine.SceneManagement; //Libreria para manejo de escenas 

public class MovePlayer : MonoBehaviour //Kishi
{
	
	public Rigidbody2D rb;
	public float velocidadMov;
	public TextMeshProUGUI puntosTxt;
	public Sprite defaultSkin;
	public Animator anim;
	public SpriteRenderer renderTortuga;

	private int puntos;
	private puntos contadorTiempo;
	private float tiempoTranscurrido;
	private Vector2 vel_rb;
	
    void Start()
    {
		//Si no tiene una skin elegida, le pone la default
        /*#region AGREGAR SKIN AL JUGADOR   
        if (GameManager.skin != null) 
			GetComponent<SpriteRenderer>().sprite = GameManager.skin; 
		else
			GetComponent<SpriteRenderer>().sprite = defaultSkin; //Agregamos la imagen del personaje
        #endregion*/

        //print(GameManager.skin);
        puntos = PlayerPrefs.GetInt("Puntos");
	    contadorTiempo = GameObject.FindGameObjectWithTag("Contador").GetComponent<puntos>();
		renderTortuga = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
	{
		vel_rb = rb.velocity;
		tiempoTranscurrido = contadorTiempo.conteoTiempo;
		anim.SetBool("Movimiento", false);


		if (vel_rb.x > 0)
        {
			anim.SetBool("Movimiento", true);
			renderTortuga.flipX = false;
		}
		else if (vel_rb.x < 0)
        {
			anim.SetBool("Movimiento", true);
			renderTortuga.flipX = true;
		}
		else
        {
		}

		if (tiempoTranscurrido >= 60f)
		{
			velocidadMov = 4;
		}
		else if (tiempoTranscurrido >= 150f)
		{
			velocidadMov = 5;
		}	

		if (!Evento.hayEvento) //False
		{
			if (Input.GetKeyDown(KeyCode.D)) //Derecha con tecla
			{
				vel_rb.x = velocidadMov;
			}
			if (Input.GetKeyDown(KeyCode.A))//Izquierda con tecla
			{
				vel_rb.x = -velocidadMov;
			}
			
			if(Input.GetMouseButtonDown(0))
            {
				Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y); //Guardamos el vector del mouse
				Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition); //Referencia al tama;o de camara

				if(worldPosition.x >= 0) 
					vel_rb.x = velocidadMov; //Mover a la derecha
				else
					vel_rb.x = -velocidadMov; //Mover a la Izquierda
			}
		}
        else
        {
			vel_rb = new Vector2(0, 0);
		}

		rb.velocity = vel_rb; 
	}

    private void OnTriggerEnter2D(Collider2D collisionInfo)
    {
		//Si choca con las paredes, muere
		if (collisionInfo.gameObject.CompareTag("Wall") || collisionInfo.gameObject.CompareTag("Obstaculo"))
		{
			GameOver();//Carga la escena de gameover de manera Additive

			PlayerPrefs.SetInt("Puntos", puntos + int.Parse(puntosTxt.text)); //Guardamos partida
			int recordTiempo = PlayerPrefs.GetInt("Record"); //Obtener el record de tiempo actual
			//print(recordTiempo);
			//Si superamos el highscore, entonces lo ponemos como nuevo record
			if(tiempoTranscurrido > recordTiempo) 
            {
				GameManager.nuevoRecord = true; //Hubo nuevo record
				PlayerPrefs.SetInt("Record", (int)tiempoTranscurrido);
            }
            else
            {
				GameManager.nuevoRecord = false; //No hubo nuevo record
            }

			Time.timeScale = 0f; //Detiene el tiempo
		}
	}

	private void GameOver() //cargamos la escena de muerte
	{
		SceneManager.LoadScene("GameOver", LoadSceneMode.Additive); //Posible cambio a carga aditiva-----------------------------
	}

	

}//end Class

