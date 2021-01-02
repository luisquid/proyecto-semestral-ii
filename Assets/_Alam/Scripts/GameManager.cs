using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Sprite skin; //Guarda la skin que el jugador tendrá a lo largo de las partidas

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    
}
