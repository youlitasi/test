using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class emove : MonoBehaviour
{
    private Transform _target;
    // Start is called before the first frame update
    private PolyNavAgent _agent;
    public PolyNavAgent agent
    {
        get
        {
            if (!_agent)
                _agent = GetComponent<PolyNavAgent>();
            return _agent;
        }
    }
    void Start()
    {
        _target = FindObjectOfType<PlayerMove>().transform;
    }



   

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(_target.position);
        var dir = _target.position - transform.position;

        if (dir.x > 0)
        {

            transform.localScale = new Vector3(-1, 1, 1);

            

        }
        else 
        {
            transform.localScale = new Vector3(1, 1, 1);


        }




        float dis = Vector3.Distance(transform.position, _target.position);

        if (dis < 0.75)
        {

            agent.Stop();

          

        }
     

    }
}
