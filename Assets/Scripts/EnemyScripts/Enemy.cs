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
    private Vector3 point;
    void Start()
    {
        //agent.SetDestination(target.transform.position);
        CambiarPunto();
    }

    void Update()
    {
        if (followingPlayer)
        {
            float distancia = Vector3.Distance(transform.position, positionPlayer.transform.position);
            //Debug.Log(distancia);
            if (distancia > outTarget)
            {
                //agent.SetDestination(transform.position);
                CambiarPunto();
                followingPlayer = false;
            }
            else
            {
                if (Time.time > lastTimeShoot + fireRate)
                {
                    lastTimeShoot = Time.time;
                    Instantiate(balaPFB, transform.position, transform.rotation);
                }
                Vector3 direccion = target.transform.position - transform.position;
                Quaternion Rotacion = Quaternion.LookRotation(direccion);
                transform.rotation = Quaternion.Slerp(transform.rotation, Rotacion, 8.0f * Time.deltaTime);
            }
        }
        else
        {
            float distanciaAutoma = Vector3.Distance(transform.position, point);
          
            if (distanciaAutoma<=3)
            {
                CambiarPunto();
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

    public float range = 10.0f;

    void CambiarPunto() {
        bool Enontrado = true;
        while (Enontrado) {
            if (RandomPoint(transform.position, range, out point))
            {
                agent.SetDestination(point);
                Enontrado = false;
            }
        }
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }
}
