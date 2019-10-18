using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    
    public float speed = 20;
  
   
   private  void Update()
    {
        movement();
    }


    void movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 MovePlayer = new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime;
        transform.Translate(MovePlayer, Space.Self);
    }
}
