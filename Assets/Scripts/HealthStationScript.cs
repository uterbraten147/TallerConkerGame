using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthStationScript : MonoBehaviour
{
	bool curarVida= false;
    // Start is called before the first frame update
    void Start()
	{
		curarVida=false;
        
    }

    // Update is called once per frame
    void Update()
	{
		if(curarVida && PlayerStats.VidaPlayer  < 100)
		{
			PlayerStats.VidaPlayer += Time.deltaTime;
			Debug.Log("Se esta curando");
		}else{
			Debug.Log("ya se curo haha");
		}
        
    }
    
	// OnTriggerEnter is called when the Collider other enters the trigger.
	protected void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			curarVida = true;		
				
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		curarVida = false;
	}
}
