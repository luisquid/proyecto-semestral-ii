using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScripStore : MonoBehaviour //Kishi
{
	public Text textPointStore;

    // Start is called before the first frame update
    void Start()
    {
	    textPointStore.text = PlayerPrefs.GetInt("Puntos").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}//end Class
