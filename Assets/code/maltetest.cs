using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maltetest : MonoBehaviour
{
    public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // din movement code

        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("moveup", true);
        }
        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("movedown", true);
        }
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("moveleft", true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("moveright", true);
        }

        
    }
}
