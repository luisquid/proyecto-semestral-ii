using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //libreria para agregar GUI


public class puntos : MonoBehaviour //Alvaro
{
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
	    puntoCero=0;
    }

    void Update()
    {
        conteoTiempo += Time.deltaTime;
        int tiempoNuevo = (int)conteoTiempo;

        marcadorDePuntos.text = puntoCero.ToString();

        if (tiempoNuevo != tiempoAnterior) 
        {
            marcadorDeTiempo.text = tiempoNuevo.ToString();
            tiempoAnterior = tiempoNuevo;
            puntoCero += 5;
        }

    }//end Update

    void mostrarTiempo()
    {
        GetComponent<TextMeshProUGUI>().text = "TIME\n" + ((int)conteoTiempo).ToString();
    }//end void




}//end class
