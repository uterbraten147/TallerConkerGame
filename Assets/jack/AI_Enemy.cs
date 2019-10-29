using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Enemy : MonoBehaviour
{//START CLASS AI_Enemy
    //variables Publicas
    public float moveMagnitude = 0.05f;//Magnitud de movimiento
    public float movementSpeed = 0.5f;//velocidad de movimiento

    public float distanceAttack = 4.5f;//distancia de ataque
    public float distanceMoveTo = 13f;//distancia a la que el enemigo se va a acercar al player

    public float turnSpeed = 10f;//velocidad de giro
    public float patrolRange = 10f;//alcance de patrol


    //variables privadas 
    private float speedMoveMultiplayer = 1f;//Multiplicador de movimiento

    private int AiTime = 0;//tiempo de AI
    private int AiState = 0;//Estado de ai

    private Transform playerTarget;//objetivo de la Ai
    private Vector3 movementPosition;//Punto de movimiento

    private Movement_Motor motor;//Referencia del componente animator dentro del enemigo

    private Animator anim;//referencia del componente animator dentro del enemigo
    //parametro de Animator
   // private string PARAMETER_RUN = "Run";
   // private string PARAMETER_ATTACK_ONE = "Attack1";
    //private string PARAMETER_ATTACK_TWO = "Attack2";
    
    //Puntos de ataque 
    [SerializeField]
  //  private GameObject rightAttackPoint, leftAttackPoint;

    private void Awake()
    {
      
       // anim = GetComponent<Animator>();
        motor = GetComponent<Movement_Motor>();
    }

    private void Start()
    {

       // leftAttackPoint.SetActive(false);
    }

    private void Update()
    { 
        EnemyAI();
    } 

    void EnemyAI()
    {  float _distance = Vector3.Distance(movementPosition, transform.position);

         Quaternion _targetRotation = Quaternion.LookRotation(movementPosition - transform.position);
        _targetRotation.x = 0f;
        _targetRotation.z = 0f;

         transform.rotation = Quaternion.Lerp(transform.rotation, _targetRotation, turnSpeed * Time.deltaTime);

        if (playerTarget != null)
        {
            movementPosition = playerTarget.position;

            if (AiTime <= 0)
            {
                AiState = Random.Range(0, 4);
                AiTime = Random.Range(10, 100);
            }
            else
            {
                AiTime--;
            }

            if (_distance <= distanceAttack)
            {
                if (AiState == 0)
                {
                    Attack();
                }
                else
                {
                    if (_distance <= distanceMoveTo)
                    {
                        transform.rotation = Quaternion.Lerp(transform.rotation, _targetRotation, turnSpeed * Time.deltaTime);
                    }
                    else
                    {
                        playerTarget = null;

                        if (AiState == 0)
                        {
                            AiState = 1;
                            AiTime = Random.Range(10, 500);


                            movementPosition = transform.position +
                                new Vector3(Random.Range(-patrolRange, patrolRange), 0f,
                                Random.Range(-patrolRange, patrolRange));
                        }
                    }
                }
            }
        }
  
        else
        {
            GameObject _target = GameObject.FindGameObjectWithTag("Player");

            if (_target)
            {

                float _targetDistance = Vector3.Distance(_target.transform.position, transform.position);

                if (_targetDistance <= distanceMoveTo || _targetDistance <= distanceAttack)
                { 
                    playerTarget = _target.transform;
                }
            }
            if (AiState == 0)
            {//START IF
                AiState = 1;
                AiTime = Random.Range(10, 200);

              
                movementPosition = transform.position +
                    new Vector3(Random.Range(-patrolRange, patrolRange), 0f,
                    Random.Range(-patrolRange, patrolRange));
            } 

            if (AiTime <= 0)
            { 
                AiState = Random.Range(0, 4);
                AiTime = Random.Range(10, 200);
            } 
            else
            { 
                AiTime--;
            } 
        } 

       
        MoveToPosition(movementPosition, 1f, motor.charController.velocity.magnitude);
    } 

    void MoveToPosition(Vector3 _position, float _speedMult, float _magnitude)
    {
          float _speed = movementSpeed * speedMoveMultiplayer * 2 * 5 * _speedMult;

        
        Vector3 _direcction = _position - transform.position;
        
        _direcction.y = 0f;
 
        Quaternion _newRotation = transform.rotation;
         
        if (_direcction.magnitude > 0.1f)
        { 
            motor.Move(_direcction.normalized * _speed);
 
            _newRotation = Quaternion.LookRotation(_direcction);
             
            transform.rotation = Quaternion.Slerp(transform.rotation, _newRotation, turnSpeed * Time.deltaTime);
        } 
        else
        { 
            motor.Stop();

        } 

         
        AnimationMove(_magnitude * 0.1f);
         
    } 
        
    void AnimationMove(float _magnitude)
    { 
        /*
        if (_magnitude > moveMagnitude)
        { 
            float _speedAnimation = _magnitude * 2;

          
            if (_speedAnimation < 1)
                _speedAnimation = 1;
 
            if (!anim.GetBool(PARAMETER_RUN))
            { 
                
                anim.SetBool(PARAMETER_RUN, true);
            
                anim.speed = _speedAnimation;
            } 
        } 
        else
        { 
            if (anim.GetBool(PARAMETER_RUN))
            { 
                anim.SetBool(PARAMETER_RUN, false);
            } 
        } */
    } 

    void Attack()
    { 
        if (Random.Range(0, 2) > 0)
        { 
          //  anim.SetBool(PARAMETER_ATTACK_ONE, true);
        } 
        else
        { 
            
            //anim.SetBool(PARAMETER_ATTACK_TWO, true);
        }
    }
    
    void CheckIfAttackEnded()
    {  /*   if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack1"))
        {
           
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.8f)
            {
                anim.SetBool(PARAMETER_ATTACK_ONE, false);
                anim.SetBool(PARAMETER_RUN, false);
            }
        }
        */
        /*
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack2"))
        {
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.8f)
            {
            anim.SetBool(PARAMETER_ATTACK_TWO, false);
               
            anim.SetBool(PARAMETER_RUN, false);
            } 
        } */
    } 
    
  /*   
    void RigthAttackBegin()
    { 
        rightAttackPoint.SetActive(true);
    } 

     
    void RigthAttackEnd()
    { 
        rightAttackPoint.SetActive(false);
    } 
 
    void LeftAttackBegin()
    { 
        leftAttackPoint.SetActive(true);
    } 

    //Desactivamos el GameObject
    void LeftAttackEnd()
    { 
        leftAttackPoint.SetActive(false);
    } */
} 
