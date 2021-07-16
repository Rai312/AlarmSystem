using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMover _mover;
    private int _positiveX = 1;
    private int _negativeX = -1;

    private void Start()
    {
        _mover = GetComponent<PlayerMover>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _mover.ChangeDirection(_negativeX);
        }

        if (Input.GetKey(KeyCode.D))
        {
            _mover.ChangeDirection(_positiveX);
        }
    }
}
