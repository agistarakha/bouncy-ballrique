using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance = null;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }
    public GameObject collectiblePrefab;
    public bool respawnAllowed = true;

    private GameObject ball;


    private float horizontalBoundary = 4f;
    private float verticalBoundary = 3f;
    // Start is called before the first frame update
    void Start()
    {
        ball = FindObjectOfType<BallController>().gameObject;
        SpawnCollectibles();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnCollectibles()
    {
        int collectibleCount = Random.Range(3, 8);
        for (int i = 0; i < collectibleCount; i++)
        {
            Vector3 spawnPoint = GenerateSpawnPoint();
            GameObject spawnedPrefab = Instantiate(collectiblePrefab, spawnPoint, Quaternion.identity);
        }
    }

    public Vector3 GenerateSpawnPoint()
    {
        bool isSpawnPointAllowed = false;
        Vector3 spawnPoint = new Vector3();
        while (!isSpawnPointAllowed)
        {
            spawnPoint = new Vector3(
                    Random.Range(-horizontalBoundary, horizontalBoundary),
                    Random.Range(-verticalBoundary, verticalBoundary),
                    0
                );
            float xBallDistance = Mathf.Abs(spawnPoint.x) - Mathf.Abs(ball.transform.position.x);
            float yBallDistance = Mathf.Abs(spawnPoint.y) - Mathf.Abs(ball.transform.position.y);

            if (Mathf.Abs(xBallDistance) > 1)
            {
                isSpawnPointAllowed = true;
            }
            else if (Mathf.Abs(yBallDistance) > 1)
            {
                isSpawnPointAllowed = true;
            }


        }
        return spawnPoint;
    }

}