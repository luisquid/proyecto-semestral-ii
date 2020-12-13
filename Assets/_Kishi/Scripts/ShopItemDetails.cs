using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItemDetails : MonoBehaviour
{
	public string itemName;
	public int itemCost;
	public bool comprado;
	private ScripStore scriptStore;
	public Sprite itemskin;
    // Start is called before the first frame update
    void Start()
	{
		GetComponentInChildren<Image>().sprite = itemskin;
		scriptStore = FindObjectOfType<ScripStore>();
	    GetComponentsInChildren<TextMeshProUGUI>()[0].text = itemName;
	    GetComponentsInChildren<TextMeshProUGUI>()[1].text = itemCost + "";
	    comprado = PlayerPrefs.GetInt(itemName) == 1 ? true : false;
	    if (comprado){
	    	GetComponentInChildren<Button>().interactable = false;
	    }
	    // GetComponentInChildren<Button>().onClick.AddListener(() => TestAction());
    }

    // Update is called once per frame
    void Update()
    {
	    if(Input.GetKeyDown(KeyCode.Space)){
	    	PlayerPrefs.SetInt(itemName, 0);
	    }
    }
	public void ItemComprado(){
		if(itemCost <= PlayerPrefs.GetInt("Puntos")){
			PlayerPrefs.SetInt(itemName, 1);
			GetComponentInChildren<Button>().interactable = false;
			PlayerPrefs.SetInt("Puntos", PlayerPrefs.GetInt("Puntos") -itemCost);
			scriptStore.textPointStore.text = PlayerPrefs.GetInt("Puntos") + "";
		}
		else{
			Debug.Log("No hay lana joven");
		}
	}

	public void SelecSkin()
	{

		
		GameManager.skin = GetComponentInChildren<Image>().sprite;


	}
}
