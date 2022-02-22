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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rig.AddForce(new Vector2(10, 10),ForceMode2D.Impulse);
        }
    }



    void FixedUpdate()
    {

      




        ve = Input.GetAxis("Horizontal");
        ve2 = Input.GetAxis("Vertical");
        rig.velocity += new Vector2(ve * moveSpeed, ve2 * moveSpeed);
        if (ve < 0)
        {

            transform.localScale = new Vector3(-1, 1, 1);

        }

        if (ve > 0) 
        {


            transform.localScale = new Vector3(1, 1, 1);


        }
        

    }
}