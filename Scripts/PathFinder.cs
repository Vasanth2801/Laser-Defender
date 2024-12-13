using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WavesConfigurationSO wavesConfiguration;
    List<Transform> waypoints;
    int waypointIndex = 0;

     void Awake()
    {
       enemySpawner = FindObjectOfType<EnemySpawner>(); 
    }
    void Start()
    {
        wavesConfiguration = enemySpawner.GetCurrentWave();
        waypoints = wavesConfiguration.GetWayPoints();
        transform.position = waypoints[waypointIndex].position;
    }

   
    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if(waypointIndex < waypoints.Count)
        {
            Vector3 targetPosition = waypoints[waypointIndex].position;
            float delta = wavesConfiguration.GetMoveSpeed()*Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if(transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
