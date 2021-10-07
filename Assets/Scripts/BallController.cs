﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float movement_speed = 2f;


    private Rigidbody2D ballRb;
    // Start is called before the first frame update
    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //fungsi untuk menggerakan bola
        MoveBall(1f, 1f);

    }

    void MoveBall(float x, float y)
    {
        Vector2 direction = new Vector2(x, y);
        //fungsi untuk menggerakan bola
        ballRb.MovePosition((Vector2)transform.position + (direction * movement_speed * Time.deltaTime));
    }
}
