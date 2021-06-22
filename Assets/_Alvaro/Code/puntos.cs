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

    public static int contadorPuntos = 0; //Nunca cambiara el valor
    [HideInInspector]
    public float conteoTiempo;
    int tiempoAnterior;

    void Start()
    {
        //marcadorDePuntos = GetComponent<TextMeshProUGUI>(); //ya que no se encontro por si solo
        conteoTiempo = 0;
        tiempoAnterior = -1; //Empieza en -1 para que sea diferente al tiempo nuevo por default
	    MostrarTiempo(); //Hace un casteo del tiempo y lo imprime en un Text
	    contadorPuntos = 0;
    }

    void Update()
    {
        //ESTO PROBABLEMENTE DESAPAREZCA, SOLO SE SUMARÁN PUNTOS CON LA BASURA QUE COLECTAS
        if (!Evento.hayEvento)
        {
            conteoTiempo += Time.deltaTime;

            int tiempoNuevo = (int)conteoTiempo;

            if (tiempoNuevo != tiempoAnterior)
            {
                marcadorDePuntos.text = contadorPuntos.ToString();
                marcadorDeTiempo.text = tiempoNuevo.ToString();
                tiempoAnterior = tiempoNuevo;
                contadorPuntos += 5;
            }
        }

    }//end Update

    void MostrarTiempo()
    {
        GetComponent<TextMeshProUGUI>().text = ((int)conteoTiempo).ToString();
    } //end void


}//end class
