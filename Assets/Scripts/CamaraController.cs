﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{

    public float RotationSpeed = 1;
    public Transform target, player;
    float mouseX, mouseY;
	// Start is called before the first frame update
	public float fieldView;
    
    void Start()
	{
		fieldView = 60f;
        
	}
    
	void Update(){
		
		if(PlayerMove.apuntar)
		{
			fieldView = 30f;
		}else{
			fieldView= 60f;
		}
		
		Camera.main.fieldOfView = fieldView;
		
	}
	

   void LateUpdate()
    {
        CamControl();
    }

    void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * RotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * RotationSpeed;
	    mouseY = Mathf.Clamp(mouseY, -5, 60);

        transform.LookAt(target);

        target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        player.rotation = Quaternion.Euler(0, mouseX, 0);
    }
}
