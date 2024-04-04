using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorManage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // give the object that stands on the conveyor belt a velocity
    // q: i add a rigidbody2d to the platform, but the player will still fall from the platform, why
// a: the player has a rigidbody2d, but the player has a script that controls the movement, so the player will not be affected by the conveyor belt
    
    
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(2, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
