using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(2);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}   
