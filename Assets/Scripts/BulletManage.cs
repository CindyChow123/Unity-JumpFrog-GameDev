using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // if collide with a saw, destroy the bullet and the saw
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Saw"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
