using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ainavmesh : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject target;
    private bool followingPlayer = false;
    private GameObject positionPlayer;
    public float outTarget;
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
            GameObject _target = GameObject.FindGameObjectWithTag("Player");
            float distancia = Vector3.Distance(transform.position, positionPlayer.transform.position);

            if (distancia > outTarget)
            {

                CambiarPunto();
                followingPlayer = false;
            }
            else
            {

                Vector3 direccion = target.transform.position - transform.position;
                Quaternion Rotacion = Quaternion.LookRotation(direccion);
                transform.rotation = Quaternion.Slerp(transform.rotation, Rotacion, 2.0f * Time.deltaTime);
            }
        }
        else
        {
            float distanciaAutoma = Vector3.Distance(transform.position, point);

            if (distanciaAutoma <= 3)
            {
                agent.SetDestination(target.transform.position);
               
            }else
            {
                CambiarPunto();
            }

        }
    }
    /*
    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            agent.SetDestination(col.gameObject.transform.position);
            positionPlayer = col.gameObject;
            followingPlayer = true;
        }
    }*/

    public float range = 10.0f;

    void CambiarPunto()
    {
        bool Econtrado = true;
        while (Econtrado)
        {
            if (RandomPoint(transform.position, range, out point))
            {
                agent.SetDestination(point);
                Econtrado = false;
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
