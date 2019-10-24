using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : MonoBehaviour
{
	
	
	
	
	public GameObject bala;
	public Transform spawner; 
	public float fuerzaDisparo = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
	{
		if(Input.GetMouseButton(0))
		{
			disparar();
		}
        
    }
    
    
	void disparar(){
		
		GameObject Balaclone = Instantiate(bala, spawner.transform) as GameObject;
		Rigidbody RigiBala = Balaclone.GetComponent<Rigidbody>();
		RigiBala.AddForce(Vector3.forward * fuerzaDisparo);
		
		Destroy(Balaclone, 5);
		
	}
}
