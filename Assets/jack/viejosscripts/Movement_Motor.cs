using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Motor : MonoBehaviour
{
    public float gravityMultiplier = 1f;//multiplicador de gravedad 
    public float lerpTime = 10f;

    private Vector3 moveDirection = Vector3.zero;
    private Vector3 targetDirection = Vector3.zero;
    private float fallVelocity = 0f;

    [HideInInspector]
    public CharacterController charController;

    public float distanceToGround;
    private bool isGrounded;

    private Collider myCollider;

    private void Awake()
    {//
        charController = GetComponent<CharacterController>();

        myCollider = GetComponent<Collider>();

    }

    private void Start()
    {//START Start

        distanceToGround = myCollider.bounds.extents.y;
    }//END Start

    private void Update()
    {//START Update
        //deteccion de la tierra tomando en cuenta la funcion
        isGrounded = OnGroundCheck();

        //valor de movimiento
        moveDirection = Vector3.Lerp(moveDirection, targetDirection, Time.deltaTime * lerpTime);

        //Movimiento en y
        moveDirection.y = fallVelocity;

        //aplicacion de movimiento
        charController.Move(moveDirection * Time.deltaTime);

        //"Gravedad"
        if (!isGrounded)
        {//START
            //Disminuir el valor de fallvelocity
            fallVelocity -= 90 * gravityMultiplier * Time.deltaTime;
        }//END
    }//END Update

    public bool OnGroundCheck()
    {//START OnGroundCheck
        //Informacion de contacto
        RaycastHit _hit;

        //Validacion del character controller con el piso
        if (charController.isGrounded)
        {//START  if
            return true;
        }

        //validaciom con raycast
        if (Physics.Raycast(myCollider.bounds.center, -Vector3.up, out _hit, distanceToGround + 0.1f))
        {//START if
            //el rayo esta tocando la tierra 
            return true;
        }//END if
        //si no se cumplen las validaciones. no estamos en la tierra
        return false;
    }//END OnGroundCheck

    public void Move(Vector3 _dir)
    {//START Move
        //Igualamos el punto final de direccion con una direccion
        //Esto se va a comunicar con los inputs del jugador
        targetDirection = _dir;
    }//END Move

    public void Stop()
    {//START Stop
        //frenaremos el movimiento dando un valor de 0 a los vectores 
        moveDirection = Vector3.zero;
        targetDirection = Vector3.zero;

    }//END Stop

    public void Jump(float _jumpValue)
    {//Start 
        if (isGrounded)
        {//START IF
            //Igualamos la velocidad de caida
            fallVelocity = _jumpValue;
        }//END IF
    }//END
}
