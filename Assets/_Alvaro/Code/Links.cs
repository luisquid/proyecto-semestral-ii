using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Links : MonoBehaviour //Alvaro
{
	/*
	 La funcion nos manda a un hiper vinculo a web,  para darnos a conocer en dieferentes medio
	 */
	public string links;
	
	// Agregas
	public void mandar()
	{
		
		Application.OpenURL(links);
		
	}
    
}
