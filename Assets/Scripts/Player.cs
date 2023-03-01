using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float paddingLeft;
    [SerializeField] private float paddingRight;
    [SerializeField] private float paddingTop;
    [SerializeField] private float paddingBottom;
    private Shooter shooter;
    private Vector2 rawInput;
    private Vector2 minBounds;
    private Vector2 maxBounds;

    private void Start() 
    {
        shooter = GetComponent<Shooter>();
        InitBounds();
    }
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 delta = rawInput * Time.deltaTime * moveSpeed;
        Vector2 newPosition = new Vector2();
        newPosition.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPosition.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);
        transform.position = newPosition;
    }

    private void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }

    private void InitBounds()
    {
        Camera camera = Camera.main;
        minBounds = camera.ViewportToWorldPoint(new Vector2(0,0));
        maxBounds = camera.ViewportToWorldPoint(new Vector2(1,1));
    }

    private void OnFire(InputValue value)
    {
        if (shooter != null)
        {
            shooter.isFiring = value.isPressed;
        }

    }
}

