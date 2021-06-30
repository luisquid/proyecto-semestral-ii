using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour //Alam
{
    public static Sprite skin; //Guarda la skin que el jugador tendrá a lo largo de las partidas
    public static bool nuevoRecord = false;

    void Start()
    {
        skin = Resources.Load<Sprite>(PlayerPrefs.GetString("Skin"));
	    //print(skin.name);
        DontDestroyOnLoad(gameObject);
    }

}
