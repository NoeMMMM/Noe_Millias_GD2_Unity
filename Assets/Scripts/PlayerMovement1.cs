using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement1 : MonoBehaviour
{
    private Rigidbody _rb;
    private float _horizontalMovement;
    private float _verticalMovement;
    private Vector3 _grappinDirection;
    private Vector3 _grappinHit;
    [SerializeField] float _speed = 2.0f;

    private Vector3 _movement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalMovement = Input.GetAxis("Horizontal");
        _verticalMovement = Input.GetAxis("Vertical");
        _movement = new Vector3(_horizontalMovement, 0f, _verticalMovement);
        _movement.Normalize();
        _movement *= _speed;
        _movement.y = _rb.linearVelocity.y;
        if (_rb != null)
        {
          _rb.linearVelocity = _movement;  
        }
        else
        {
            Debug.LogError("No RigidBody found !");
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            TryThrowGrappin();
        }

        if (Input.GetKeyUp(KeyCode.G))
        {
            ThrowGrappin();
        }
    }

    private void GrappinUpdateDirection(Vector3 direction)
    {
        if (direction.sqrMagnitude > 0.1f)
        {
            _grappinDirection = direction;

        }
    }

    private void TryThrowGrappin()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, _grappinDirection, out hit,100f))
        {
            Debug.DrawRay(transform.position, _grappinDirection, Color.red);
            _grappinHit = hit.point + hit.normal * 1.5f;
        }
    }

    private void ThrowGrappin()
    {
        transform.position = _grappinHit;
        _grappinDirection = Vector3.zero;
    }
}

