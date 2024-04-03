using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bulletObject;
    // define the initial position of the bullet that is defined randomly in the map
    public Vector2 bulletPosition = new Vector2(0, 0);
    public bool collected = false;
    public bool shoot = false;
    public float bulletSpeed = 5f;
    
    void Start()
    {
        // generate a bullet
        GameObject bullet = Instantiate(bulletObject, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        // check whether be collected
        if (collected)
        {
            CollectBullet();
        }

        if (shoot)
        {
            BulletMovement();
        }
    }
    
    public void CollectBullet()
    {
        // destroy the bullet
        Destroy(gameObject);
        collected = true;
    }
    
    void BulletMovement()
    {
        // move the bullet along x axis
        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
    }
}
