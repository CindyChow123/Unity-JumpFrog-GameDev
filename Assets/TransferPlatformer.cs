using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// q: convert this interface to a class

public class TransferPlatformer : MonoBehaviour
{
    private Vector2D startPosition;
    private void Start()
    {
        startPosition = transform.position;
    }
    private float moveSpeed = 5.0f;
    private Vector2 direction = Vector2.right;
    private float moveDistance = 10.0f;
    
    private void Update()
    {
        // q: move this platformer from left to right automatically
        transform.position += direction * moveSpeed * Time.deltaTime;
        ChangeDirection();
    }

    private void ChangeDirection()
    {
        // q: when reach the distance, change direction
        if (Mathf.Abs(transform.position.x - startPosition.x) >= moveDistance)
        {
            direction = -direction;
        }
        
    }
}
