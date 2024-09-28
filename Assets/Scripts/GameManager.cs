using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] Transform[] spawnPoints;

    [SerializeField] GameObject[] obstacles;

    [SerializeField] float spawnRate;

    [SerializeField] float startSpawnTime;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), startSpawnTime, spawnRate);
    }


    public void SpawnObstacle()
    {
        int randomLane = Random.Range(0, spawnPoints.Length);
        int randomObstacle = Random.Range(0, obstacles.Length);

        Instantiate(obstacles[randomObstacle], spawnPoints[randomLane]);


    }


    public void LoseGame()
    {
        print("lose game");
    }
}
