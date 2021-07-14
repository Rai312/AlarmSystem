using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMover _mover;

    private void Start()
    {
        _mover = GetComponent<PlayerMover>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _mover.MoveLeft();
        }

        if (Input.GetKey(KeyCode.D))
        {
            _mover.MoveRight();
        }
    }
}
