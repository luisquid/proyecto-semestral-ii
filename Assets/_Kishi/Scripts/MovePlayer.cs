using System.Collections;
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
	
	private int puntos;
	private puntos contadorTiempo;
	private float tiempoTranscurrido;
	private Vector2 vel_rb;


	
    // Start is called before the first frame update
    void Start()
    {
		//Si no tiene una skin elegida, le pone la default
        #region AGREGAR SKIN AL JUGADOR   
        if (GameManager.skin != null) 
			GetComponent<SpriteRenderer>().sprite = GameManager.skin; 
		else
			GetComponent<SpriteRenderer>().sprite = defaultSkin; //Agregamos la imagen del personaje
        #endregion
        //print(GameManager.skin);
        puntos = 0;
	    contadorTiempo = GameObject.FindGameObjectWithTag("Contador").GetComponent<puntos>();
		
    }

    // Update is called once per frame
    void Update()
	{
		vel_rb = rb.velocity;
		tiempoTranscurrido = contadorTiempo.conteoTiempo;

		if (Evento.hayEvento) //True
			vel_rb = new Vector2(0, 0);

		if (tiempoTranscurrido >=60f)
		{
			velocidadMov = 4;
		}
		else if (tiempoTranscurrido >= 300f)
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
		
		rb.velocity = vel_rb; 
	}

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
		SceneManager.LoadScene("GameOver"); //Posible cambio a carga aditiva-----------------------------
	}

}//end Class

