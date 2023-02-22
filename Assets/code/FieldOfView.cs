using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{

    public GameObject deathMenu;
    public float radius = 5f;
    [Range(1, 360)]public float angle = 45f; //Fiendens range f�r att uppt�cka spelaren - Samuel

    //Lager f�r att veta om fienden kan uppt�cka spelaren - Samuel
    public LayerMask targetLayer;
    public LayerMask obstructionLayer;

    public Animator animator;

    [SerializeField]
    Transform player;

    [SerializeField]
    float moveSpeed;

    Rigidbody2D rb2d;

    private float distance;


    public GameObject playerRef;

    [SerializeField]
    Transform[] waypoints;
    [SerializeField]
    float movespeed = 1f;

    int waypointindex = 0;

    public bool CanSeePlayer { get; private set; }

    void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player"); 
        StartCoroutine(FOVCheck());
        transform.position = waypoints[waypointindex].transform.position;
        
    }
   //V�ntar innan den kollar igen om det finns n�got innan f�r dess range - Samuel
   private IEnumerator FOVCheck()
    {
        WaitForSeconds wait = new WaitForSeconds(0.0001f);

        while (true)
        {
            yield return wait;
            FOV();
        }
    }
    //Slutar jaga spelaren - Samuel
    void StopChasingPlayer()
    {
        rb2d.velocity = new Vector2(0, 0);
    }
    //Kollar efter spelaren - Samuel
    private void FOV() 
    {
        Collider2D[] rangeCheck = Physics2D.OverlapCircleAll(transform.position, radius, targetLayer); 

        if (rangeCheck.Length > 0)
        {
            Transform target = rangeCheck[0].transform;
            Vector2 directionToTarget = (target.position - transform.position).normalized; 

            if(Vector2.Angle(transform.up, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector2.Distance(transform.position, target.position); 
                if(!Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionLayer)) //Kollar om spelaren �r inom fiendens range - Samuel
                {
                    CanSeePlayer = true; //V�nder sig till och jagar spelaren n�r den ser den - Samuel
                    AimToPlayer(); //V�nder sig mot spelaren - Samuel
                    ChasePlayer(); //Jagar spelaren - Samuel
                    
                    
                }
                else
                {
                    CanSeePlayer = false;
                    
                    
                }
            }
            else
            {
                CanSeePlayer = false;
            }
        }
        else if (CanSeePlayer)
        {
            CanSeePlayer = false;
            
        }

        
    }
    
    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (CanSeePlayer == true && collision.gameObject.tag == "Player")
        {
            
            deathMenu.SetActive(true);
            animator.Play("deathmenuanim");
            

        }
    }

    //Fienden v�nder sig mot spelaren n�r den uppt�cker den - Samuel
    void AimToPlayer()
    {
        
        Vector3 playerPosition = player.position;
        Vector2 direction = playerPosition - transform.position;
        float angle = Vector2.SignedAngle(Vector2.up, direction);
        transform.eulerAngles = new Vector3(0, 0, angle);
    }

    void AimToWaypoint()
    {   // G�r s� att fienden kollar mot n�sta waypoint - William A
        Vector2 direction = waypoints[waypointindex].transform.position - transform.position;
        float angle = Vector2.SignedAngle(Vector2.up, direction);
        transform.eulerAngles = new Vector3(0, 0, angle);
    }        
    //Jagar spelaren n�r den uppt�cker den - Samuel
    void ChasePlayer()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, moveSpeed * Time.deltaTime);
    }

    
    //Samuel
    private Vector2 DirectionFromAngle(float eulerY, float angleInDegrees)
    {
        angleInDegrees += eulerY;

        return new Vector2(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }

    void WaypointMove()
    {
        // g�r s� att fienden g�r mot n�sta waypoint i sin cycle(loopar n�r den �r klar) - William A
        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointindex].transform.position, movespeed * Time.deltaTime);
        if (transform.position == waypoints[waypointindex].transform.position)
        {
            waypointindex += 1;
        }
        if (waypointindex == waypoints.Length)
        {
            waypointindex = 0;
        }
    }

    

    void Update()
    {   
        if (CanSeePlayer == false)
        {
            WaypointMove();
            AimToWaypoint();
        }
        
        

        
    }
}
