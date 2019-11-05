using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("daño por explosivo");
        }
        if(col.gameObject.CompareTag("Bala"))
        {
            Debug.Log("daño por bala");
        }

    }
}
