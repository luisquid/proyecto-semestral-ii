using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScripStore : MonoBehaviour //Kishi
{
	public Text textPointStore;

    void Start()
    {
	    textPointStore.text = PlayerPrefs.GetInt("Puntos").ToString();
    }

    void Update()
    {
        
    }
}
