using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Taps : MonoBehaviour  //Alexander 
{
    //crear un loop para dar taps hasta llevar a un tiempo deseado

    int contador; //para los taps

    public TextMeshProUGUI marcadorDeTaps;
    public TextMeshProUGUI marcadorDeTiempo;

    public float limite;
    float tiempo;

    // Start is called before the first frame update
    void Start()
    {
        contador = 0;
        marcadorDeTaps.text = contador.ToString();
        tiempo = limite;
    }

    // Update is called once per frame
    void Update()
    {
        LoopDeTaps();
        tiempo -= Time.deltaTime;
        MostrarTiempo();
    }

    public void LoopDeTaps()
    {
        if (tiempo <= 0f) //si ya pasaron dos segundos
        {
            Fin();
        }
        if(contador == 20) //condicion de salir del loop
        {
            Fin();
        }
    }

    public void Tap()
    {
        contador++;
        marcadorDeTaps.text = contador.ToString();
    }

    public void Fin() 
    {
        Evento.hayEvento = false;
        SceneManager.UnloadSceneAsync("Evento");
        Puntos.puntoCero += contador;
    }

    void MostrarTiempo()
    {
        marcadorDeTiempo.text =  (tiempo).ToString("#.00");
    }

}
