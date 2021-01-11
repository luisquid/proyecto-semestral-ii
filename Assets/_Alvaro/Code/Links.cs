using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Links : MonoBehaviour
{
	public string links;
	
  
	public void mandar()
	{
		
		Application.OpenURL(links);
		
	}
    
}
