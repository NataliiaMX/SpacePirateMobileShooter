using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    private EnemySpawner enemySpawner;
    private WaveConfig waveConfig;
    private List<Transform> waypoints;
    private int currentWaypointIndex = 0;

    private void Awake() 
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }
    private void Start() 
    {
        waveConfig = enemySpawner.GetCurrentWave();
        waypoints = waveConfig.GetAllWaypoints();
        transform.position = waypoints[currentWaypointIndex].position;
    }

    private void Update() 
    {
        FollowPath();
    }

    private void FollowPath()
    {
        if(currentWaypointIndex < waypoints.Count)
        {
            Vector3 targetPosition = waypoints[currentWaypointIndex].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;//distance we move each frame
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if(transform.position == targetPosition)
            {
                currentWaypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
