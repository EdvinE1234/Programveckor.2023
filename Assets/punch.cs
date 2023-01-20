using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class punch : MonoBehaviour
{
    public AudioSource hit;
    public AudioSource miss;
    public Transform attackPoint;
    public float range = 0.5f;
    public LayerMask enemyLayers;
    public GameObject enemy;
    
    public Animator animator;
    public Animator enemyanimator;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("kick", true);
            Attack();

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("kick", false);

           miss.Play();
        }


    }
    


    void Attack()
    {
        Collider2D[] hitenemies = Physics2D.OverlapCircleAll(attackPoint.position, range, enemyLayers);

        foreach (Collider2D enemy in hitenemies)
        {
            
            Destroy(enemy.gameObject, 1.6f);
            död();

            Debug.Log("penis");

            hit.Play();
            
        }
    }
    [ContextMenu(itemName: "död")]
    public void död()
    {
        enemyanimator.Play("vaktdö");
        

    }
       
        
}
