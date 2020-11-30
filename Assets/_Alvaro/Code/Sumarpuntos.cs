using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sumarpuntos : MonoBehaviour
{
    GameObject Personaje;
    public puntos contantdor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Recompensa_20")) 
        {

            contantdor.Puntoslocos += 20;
            Destroy(collision.gameObject);
        
        }
    }


}
