using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _speedAcceleration;
    [SerializeField] private float _time;

    private Coroutine _acceleration;
    private float _maxSpeed;
    private float _startSpeed;

    public event UnityAction CountEnemyChanged;

    private void Start()
    {
        _startSpeed = _speed;
        _maxSpeed = _speed * _speedAcceleration;
    }

    private void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * _speed, Input.GetAxis("Vertical") * Time.deltaTime * _speed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out var Enemy))
        {
            StartAcceleration();
            CountEnemyChanged?.Invoke();
        }
    }

    private void StartAcceleration()
    {
        _speed = _startSpeed;
        _acceleration = StartCoroutine(Acceleration());
        if (_acceleration != null)
            StopCoroutine(_acceleration);
        StartCoroutine(Acceleration());
    }

    private IEnumerator Acceleration()
    {
        _speed = Mathf.Clamp(_speed * _speedAcceleration, 0, _maxSpeed);
        yield return new WaitForSeconds(_time);
        _speed = _startSpeed;
    }

}
