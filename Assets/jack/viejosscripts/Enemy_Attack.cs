using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack : MonoBehaviour
{//START CLASS MG2_EnemyAttack
    //Variables publicas 
    public LayerMask playerLayer;//layer añ que pertenece el jugador 
    public float damage = 1f;//cantidad de daño a infringir
    public float radius = 0.3f;//Radio de la esfera de deteccion

    //Variables privadas
   // private Player_Health playerHealth;//referencia de script Player_Health
    private bool collided;//bool que indicara si colisionamos con el jugador

    private void Update()
    {//START Update
        //Llamda de metodo CheckForDamage
        CheckForDamage();
    }//END Update

    void CheckForDamage()
    {//START CheckForDamage
        //Vamos a generar un arreglo de collisiones 
        //E integramos una esfera hecha de fisicas para deteccion 
        Collider[] _hits = Physics.OverlapSphere(transform.position, radius, playerLayer);
        foreach (Collider _h in _hits)
        {//START foreach
            //La colision asignara el valor de enemyHealth si esta encuentra el script
            //como componente del objeto con el que se choca 
          //  playerHealth = _h.GetComponent<Player_Health>();

            //Si de le dio un valor a enemyHealth
         /*   if (playerHealth)
            {//START IF
                //le estamos pegando a algo valido
                collided = true;
            }//END IF*/
        }//END foreach

        //si le pegamos a algo valido (enemigo)
        if (collided)
        {//START IF
            //Se va a desactivar el collided con el fin de evitar dqaño miltiple
            collided = false;

            //LLamada al metodo que hara daño al enemigo 
         //  playerHealth.TakeDamage(damage);
            //desactivar GameObject
            gameObject.SetActive(false);
        }//END IF

    }//END CheckForDamage
}//END CLASS MG2_EnemyAttack
