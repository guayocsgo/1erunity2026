
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;

    
    public float laneWidth = 3f;
    private float[] lanePositionsX;

    private void Start()
    {
        
        lanePositionsX = new float[]
        {
            -laneWidth,  
             0f,         
             laneWidth   
        };

        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnObstacle();
        SpawnCoin();
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2);
    }

    public GameObject obsctalcePrefab;
    void SpawnObstacle()
    {
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
        Instantiate(obsctalcePrefab, spawnPoint.position, Quaternion.identity, transform);
    }

    public GameObject coinPrefab;
    void SpawnCoin()
    {
        int coinToSpawn = 10;
        for (int i = 0; i < coinToSpawn; i++)
        {
            GameObject temp = Instantiate(coinPrefab, transform);
            temp.transform.position = GetRandomPointInLane();
        }
    }

    Vector3 GetRandomPointInLane()
    {
        Collider collider = GetComponent<Collider>();

        
        int randomLane = Random.Range(0, lanePositionsX.Length);
        float laneX = lanePositionsX[randomLane];

        
        float randomZ = Random.Range(collider.bounds.min.z, collider.bounds.max.z);

        return new Vector3(laneX, 1f, randomZ);
    }
}

