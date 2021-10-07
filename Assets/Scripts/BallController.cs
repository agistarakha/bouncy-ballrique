using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float movement_speed = 2f;
    public bool isInputAllowed = false;


    private Rigidbody2D ballRb;
    private Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
        movement = Vector2.zero;
        if (!isInputAllowed)
        {
            ballRb.velocity = new Vector2(5f, 5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        movement = new Vector2(horizontalInput, verticalInput);
    }


    void FixedUpdate()
    {
        if (isInputAllowed)
        {
            MoveBall();
        }

    }

    void MoveBall()
    {
        Vector2 direction = movement;
        //fungsi untuk menggerakan bola
        ballRb.MovePosition((Vector2)transform.position + (direction.normalized * movement_speed * Time.deltaTime));
    }
}
