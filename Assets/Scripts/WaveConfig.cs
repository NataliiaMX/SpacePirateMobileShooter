using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] private List<GameObject> enemyPrefabs;
    [SerializeField] private Transform pathPrefab;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float timeBetweenEnemySpawns = 1f;
    [SerializeField] private float spawnTimeVariance = 0f;
    private float minimunSpawnTime = 0.2f;

    public Transform GetStartingWaypoint()
    {
        return pathPrefab.GetChild(0).transform;
    }
    public float GetMoveSpeed ()
    {
        return moveSpeed;
    }

    public List<Transform> GetAllWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform child in pathPrefab)
        {
            waypoints.Add(child);
        }
        return waypoints;
    }

    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int enemyIndex)
    {
        return enemyPrefabs[enemyIndex];
    }

    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(timeBetweenEnemySpawns - spawnTimeVariance, timeBetweenEnemySpawns + spawnTimeVariance);
        return Mathf.Clamp(spawnTime, minimunSpawnTime, float.MaxValue);
    }
}
