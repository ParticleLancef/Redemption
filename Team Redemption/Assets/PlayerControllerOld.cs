using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerOld : MonoBehaviour
{
    public float jumpForce;

    public float speed = 5f;
    private Rigidbody2D rbPlayer;

    

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJump;
    public int extraJumpValue;

    public float accelration = 1f;
    public float maxSpeed = 10f;

    private void Start()
    {
        extraJump = extraJumpValue;
        rbPlayer = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            speed += accelration * Time.deltaTime;
            if (speed > maxSpeed)
            {
                speed = maxSpeed;
            }
            rbPlayer.GetComponent<SpriteRenderer>().flipX = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            rbPlayer.GetComponent<SpriteRenderer>().flipX = false;
        }


        

        if (isGrounded == true)
        {
            extraJump = extraJumpValue;
        }


        if (Input.GetKeyDown(KeyCode.Space) && extraJump > 0)
        {
            rbPlayer.velocity = Vector2.up * jumpForce;
            extraJump--;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJump == 0 && isGrounded == true)
        {
            rbPlayer.velocity = Vector2.up * jumpForce;
        }

        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "TempPlatform")
        {
            gameObject.transform.parent = other.gameObject.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "TempPlatform")
        {
            gameObject.transform.parent = null;
        }
    }

}

        


