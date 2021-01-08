using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tiempo : MonoBehaviour //Alvaro
{
    float conteoTiempo;

    void Update()
    {
        conteoTiempo += Time.deltaTime;
        mostrarTiempo();
    }

    void mostrarTiempo()
    {
        GetComponent<TextMeshProUGUI>().text = "TIME\n" + ((int)conteoTiempo).ToString();
    }


}//end class
