using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class daodanmove : MonoBehaviour
{
    // Start is called before the first frame update

    public float _speed;
    private Transform _target;
    public float _rspeed;
    void Start()
    {
        _target = FindObjectOfType<PlayerMove>().transform;
    }

    // Update is called once per frame
    void Update()
    {


        var dir = _target.position - transform.position;


        transform.up = Vector3.MoveTowards(transform.up, dir, _rspeed * Time.deltaTime);




        transform.position = Vector3.MoveTowards(transform.position, _target.position + transform.up, _speed * Time.deltaTime);





    }
}
