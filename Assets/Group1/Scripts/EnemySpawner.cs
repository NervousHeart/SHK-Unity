using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private int _countEnemy;

    public int CountEnemy => _countEnemy;

    private void Start()
    {
        for (int i = 0; i < _countEnemy; i++)
        {
            Instantiate(_enemyPrefab, GetRandomPosition(), Quaternion.identity);
        }
    }

    private Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0);
    }
}
