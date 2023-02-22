using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public AudioSource footstepsSound;
    [SerializeField]
    float playerspeed = 10f;
    Rigidbody2D rb2d;
    public Animator animator;
    float moveH = 0f;
    float moveV = 0f;
    //får fram rigidbodyn - hugo
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    //vrider spelaren dit muspekaren är på skärmen - hugo
    void AimToMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = mousePosition - transform.position;
        float angle = Vector2.SignedAngle(Vector2.up, direction);
        transform.eulerAngles = new Vector3(0, 0, angle);

    }


    //MoveH använder mathF för att känna av när spelaren rör på sig för att trigga en animation. -hugo
    //AimToMouse sitter också i update. - hugo
    //philip fixade sound effects
    void Update()
    {
        moveH = Input.GetAxisRaw("Horizontal") * playerspeed;
        moveV = Input.GetAxisRaw("Vertical") * playerspeed;

        animator.SetFloat("speed", Mathf.Abs(moveH));
        animator.SetFloat("speed", Mathf.Abs(moveV));

        AimToMouse();
        if (Input.GetKey(KeyCode.W))
        {
            rb2d.AddForce(Vector2.up * playerspeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb2d.AddForce(Vector2.down * playerspeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb2d.AddForce(Vector2.right * playerspeed * Time.deltaTime);
            animator.SetFloat("speed", Mathf.Abs(moveH));
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb2d.AddForce(Vector2.left * playerspeed * Time.deltaTime);
            animator.SetFloat("speed", Mathf.Abs(moveH));


            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                footstepsSound.enabled = false;
            }

            else
            {
                footstepsSound.enabled = true;
                
            }
        }
    }
}
