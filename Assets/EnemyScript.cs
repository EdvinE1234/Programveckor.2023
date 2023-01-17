using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    Transform player;

    [SerializeField]
    Transform castPoint;

    [SerializeField]
    float agroRange;

    [SerializeField]
    float moveSpeed;

    Rigidbody2D rb2d;

    bool isfacingleft;

    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CanSeePlayer(agroRange))
        {
            ChasePlayer();
        }
        else
        {
            StopChasingPlayer();
        }

        float distToPlayer = Vector2.Distance(transform.position, player.position);

         if (distToPlayer < agroRange)
          {
              ChasePlayer();
          }
          else
          {
              StopChasingPlayer();
          }
    }


        void AimToPlayer()
    {
        Vector3 playerPosition = player.position;
        Vector2 direction = playerPosition - transform.position;
        float angle = Vector2.SignedAngle(Vector2.up, direction);
        transform.eulerAngles = new Vector3(0, 0, angle);
    }

       void ChasePlayer()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, moveSpeed * Time.deltaTime);
    } 

    void StopChasingPlayer()
    {
        rb2d.velocity = new Vector2(0, 0);
    }
    
   
    
    bool CanSeePlayer(float distance)
    {
        
        float castDist = distance;
        bool val = false;

        if(isfacingleft == true)
        {
            castDist = -distance;
        }

        Vector2 endPos = castPoint.position + transform.up * castDist;
        RaycastHit2D hit = Physics2D.Linecast(castPoint.position, endPos, 1 << LayerMask.NameToLayer("Action"));

        if(hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                val = true;
                 ChasePlayer();
                 AimToPlayer();
                Destroy(hit.collider.gameObject);
                
            }
            else
            {
                val = false;
               StopChasingPlayer();
            }
            Debug.DrawLine(castPoint.position, hit.point, Color.green);

        }
        else
        {
            Debug.DrawLine(castPoint.position, endPos, Color.red);
        }

        return val;
    }

    
    

}
