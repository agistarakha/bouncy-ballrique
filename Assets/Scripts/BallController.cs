using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float movement_speed = 2f;
    public bool isInputAllowed = false;


    private Rigidbody2D ballRb;
    private Vector2 movement;
    private Vector3 mouseClickPosition;
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
        movement = Vector2.zero;
        cam = Camera.main;
        if (!isInputAllowed)
        {
            ballRb.velocity = new Vector2(5f, 5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Mendaaptkan posisi mouse klik
            mouseClickPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        movement = new Vector2(horizontalInput, verticalInput);
        // mouseClickPosition = transform.position;


    }


    void FixedUpdate()
    {

        //Akan aktif hanya pada problem yang ada input
        if (isInputAllowed)
        {
            if (movement != Vector2.zero)
            {
                //reset mouseclick ketika input keyboard
                mouseClickPosition = transform.position;
            }
            else
            {
                //Berjalan menuju ke posisi klik mouse
                ballRb.transform.position = Vector2.MoveTowards(transform.position, mouseClickPosition, Time.deltaTime * movement_speed);
            }
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
