using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tiempo : MonoBehaviour
{
    float Tiempoloco;

    private void Start()
    {
        
    }
    void Update()
    {

        Tiempoloco += Time.deltaTime;
        mostrarTiempo();
        
    }

    void mostrarTiempo()
    {
        GetComponent<TextMeshProUGUI>().text = "TIME\n" + ((int)Tiempoloco).ToString();
    }


}
