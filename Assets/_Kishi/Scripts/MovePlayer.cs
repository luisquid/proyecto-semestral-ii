using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //libreria para agregar GUI
using UnityEngine.SceneManagement; //Libreria para manejo de escenas 

public class MovePlayer : MonoBehaviour
{
	public float velocidadMov;
	public TextMeshProUGUI puntosTxt;
	public Sprite defaultSkin;

	[SerializeField]
	private GameObject gameOverPanel;
	private Rigidbody2D rb;
	private Vector2 velRb;
	private SpriteRenderer renderTortuga;
	private Animator anim;
	private Camera cam;
	private puntos puntosManager;
	private float tiempoTranscurrido;
	private int puntos;
	
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
        #region GET COMPONENTS
        rb = GetComponent<Rigidbody2D>();
		renderTortuga = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
	    puntosManager = GameObject.FindGameObjectWithTag("Contador").GetComponent<puntos>();
		cam = Camera.main;
		#endregion

		puntos = PlayerPrefs.GetInt("Puntos");
		gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
	{
		velRb = rb.velocity;
		tiempoTranscurrido = puntosManager.conteoTiempo;
		anim.SetBool("Movimiento", false);

        #region ANIMACIONES 
        if (velRb.x > 0)
        {
			anim.Play("Derecha");
		}
		else if (velRb.x < 0)
        {
			anim.Play("Izquierda");
		}
		else
        {
			anim.Play("Idle");
		}
        #endregion


  //      if (tiempoTranscurrido >= 60f)
		//{
		//	velocidadMov = 4;
		//}
		//else if (tiempoTranscurrido >= 150f)
		//{
		//	velocidadMov = 5;
		//}	

		if (!Evento.hayEvento) //False
		{
			if (Input.GetKeyDown(KeyCode.D)) //Derecha con tecla
			{
				velRb.x = velocidadMov;
			}
			if (Input.GetKeyDown(KeyCode.A))//Izquierda con tecla
			{
				velRb.x = -velocidadMov;
			}
			
			if(Input.GetMouseButtonDown(0))
            {
				Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y); //Guardamos el vector del mouse
				Vector2 worldPosition = cam.ScreenToWorldPoint(screenPosition); //Referencia al tama;o de camara

				if(worldPosition.x >= 0) 
					velRb.x = velocidadMov; //Mover a la derecha
				else
					velRb.x = -velocidadMov; //Mover a la Izquierda
			}
		}
        else
        {
			velRb = Vector2.zero;
		}

		rb.velocity = velRb; 
	}

    private void OnTriggerEnter2D(Collider2D collisionInfo)
    {
		//Si choca con las paredes, pierde
		if (collisionInfo.gameObject.CompareTag("Wall") || collisionInfo.gameObject.CompareTag("Obstaculo"))
		{
			gameOverPanel.SetActive(true); //Activar pantalla de game over

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

}//end Class

