using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snakemovement : MonoBehaviour
{

    public float speed = 1f;
    Rigidbody2D myRB;
    Vector3 dir = new Vector3(0, 0, 0);

    public List<Transform> segments; //different part of the body
    public Transform snakebodyPrefab;
    public List<Vector3> PositionHistory;


    // Start is called before the first frame update
    void Start()
    {
        segments = new List<Transform>();
        segments.Add(this.transform);
     //   InvokeRepeating("StorePosition", 0f, .5f);
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }

        dir = Direction();
        transform.Translate(dir * speed);

        //check segement positions, if a segment is placed within the original square, turn off the box collider and/or ignore collision
        //basically we don't want any self-intersecting hits to kill the snake
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

    private void Grow()
    {
        Transform segment = Instantiate(this.snakebodyPrefab);
        segment.position = segments[segments.Count - 1].position;
        segments.Add(segment);
    }

    /* void StorePosition()
     {
         for (int i = segments.Count - 1; i > 0; i--)
         {
             segments[i].position = segments[i - 1].position;
         }
         //check the current length of the segements List and use that to delete old unnecessary data out of the PositionHistory list
         Debug.Log("stored a new Pos");

         //NOTE: count backwards from last item to first when using this PositionHistory list to spawn segments
         PositionHistory.Add(transform.position);
     }
    */
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Food"))
        {
            Grow();
        }
    }
}
