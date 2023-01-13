using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float playerspeed = 10f;
    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void AimToMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = mousePosition - transform.position;
        float angle = Vector2.SignedAngle(Vector2.up, direction);
        transform.eulerAngles = new Vector3(0, 0, angle);

    }


    // Update is called once per frame
    void Update()
    {
        AimToMouse();
        if (Input.GetKey(KeyCode.W))
        {
            rb2d.AddForce(Vector2.up * playerspeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb2d.AddForce(Vector2.down * playerspeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb2d.AddForce(Vector2.right * playerspeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb2d.AddForce(Vector2.left * playerspeed);
        }
    }
}
