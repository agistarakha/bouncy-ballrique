using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject collectiblePrefab;

    private float horizontalBoundary = 4f;
    private float verticalBoundary = 3f;
    // Start is called before the first frame update
    void Start()
    {
        SpawnCollectibles();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnCollectibles()
    {
        int collectibleCount = Random.Range(3, 9);
        for (int i = 0; i < collectibleCount; i++)
        {
            Vector3 spawnPoint = new Vector3(
                Random.Range(-horizontalBoundary, horizontalBoundary),
                Random.Range(-verticalBoundary, verticalBoundary),
                0
            );
            Instantiate(collectiblePrefab, spawnPoint, Quaternion.identity);
        }
    }
}