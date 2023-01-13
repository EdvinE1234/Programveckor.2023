using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class punch : MonoBehaviour
{
    public Transform attackPoint;
    public float range = 0.5f;
    public LayerMask enemyLayers;
    public GameObject enemy;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {

            Attack();
        }
        

    }


    void Attack()
    {
        Collider2D[] hitenemies = Physics2D.OverlapCircleAll(attackPoint.position, range, enemyLayers);

       foreach (Collider2D enemy in hitenemies)
        {
            Destroy(enemy.gameObject);

            Debug.Log("penis");
        }
    }
       
        
}
