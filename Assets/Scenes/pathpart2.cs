using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathpart2 : MonoBehaviour
{
    [SerializeField]
    Transform[] waypoints;
    [SerializeField]
    float movespeed = 2f;

    int waypointindex = 0;

    public GameObject player;

    public float speed;

    public float rotationModifier;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypoints[waypointindex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       

        Move();

        

    
    

}
    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointindex].transform.position, movespeed * Time.deltaTime);
        if (transform.position== waypoints[waypointindex].transform.position)
        {
            waypointindex += 1;
        }
        if (waypointindex== waypoints.Length)
        {
            waypointindex = 0;
        }
    }

}

