using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider2D foodrange;

    // Start is called before the first frame update
     void Start()
    {
        randomPosition();
    }

    // Update is called once per frame
    void Update()
    {
       // randomPosition();
    }

    private void randomPosition()
    {
       
        Bounds bounds = foodrange.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        transform.position = new Vector3(x, y, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            randomPosition();
        }
    }
}
