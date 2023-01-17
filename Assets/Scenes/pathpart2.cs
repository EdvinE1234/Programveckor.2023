using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathpart2 : MonoBehaviour
{
    [SerializeField]
    Transform[] waypoints;
    [SerializeField]
    float movespeed = 1f;

    int waypointindex = 0;

    public GameObject player;

    public float speed;

    public float rotationspeed;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypoints[waypointindex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       

        Move();

        Vector2 direction = waypoints[waypointindex].transform.position - transform.position;
        float angle = Vector2.SignedAngle(Vector2.up, direction);
        transform.eulerAngles = new Vector3(0, 0, angle);






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

