using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public GameObject roadPrefab;
    public int roadCount;
    public float roadLength = 24f;

    private Queue<GameObject> roadPool = new Queue<GameObject>();
    private Transform player;
    private float spawnZ = 0f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < roadCount; i++)
        {
            GameObject road = Instantiate(roadPrefab, new Vector3(0, 0, spawnZ), Quaternion.identity);
            roadPool.Enqueue(road);
            spawnZ += roadLength;
        }
    }

    private void Update()
    {
        if (player.position.z - 2 * roadLength > roadPool.Peek().transform.position.z)
        {
            RecycleRoad();
        }
    }

    private void RecycleRoad()
    {
        GameObject oldRoad = roadPool.Dequeue();
        oldRoad.transform.position = new Vector3(0, 0, spawnZ);
        spawnZ += roadLength;
        roadPool.Enqueue(oldRoad);
    }
}
