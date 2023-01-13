using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class path : MonoBehaviour
{
    [SerializeField]
    private Transform[] waypoints;

    [SerializeField]
    private float movespeed = 2f;

    private int waypointindex = 0;


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
    private void Move()
    {
        if (waypointindex <= waypoints.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointindex].transform.position, movespeed * Time.deltaTime);
        }
        if (transform.position == waypoints[waypointindex].transform.position)
        {
            waypointindex += 1;
        }
        {

        }
    }
}