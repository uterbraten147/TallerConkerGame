using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayViewer : MonoBehaviour
{
	public float weaponRange = 50f;
	public Camera  cam;
  
    void Start()
	{
		cam= GetComponent<Camera>();
        
    }


    void Update()
    {
	     Vector3 lineOrigin = cam.ViewportToWorldPoint(new Vector3(0.5f,0.5f,0));
	     Debug.DrawRay(lineOrigin, cam.transform.forward * weaponRange, Color.green);
    }
}
