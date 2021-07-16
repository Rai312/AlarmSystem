using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _stepSize;

    private Vector3 _targetPosition;

    private void Start()
    {
        _targetPosition = transform.position;
    }

    private void Update()
    {
        if (_targetPosition != transform.position)
            transform.position = Vector2.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
    }

    public void ChangeDirection(int xDirection)
    {
        SetNextPosition(-_stepSize * xDirection);
    }

    private void SetNextPosition(float stepSize)
    {
        _targetPosition = new Vector2(transform.position.x - stepSize, transform.position.y);
    }
}
