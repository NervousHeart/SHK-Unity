using System;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    private Vector3 _target;

    private void Start()
    {
        _target = Random.insideUnitCircle * 4;
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, 2 * Time.deltaTime);
        if (transform.position == _target)
            _target = Random.insideUnitCircle * 4;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out var Player))
        {
            Destroy(gameObject);
        }
    }
}
