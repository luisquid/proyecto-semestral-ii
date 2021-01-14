using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] //Obligamos al objeto a tener Rigibody2D

public class Parallax : MonoBehaviour
{
    SpriteRenderer fondo;
    
    [SerializeField]

    public Transform posInicial;
    public Transform posFinal;

    public float velocidad;

    private puntos contadorTiempo;
    private float tiempoTranscurrido;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {

        fondo = GetComponent<SpriteRenderer>();
        contadorTiempo = GameObject.FindGameObjectWithTag("Contador").GetComponent<puntos>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        tiempoTranscurrido = contadorTiempo.conteoTiempo;

        if (tiempoTranscurrido <= 15f)
        {
            velocidad = 2f;
        }
        else if (tiempoTranscurrido <= 30f)
        {
            velocidad = 3.5f;
        }
        else if (tiempoTranscurrido <= 45f)
        {
            velocidad = 4.3f;
        }
        else
        {
            velocidad = 5.5f;
        }

        rb.velocity =  Vector2.down * velocidad;

        if (gameObject.transform.position.y <= posFinal.position.y) //si pasamos la pos nos regresamos para dejarla correr
            gameObject.transform.position = posInicial.position;

    }
}
