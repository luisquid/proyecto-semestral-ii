using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class puntos : MonoBehaviour
{
    private TextMeshProUGUI Marcadordepuntos;
    public  TextMeshProUGUI timeloco;
    public GameObject holis;
    public int Puntoslocos = 0;
    float Tiempoloco;
    int tiempoanterior;

    void Start()
    {
        Marcadordepuntos = GetComponent<TextMeshProUGUI>();
        Tiempoloco += Time.deltaTime;
        mostrarTiempo();
    }

    void Update()
    {
        Tiempoloco += Time.deltaTime;
        int tiemponuevo = (int)Tiempoloco;

        Marcadordepuntos.text = Puntoslocos.ToString();

        if (tiemponuevo != tiempoanterior) 
        {

            timeloco.text = tiemponuevo.ToString();
            tiempoanterior = tiemponuevo;
            Puntoslocos = Puntoslocos + 5;

        }

        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        { 
        

        
        }

           
    }
    void mostrarTiempo()
    {
        GetComponent<TextMeshProUGUI>().text = "TIME\n" + ((int)Tiempoloco).ToString();
    }




}
