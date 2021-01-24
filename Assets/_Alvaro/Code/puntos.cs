using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //libreria para agregar GUI


public class puntos : MonoBehaviour //Alvaro
{
    /*
     Para visualizar el tiempo en un canvas mediante un text mesh ademas de ser llenado por el time real y puntos 
     */
    public TextMeshProUGUI marcadorDePuntos;
    public  TextMeshProUGUI marcadorDeTiempo;

    public static int puntoCero = 0; //Nunca cambiara el valor
    [HideInInspector]
    public float conteoTiempo;
    int tiempoAnterior;

    void Start()
    {
        //marcadorDePuntos = GetComponent<TextMeshProUGUI>(); //ya que no se encontro por si solo
        conteoTiempo += Time.deltaTime; //llenamos el tiempo con a tiempo real
	    mostrarTiempo(); //Hace un casteo del tiempo y lo imprime en un Text
	    puntoCero = 0;
    }

    void Update()
    {
        if (!Evento.hayEvento)
        {
            conteoTiempo += Time.deltaTime;

            int tiempoNuevo = (int)conteoTiempo;

            if (tiempoNuevo != tiempoAnterior)
            {
                marcadorDePuntos.text = puntoCero.ToString();
                marcadorDeTiempo.text = tiempoNuevo.ToString();
                tiempoAnterior = tiempoNuevo;
                puntoCero += 5;
            }
        }

    }//end Update

    void mostrarTiempo()
    {
        GetComponent<TextMeshProUGUI>().text = ((int)conteoTiempo).ToString();
    }//end void




}//end class
