using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject[] carPrefabs;
    public int poolSize;
    public float spawnInterval;
    public Transform player;
    public float despawnDistance;
    private float firstCarPosition;
    private Queue<GameObject> carPool = new Queue<GameObject>();

    private void Start()
    {

        for (int i = 0; i < poolSize; i++)
        {
            GameObject car = Instantiate(GetRandomCar(), Vector3.zero, Quaternion.identity);
            car.SetActive(false);
            carPool.Enqueue(car);
        }
        firstCarPosition = Random.Range(40f, 60f);
        SpawnCar();
    }

    private void Update()
    {
        if (player.position.z >= spawnInterval && firstCarPosition < player.position.z + 270f)
        {
            spawnInterval += 20;
            SpawnCar();
        }

        RecycleCars();
    }

    private void SpawnCar()
    {
        if (carPool.Count == 0) return;

        GameObject car = carPool.Dequeue();
        float RandomNumber = Random.Range(0, 2);
        if(RandomNumber == 0)
        {
            car.transform.position = new Vector3(2, 0, firstCarPosition);
            firstCarPosition += Random.Range(20f, 80f);
        }
        else
        {
            car.transform.position = new Vector3(-2, 0, firstCarPosition);
            firstCarPosition += Random.Range(20f, 80f);
        }
        
        car.SetActive(true);
        carPool.Enqueue(car);
    }

    private void RecycleCars()
    {
        foreach (var car in carPool)
        {
            if (car.activeInHierarchy && car.transform.position.z < player.position.z - despawnDistance)
            {
                car.SetActive(false);
            }
        }
    }

    private GameObject GetRandomCar()
    {
        return carPrefabs[Random.Range(0, carPrefabs.Length)];
    }
}
