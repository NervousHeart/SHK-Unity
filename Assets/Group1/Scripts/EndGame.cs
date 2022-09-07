using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private GameObject _endScreen;
    [SerializeField] private Player _player;

    private int _countEnemy;

    private void Start()
    {
        _countEnemy = _enemySpawner.CountEnemy;
        _player.CountEnemyChanged += OnCountEnemyChanged;
    }

    private void OnCountEnemyChanged()
    {
        _countEnemy--;
        if (_countEnemy == 0)
            _endScreen.SetActive(true);
    }
}
