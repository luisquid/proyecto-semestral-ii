using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] //Obligamos al objeto a tener Rigibody2D

public class Parallax : MonoBehaviour
{
    SpriteRenderer fondo;
    
    [SerializeField]
    public Transform posInicial;//donde inicia el loop
    public Transform posFinal;//donde finaliza el loop
    //public float velocidad;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {

        fondo = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //rb.velocity =  Vector2.down * SpeedManager.velocidadGlobal; //Rregresamos la vel

        if (gameObject.transform.position.y <= posFinal.position.y) //si pasamos la pos nos regresamos para dejarla correr
            gameObject.transform.position = posInicial.position; //Regresamos a la posicion de inicio de loop

    }
    void FixedUpdate()
    {
        //Si no hay un evento activo el objeto sigue en movimiento, sino, su velocidad es 0 en X y Y
        if (!Evento.hayEvento)
        {
            rb.velocity = Vector2.down * SpeedManager.velocidadGlobal; //Le da la velocidad de movimiento al obstáculo
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

    }
}
