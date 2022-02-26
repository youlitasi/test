using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update

    public PolyNav2D poly;
    public PolyNavObstacle ob;
    public float time;
    void Start()
    { ob = GetComponent<PolyNavObstacle>();
        poly = FindObjectOfType<PolyNav2D>();
        poly.AddObstacle(ob);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;



       
        if (time == 1)
        {

            poly.RemoveObstacle(ob);

        }
    }
}
