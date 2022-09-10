using UnityEngine;
using System.Collections.Generic;

public class LevelPart : MonoBehaviour
{
    [SerializeField] private GameObject _appleCollectable;
    [SerializeField] private GameObject _pineappleCollectable;
    [SerializeField] private int _collectablesAmount;
    [SerializeField] private List<Transform> _collectablesLocations;
    private int _collectablesLocationsIndex;
    private int _randomCollectable;

    void Start()
    {
        RandomInstantiate();
        Destroy(gameObject, 16);
    }

    private void RandomInstantiate()
    {
        for (int i = 0; i < _collectablesAmount; i++)
        {
            _collectablesLocationsIndex = Random.Range(0, _collectablesLocations.Count);
            _randomCollectable = Random.Range(0, 100);

            if (_randomCollectable >= 97)
            {
                Instantiate(_pineappleCollectable, _collectablesLocations[_collectablesLocationsIndex]);
            }
            else
            {
                Instantiate(_appleCollectable, _collectablesLocations[_collectablesLocationsIndex]);
            }
            _collectablesLocations.RemoveAt(_collectablesLocationsIndex);
        }
    }
}
