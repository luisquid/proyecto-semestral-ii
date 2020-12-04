using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escenes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
	public void abrirEscenaPlay() {
		SceneManager.LoadScene("Game");
	}
	
	public void abrirCredits (){
		SceneManager.LoadScene("Credits");
	}
	
	public void abrirStore (){
		SceneManager.LoadScene("Store");
	}
	
	public void abrirMenu (){
		SceneManager.LoadScene("Menu");
	}
}
