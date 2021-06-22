using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Taps : MonoBehaviour  //Alexander 
{
    //crear un loop para dar taps hasta llevar a un tiempo deseado

    int contadorTaps; //para los taps

    public TextMeshProUGUI marcadorDeTaps;
    public TextMeshProUGUI marcadorDeTiempo;
    public TextMeshProUGUI cuentaRegresiva;
    public GameObject interfazTaps;
    public float limite;

    float tiempo;
    private int contador = 3;
    

    // Start is called before the first frame update
    void Start()
    {
	    //Debug.Log(gameObject.name, gameObject);
        contadorTaps = 0;
        marcadorDeTaps.text = contadorTaps.ToString();
        cuentaRegresiva.text = contador.ToString();
        tiempo = limite;
    }

    // Update is called once per frame
    void Update()
    {
        LoopDeTaps();
        tiempo -= Time.deltaTime;
    }

    public void LoopDeTaps()
    {
        if (tiempo <= 0f) //si ya pasó el tiempo límite
        {
            tiempo = 100f; //Ponerlo en un tiempo distinto para que ya no se cumpla esta condición
            if (contadorTaps >= 20) //Si llega a la meta gana los puntos
            {
                puntos.contadorPuntos += 50;
                Fin();
            }
            Fin();
        }
        else
        {
            MostrarTiempo(); //Mostrar el tiempo solo si es necesario
        }

    }

    public void Tap()
    {
        contadorTaps++;
        marcadorDeTaps.text = contadorTaps.ToString();
    }

    public void Fin() 
    {
        interfazTaps.SetActive(false); //Quitar del canvas el quick time event
        cuentaRegresiva.gameObject.SetActive(true);
        int tiempoEspera = 1;
        for(int i = 0; i < 3; i++, tiempoEspera++)
        {
            StartCoroutine(RegresarAlJuego(tiempoEspera));
        }

    }

    void MostrarTiempo()
    {
        marcadorDeTiempo.text =  (tiempo).ToString("#.00");
    }


    /* 
     * Esta co-rutina pone en pantalla un contador, sirve para llamarla cuando el jugador sale del evento y dar una mejor UX.
     * No deja que el juego siga hasta que termine la cuenta regresiva
     */
    IEnumerator RegresarAlJuego(float _tiempoEspera)
    {
        yield return new WaitForSeconds(_tiempoEspera);
        contador--;
        if(contador > 0)
        {
            cuentaRegresiva.text = contador.ToString();
        }
        else
        {
            Evento.hayEvento = false;
            SceneManager.UnloadSceneAsync("Evento");
        }
    }

}
