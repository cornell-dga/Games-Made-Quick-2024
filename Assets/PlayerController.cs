using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D myRB;
    public GameObject laserPrefab;
    public float laneSwapSpeed;
    public float laserOffset;
    public float percentDistanceFromTop;
    public int maxLaserCharges;
    public int startLane;
    private float[] laneHeights;
    private int laserCharges;
    private int laneTarget;

    // Start is called before the first frame update
    void Start()
    {
        laneTarget= startLane;
        laserCharges = 0;
        laneHeights = new float[5];
        float top = 2.5f;
        for (int i = 0; i < 5; i++)
        {
            laneHeights[i] = top - i*1.25f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, laneHeights[laneTarget]), laneSwapSpeed);
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
            // move down
            if (laneTarget == 4) return;
            laneTarget++;
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
            // move up
            if (laneTarget == 0) return;
            laneTarget--;
        }
    }

    public void AddLaser()
    {
        laserCharges++;
        laserCharges = Math.Max(laserCharges, maxLaserCharges);
    }

    public void TryToShootLaser()
    {
        if (laserCharges == 0) return;
        laserCharges--;
        GameObject.Instantiate(laserPrefab, transform.position + Vector3.right*laserOffset, Quaternion.identity);
    }
}
