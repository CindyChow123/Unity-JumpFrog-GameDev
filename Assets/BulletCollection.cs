using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollection : MonoBehaviour
{
    public BulletController bulletController;
    // instantiate the bullet object
    public GameObject bulletObject;
    public int bulletCount = 0;
    // player
    public PlayerMovement player;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            if (bulletCount > 0)
            {
                ShootBullet();
            }
        }
        // q: how to get the position of a bullet and the player
        
        if (Input.GetKeyDown(KeyCode.I))
        {
            CollectBullet();
        }
    }

    void CollectBullet()
    {
        // instantiate the bullet object
        GameObject bullet = Instantiate(bulletObject, transform.position, Quaternion.identity);
        // using the functions of BullectController to destroy the bullet
        bulletController.collected = true;
        bulletController.shoot = false;
        // bulletController.CollectBullet();
        bulletCount++;
    }

    void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletObject, transform.position, Quaternion.identity);
        bulletController.shoot = true;
        bulletController.collected = false;
        bulletCount--;
    }
    
}
