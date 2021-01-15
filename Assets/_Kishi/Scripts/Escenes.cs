using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Libreria para manejo de escenas 

public class Escenes : MonoBehaviour //Kishi
{
	/*
		Manejo de las cargas de escenas dependiendo del estado o del evento indicado
	 */
	public void abrirGame() // public void abrirEscenaPlay()
	{
		SceneManager.LoadScene("Game");
		
	}
	
	public void abrirCredits()
	{
		SceneManager.LoadScene("Credits");
	}
	
	public void abrirStore()
	{
		SceneManager.LoadScene("Store");
	}
	
	public void abrirMenu()
	{
		SceneManager.LoadScene("Menu");
	}
}
