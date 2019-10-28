using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float life;
    public float Velocidad;
    private Rigidbody rigPlayer;

    void Start()
    {
        rigPlayer = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float MoverHorizontal = Input.GetAxis("Horizontal");
        float MoverVertical = Input.GetAxis("Vertical");


        Vector3 movimiento = new Vector3(MoverHorizontal, 0.0f, MoverVertical);

        rigPlayer.AddForce(movimiento * Velocidad);
    }

    public void ReciveDamege(float dano) {
        life -= dano;
        Debug.Log("Recivi daño");
    }
}
