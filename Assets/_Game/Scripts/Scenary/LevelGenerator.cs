using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform _levelPartStart;
    [SerializeField] private List<Transform> _levelPartList_1;
    [SerializeField] private List<Transform> _levelPartList_2;
    [SerializeField] private GameObject _playerGameObject;
    [SerializeField] private PlayerCollisions _playerCollisions;
    [SerializeField] private GameData _gameData;

    private Vector3 _playerPosition;
    private Vector3 _lastEndPosition;
    private float _playerDistanceToSpawn = 20F;
    private Transform _chosenLevelPart;


    private void Awake()
    {
        _lastEndPosition = _levelPartStart.Find("EndPosition").position;
        int startingSpawnLevelParts = 5;
        for (int i = 0; i < startingSpawnLevelParts; i++)
        {
            SpawnLevelPart();
        }
    }


    private void Update()
    {
        if (Vector3.Distance(_playerPosition, _lastEndPosition) < _playerDistanceToSpawn)
        {
            SpawnLevelPart();
        }
        if (_playerCollisions._playerIsAlive)
        {
            _playerPosition = _playerGameObject.transform.position;
        }
    }


    private void SpawnLevelPart()
    {
        switch (_gameData.Score)
        {
            case <= 50:
                _chosenLevelPart = _levelPartList_1[Random.Range(0, _levelPartList_1.Count)];
                break;

            case >= 51:
                _chosenLevelPart = _levelPartList_2[Random.Range(0, _levelPartList_2.Count)];
                break;
        }

        Transform lastLevelPartTransform = SpawnLevelPart(_chosenLevelPart, _lastEndPosition);
        _lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
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
