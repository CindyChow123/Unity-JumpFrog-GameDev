using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 2f;
    public Vector2 direction = Vector2.right;

    public GameObject trap;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
        // Get the current position
        Vector3 currentPosition = transform.position;

// Set the new Z position
        float newZPosition = 5f;

// Set the position to the new position
        transform.position = new Vector3(currentPosition.x, currentPosition.y, trap.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the bullet has collided with a game object tagged "Enemy"
        if (collision.gameObject.CompareTag("Trap"))
        {
            Debug.Log("Bullet has collided with an trap!");
            // Destroy the enemy game object
            Destroy(collision.gameObject);

            // Destroy the bullet
            Destroy(gameObject);
        }
    }
}
