using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class puntos : MonoBehaviour
{
    private TextMeshProUGUI marcadorDePuntos;
    public  TextMeshProUGUI marcadorDeTiempo;
    public GameObject holis;
    public static int puntosLocos = 0;
    float tiempoLoco;
    int tiempoanterior;

    void Start()
    {
        marcadorDePuntos = GetComponent<TextMeshProUGUI>();
        tiempoLoco += Time.deltaTime;
        mostrarTiempo();
    }

    void Update()
    {
        tiempoLoco += Time.deltaTime;
        int tiemponuevo = (int)tiempoLoco;

        marcadorDePuntos.text = puntosLocos.ToString();

        if (tiemponuevo != tiempoanterior) 
        {

            marcadorDeTiempo.text = tiemponuevo.ToString();
            tiempoanterior = tiemponuevo;
            puntosLocos = puntosLocos + 5;

        }

        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        { 

        }

    }
    void mostrarTiempo()
    {
        GetComponent<TextMeshProUGUI>().text = "TIME\n" + ((int)tiempoLoco).ToString();
    }




}
