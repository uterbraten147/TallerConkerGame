using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
	public static float VidaPlayer= 20f;
	public Image VidaBarra;
    // Start is called before the first frame update
    void Start()
	{
		VidaPlayer = 20f;
        
    }

    // Update is called once per frame
    void Update()
	{
		
		VidaBarra.fillAmount = (VidaPlayer / 100f );
		
		if(VidaPlayer <= 0 )
		{
			Debug.Log("Se murio el player");
			
			
		}
		
        
    }
    
    
}
