using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShoot : MonoBehaviour
{
    
	public int Daño= 1;
	public float fireRate = .25f;
	public float weaponRange = 50f;
	public float hitForce= 100f;
	public Transform gunEnd;
	
	public Camera Cam;
	private WaitForSeconds shotDuration = new WaitForSeconds(.07f);
	private LineRenderer laserLine;
	private float nextFire;
    
    void Start()
	{
		laserLine = GetComponent<LineRenderer>();
		Cam = GameObject.Find("Target").transform.GetChild(0).GetComponent<Camera>();
        
    }

    
    void Update()
    {
	    if(Input.GetButton("Fire1") && Time.time > nextFire)
	    {
	    	nextFire = Time.time + fireRate;
	    	StartCoroutine(shotEffect());
	    	Vector3 rayOrigin = Cam.ViewportToWorldPoint(new Vector3(0.5f,0.5f,0));
	    	RaycastHit hit;
	    	
	    	laserLine.SetPosition(0, gunEnd.position);
	    	
	    	if(Physics.Raycast(rayOrigin, Cam.transform.forward, out hit, weaponRange))
	    	{
	    		laserLine.SetPosition(1, hit.point);
	    	}
	    	else{
	    		laserLine.SetPosition(1, rayOrigin + (Cam.transform.forward * weaponRange));
	    	}
	    
	    }
    }
    
    
	private IEnumerator shotEffect()
	{
		laserLine.enabled = true;
		yield return shotDuration;
		laserLine.enabled = false;
	}
}
