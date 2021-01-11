using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Libreria para manejo de canvas
using TMPro; 

public class ShopItemDetails : MonoBehaviour //Kishi
{
	public string itemName;
	public int itemCost;
	public bool bought; //ambiguo todo en ingles o español ando piki "bought" --> comprado
	public Sprite itemSkin;
	public string nameSkin;

	private ScripStore scriptStore;

    void Start()
	{
		GetComponentInChildren<Image>().sprite = itemSkin;

		scriptStore = FindObjectOfType<ScripStore>();
	    GetComponentsInChildren<TextMeshProUGUI>()[0].text = itemName;
	    GetComponentsInChildren<TextMeshProUGUI>()[1].text = itemCost + "";
	    bought = PlayerPrefs.GetInt(itemName) == 1 ? true : false;

		nameSkin = itemSkin.name;


	    if (bought)
		{
	    	GetComponentInChildren<Button>().interactable = false;
	    }
	    // GetComponentInChildren<Button>().onClick.AddListener(() => TestAction());
    }

    // Update is called once per frame
    void Update()
    {
	    if(Input.GetKeyDown(KeyCode.Space))
		{
	    	PlayerPrefs.SetInt(itemName, 0);
	    }

		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			PlayerPrefs.SetInt("Puntos", 20000);
		}
	}

	public void ItemComprado()
	{
		if(itemCost <= PlayerPrefs.GetInt("Puntos"))
		{
			PlayerPrefs.SetInt(itemName, 1);
			GetComponentInChildren<Button>().interactable = false;
			PlayerPrefs.SetInt("Puntos", PlayerPrefs.GetInt("Puntos") -itemCost);
			scriptStore.textPointStore.text = PlayerPrefs.GetInt("Puntos") + "";
		}
		else
			Debug.Log("Falta Dinero");
		
	}

	public void SelecSkin()
	{
		GameManager.skin = GetComponentInChildren<Image>().sprite;
	}
}//end Class
