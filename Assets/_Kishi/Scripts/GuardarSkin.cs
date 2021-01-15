using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuardarSkin : MonoBehaviour
{
	/*
	 * Para guardas que skins somos los que hemos comprado y iniciar partidas con ellos puestos
	 */
	private string nameSkin;
	public string ruta = "Resources/";
	public void Guardar()
	{
		nameSkin = GameManager.skin.name;
		print(nameSkin);
		
		PlayerPrefs.SetString("Skin", nameSkin);
	}
}
