using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform levelPart_Start;
    [SerializeField] private List<Transform> levelPartList;
    [SerializeField] private GameObject playerGameObject;
    [SerializeField] private PlayerCollisions playerCollisions;

    private Vector3 playerPosition;
    private Vector3 lastEndPosition;
    private float playerDistanceToSpawn = 20F;


    private void Awake()
    {
        lastEndPosition = levelPart_Start.Find("EndPosition").position;
        int startingSpawnLevelParts = 5;
        for (int i = 0; i < startingSpawnLevelParts; i++)
        {
            SpawnLevelPart();
        }
    }


    private void Update()
    {
        if (Vector3.Distance(playerPosition, lastEndPosition) < playerDistanceToSpawn)
        {
            SpawnLevelPart();
        }
        if (playerCollisions._playerIsAlive)
        {
            playerPosition = playerGameObject.transform.position;
        }
    }


    private void SpawnLevelPart()
    {
        Transform chosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }


    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }


    //public void DestroyLevelParts()
    //{
    //    List<GameObject> levelParts= GameObject.FindGameObjectsWithTag("levelPart");

    //    for (var i = 0; i < levelParts.Length; i++)
    //    {
    //        Destroy(levelParts[i]);
    //    }
    //}
}
