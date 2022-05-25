using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
    public Rigidbody2D rb;
    private Collision coll;

    public float speed = 10;
    public float jumpForce = 20;

    private bool faceRight = true;

    void Start()
    {
        coll = GetComponent<Collision>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        //float xRaw = Input.GetAxisRaw("Horizontal");
        // float yRaw = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(x, y);
        Walk(dir);

        if (faceRight == false && x > 0)
        {
            flip();
        }
        else if (faceRight == true && x < 0)
        {
            flip();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (coll.onGround == true)
            {
                Jump(Vector2.up);
            }
        }




    }

    private void Walk(Vector2 dir)
    {
        rb.velocity = (new Vector2(dir.x * speed, rb.velocity.y));  
    }

    void flip()
    {
        faceRight = !faceRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    public void Jump(Vector2 dir)
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += dir * jumpForce;
    }
}
