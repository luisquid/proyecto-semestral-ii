using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Libreria para manejo de escenas 

public class Escenes : MonoBehaviour //Kishi
{
	/*
		Manejo de las cargas de escenas dependiendo del estado o del evento indicado
	 */

    public void Play() // public void abrirEscenaPlay()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene("Game");
	}
	
	public void Creditos()
	{
		SceneManager.LoadScene("Credits");
	}
	
	public void Store()
	{
		SceneManager.LoadScene("Store");
	}
	
	public void MainMenu()
	{
		SceneManager.LoadScene("Menu");
	}
}
