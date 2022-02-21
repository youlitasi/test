using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public sealed class move : MonoBehaviour
{



    public Rigidbody2D rig;

    public  float ve;

    public float ve2;
    public float moveSpeed;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
      
       


    }





    void FixedUpdate()
    {

        ve = Input.GetAxis("Horizontal");
        ve2 = Input.GetAxis("Vertical");
        rig.velocity = new Vector2(ve * moveSpeed, ve2 * moveSpeed);
        if (ve < 0)
        {

            transform.localScale = new Vector3(-1, 1, 1);

        }

        if (ve > 0) 
        {


            transform.localScale = new Vector3(1, 1, 1);


        }
        Debug.Log(ve);

    }
}