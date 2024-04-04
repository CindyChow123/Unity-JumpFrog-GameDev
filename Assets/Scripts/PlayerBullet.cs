using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private int ammoCnt = 0;
    public GameObject bulletPrototype;
    
    public void AddAmmo(int ammo)
    {
        ammoCnt += ammo;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if the player presses the key U, the player will shoot a bullet
        if (Input.GetKeyDown(KeyCode.U) && ammoCnt > 0)
        {
            ammoCnt--;
            // Instantiate a bullet object
            GameObject bullet = Instantiate(bulletPrototype, transform.position, Quaternion.identity);
            bullet.SetActive(true);
            // Set the bullet's velocity
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);
        }
    }
}
