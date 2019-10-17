using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    private Rigidbody rigBala;
    public float velocidadBala;
    public float damage;
    void Start()
    {
        rigBala = GetComponent<Rigidbody>();
        rigBala.velocity = velocidadBala*transform.forward;
        Destroy(gameObject, 5);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SendMessage("ReciveDamege", damage,SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
    }
}
