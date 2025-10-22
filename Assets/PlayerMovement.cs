using NUnit.Framework;
using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;

    public float sprintMultiplier = 1.1f;

    public Rigidbody2D rb;
    public float jumpForce = 5f;
    public bool isGrounded;
    
    void Start()
    {
        
    }

    void Update()
    {
        Movement();

        Sprint();

        Jump();
    }

    void Movement()
    {
        Vector2 direction = new Vector2(1, 0) * Input.GetAxisRaw("Horizontal");
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void Sprint()
    {
        Vector2 direction = new Vector2(1, 0) * Input.GetAxisRaw("Horizontal");

        if (direction.x != 0 && Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(direction * (speed * sprintMultiplier) * Time.deltaTime);
        }
    }
    
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpForce);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }
}
