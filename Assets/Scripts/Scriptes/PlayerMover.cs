using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _stepSize;

    [SerializeField] private Transform _leftLimiter;
    [SerializeField] private Transform _rightLimiter;

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

    public void MoveLeft()
    {
        if (Vector2.Distance(_leftLimiter.position, _targetPosition) >= 4)
        {
            SetNextPosition(_stepSize);
        }
    }

    public void MoveRight()
    {
        if (Vector2.Distance(_rightLimiter.position, _targetPosition) >= 4)
        {
            SetNextPosition(-_stepSize);
        }
    }

    private void SetNextPosition(float stepSize)
    {
        _targetPosition = new Vector2(transform.position.x - stepSize, transform.position.y);
    }
}
