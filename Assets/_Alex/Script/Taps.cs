using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Taps : MonoBehaviour
{
    //Alexander Iniguez

    //crear un loop para dar taps hasta llevar a un tiempo deseado

    int contador; //para los taps
    public TextMeshProUGUI marcadorDeTaps;
    public float limite;
    float tiempoLoco;
    public TextMeshProUGUI marcadorDeTiempo;

    // Start is called before the first frame update
    void Start()
    {
        contador = 0;
        marcadorDeTaps.text = contador.ToString();
        tiempoLoco = limite;
    }

    // Update is called once per frame
    void Update()
    {
        LoopDeTaps();
        tiempoLoco -= Time.deltaTime;
        MostrarTiempo();
    }

    public void LoopDeTaps()
    {
        if (tiempoLoco <= 0f) //si ya pasaron dos segundos
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
        puntos.puntosLocos += contador;
    }

    void MostrarTiempo()
    {
        marcadorDeTiempo.text =  (tiempoLoco).ToString("#.00");
    }

}
