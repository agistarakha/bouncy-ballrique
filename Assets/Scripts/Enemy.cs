using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("InitialPush", 1);
        InvokeRepeating("PushBall", 4, 4);
    }
    // Update is called once per frame
    void Update()
    {
    }

    void PushBall()
    {
        rb.velocity = rb.velocity * 1.02f;
    }
    void InitialPush()
    {
        rb.velocity = new Vector2(4f, 4f);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            GameOverManager.Instance.ShowGameOverUI();
        }
    }
}
