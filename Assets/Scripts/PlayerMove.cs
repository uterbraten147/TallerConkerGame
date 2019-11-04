using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	public Animator animPlayer;
    
	public float Walkspeed = 10;
	public float Runspeed = 15;
	bool isRuning = false;
	bool apuntar = false;
	Vector3 MovePlayer;
	
	void Start()
	{
		//Set Cursor to not be visible
		Cursor.visible = false;
		isRuning = false;
		MovePlayer = Vector3.zero;
		
		
	}
    
  
   
   private  void Update()
    {
        movement();
    }


    void movement()
	{
    	
		if(Input.GetMouseButton(1))
		{
			apuntar=true;
			
		}else {
			apuntar = false;
		}
			
    	
        float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
        
		if(Input.GetKey(KeyCode.LeftShift)){
			
			isRuning = true;
			MovePlayer = new Vector3(horizontal, 0, vertical) * Runspeed * Time.deltaTime;
			
		}else{
			
			isRuning = false;
			 MovePlayer = new Vector3(horizontal, 0, vertical) * Walkspeed * Time.deltaTime;
			
		}
		
		
        
		transform.Translate(MovePlayer, Space.Self);
		
		
        
		animPlayer.SetFloat("walk", vertical);
		animPlayer.SetFloat("sideWalk", horizontal);
		animPlayer.SetBool("runing",isRuning);
		animPlayer.SetBool("apuntando", apuntar);
    }
}
