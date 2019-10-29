using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
   // public GameObject xplosion;
    public GameObject enem;
   public GameObject xplosion;


    void Fire()
    {
        GameObject explosionclon = (GameObject)Instantiate(xplosion, transform.position, transform.rotation);


    }
    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Player"))
        {

            Fire();
            Destroy(enem);
        }
    }
}
