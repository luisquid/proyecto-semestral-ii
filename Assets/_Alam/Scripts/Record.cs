using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //libreria para agregar GUI


public class Record : MonoBehaviour
{
    /*
     * Este script se encarga de mostrar en pantalla el record actual cuando se llega al gameover
     */
    public TextMeshProUGUI textoRecord;

    private TextMeshProUGUI marcadorRecord;

    void Start()
    {
        marcadorRecord = GetComponent<TextMeshProUGUI>();
        marcadorRecord.text = PlayerPrefs.GetInt("Record").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.nuevoRecord)
        {
            textoRecord.text = "Nuevo Record"; //Cambiar a texto de nuevo record
            textoRecord.color = new Color(212f, 0f, 0f);
            marcadorRecord.enableAutoSizing = true;
            marcadorRecord.color = new Color(212f, 0f, 0f);

            GameManager.nuevoRecord = false; //Aseguramos que ya no se meta a este IF
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteKey("Record");
            Debug.LogWarning("Record borrado!", gameObject);
        }
    }
}
