using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject target;
    private bool followingPlayer=false;
    private GameObject positionPlayer;
    public float outTarget;
    public GameObject balaPFB;
    public float fireRate;
    private float lastTimeShoot;
    void Start()
    {
        //agent.SetDestination(target.transform.position);
    }

    void Update()
    {
        if (followingPlayer) {
            float distancia = Vector3.Distance(transform.position, positionPlayer.transform.position);
            //Debug.Log(distancia);
            if (distancia > outTarget)
            {
                agent.SetDestination(transform.position);
                followingPlayer = false;
            }
            else {
                if (Time.time > lastTimeShoot + fireRate) {
                    lastTimeShoot = Time.time;
                    Instantiate(balaPFB,transform.position,transform.rotation);
                }
                Vector3 direccion =target.transform.position-transform.position;
                Quaternion Rotacion = Quaternion.LookRotation(direccion);
                transform.rotation = Quaternion.Slerp(transform.rotation, Rotacion, 8.0f * Time.deltaTime);
            }
            
        }
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            agent.SetDestination(other.gameObject.transform.position);
            positionPlayer = other.gameObject;
            followingPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }

}
