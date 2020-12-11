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
    public TextMeshProUGUI Marcadordetaps;
    public float limite;
    float Tiempoloco;
    public TextMeshProUGUI Marcadortiempo;

    // Start is called before the first frame update
    void Start()
    {
        contador = 0;
        Marcadordetaps.text = contador.ToString();
        Tiempoloco = limite;


    }

    // Update is called once per frame
    void Update()
    {

        LoopDeTaps();
        Tiempoloco -= Time.deltaTime;
        mostrarTiempo();

    }

    public void LoopDeTaps()
    {

        if (Tiempoloco <= 0f) //si ya pasaron dos segundos
        {
            Fin();
        }
        if(contador == 20) //condicion de salir del loop
        {
            Fin();
            print("La libraste perro");
        }
        
    }

    public void Tap()
    {
        contador++;
        print("llevas  " + contador + "  taps");
        Marcadordetaps.text = contador.ToString();

    }

    public void Fin() 
    {
        
            Evento.evento = false;
            SceneManager.UnloadSceneAsync("Evento");
            puntos.Puntoslocos = puntos.Puntoslocos + contador;

    }
    void mostrarTiempo()
    {
        Marcadortiempo.text =  ((int)Tiempoloco).ToString();
    }

}
