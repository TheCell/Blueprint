using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    //List<GameObject> floorTiles = new List<GameObject>();
    private int nrOfObstacles;

    public Transform prefab;

    void Start()
    {
        List<GameObject> floorTiles = new List<GameObject>(GameObject.FindGameObjectsWithTag("floor_tile"));
        nrOfObstacles = (int) Mathf.Sqrt(floorTiles.Count);

        for(int i = 1; i <= nrOfObstacles; i++)
        {
            int randomIndex = Random.Range(0, floorTiles.Count);
            Vector3 spawnPosition = floorTiles[randomIndex].transform.position;
            Instantiate(prefab, spawnPosition, Quaternion.Euler(-90, 0, 0));
            floorTiles.RemoveAt(randomIndex);
        }
    }

    void Update()
    {
        
    }
}
