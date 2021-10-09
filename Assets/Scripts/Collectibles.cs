using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{

    private float respawnDuration = 3.0f;
    private float timer = 0;
    private BoxCollider2D collectibleCollider;
    private bool isCollected;

    void Awake()
    {
        isCollected = false;
        collectibleCollider = GetComponent<BoxCollider2D>();
    }


    void Update()
    {
        if (isCollected)
        {
            if (timer < respawnDuration)
            {
                timer += Time.deltaTime;
            }
            else
            {
                if (GameManager.Instance.respawnAllowed)
                {
                    Respawn();

                }
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            ScoreManager.score += 1;
            // gameObject.SetActive(false);
            isCollected = true;
            collectibleCollider.enabled = false;
            transform.localScale = Vector3.zero;
        }
    }

    private void Respawn()
    {
        gameObject.transform.position = GameManager.Instance.GenerateSpawnPoint();
        // gameObject.SetActive(true);
        transform.localScale = Vector3.one;
        collectibleCollider.enabled = true;
        timer = 0;
        isCollected = false;
    }
}
