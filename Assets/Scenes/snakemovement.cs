using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakemovement : MonoBehaviour
{

    public float speed = 1f;
    Rigidbody2D myRB;
    Vector3 dir = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dir = Direction();

        transform.Translate(dir * speed);
    }

    Vector3 Direction()
    {
        
        Vector3 v = Vector3.zero;
       
        if (Input.GetKey(KeyCode.W))
        { v += Vector3.up; }
        else if (Input.GetKey(KeyCode.S))
        { v += Vector3.down; }

        
        if (Input.GetKey(KeyCode.D))
        { v += Vector3.right; }
        else if (Input.GetKey(KeyCode.A))
        { v += Vector3.left; }

        //return our desired direction after all WASD checks  
        return v;
    }
}
