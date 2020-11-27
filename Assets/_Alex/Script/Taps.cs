using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taps : MonoBehaviour
{
    //Alexander Iniguez

    //crear un loop para dar taps hasta llevar a un tiempo deseado

    int contador; //para los taps
    float tiempo; //para ser llenado
    bool terminado; //condicional

    // Start is called before the first frame update
    void Start()
    {
        contador = 0;
         terminado = false;
    }

    // Update is called once per frame
    void Update()
    {
        LoopDeTaps();

    }

    public void LoopDeTaps()
    {
        if(!terminado)
        {
            tiempo += Time.deltaTime;
            
            if(tiempo >= 2.0f) //si ya pasaron dos segundos
            {
                print("te moristes alv"); //muerte
            }

            if(Input.GetKeyDown(KeyCode.Space)) //reset tiempo y damos al contador +1
            {
                tiempo = 0.0f;
                contador++;
                print("llevas  " + contador + "  taps");
            }

            if(contador == 20) //condicion de salir del loop
            {
                terminado = true;
                print("La libraste perro");
            }
        }
    }
}
