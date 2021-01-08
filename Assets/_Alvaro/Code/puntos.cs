using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //libreria para agregar GUI


public class Puntos : MonoBehaviour //Alvaro
{
    public TextMeshProUGUI marcadorDePuntos;
    public  TextMeshProUGUI marcadorDeTiempo;

    public GameObject holis; //Que va llevar aqui?????? //Cambiar nombre

    public static int puntoCero = 0; //Nunca cambiara el valor
    int tiempoAnterior;

    float conteoTiempo;

    void Start()
    {
        //marcadorDePuntos = GetComponent<TextMeshProUGUI>(); //ya que no se encontro por si solo
        conteoTiempo += Time.deltaTime; //llenamos el tiempo con a tiempo real
        mostrarTiempo(); //Hace un casteo del tiempo y lo imprime en un Text
    }//end Start

    void Update()
    {
        conteoTiempo += Time.deltaTime;
        int tiempoNuevo = (int)conteoTiempo;

        marcadorDePuntos.text = puntoCero.ToString();

        if (tiempoNuevo != tiempoAnterior) 
        {
            marcadorDeTiempo.text = tiempoNuevo.ToString();
            tiempoAnterior = tiempoNuevo;
            puntoCero = puntoCero + 5;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        { 

        }

    }//end Update

    void mostrarTiempo()
    {
        GetComponent<TextMeshProUGUI>().text = "TIME\n" + ((int)conteoTiempo).ToString();
    }//end void




}//end class
