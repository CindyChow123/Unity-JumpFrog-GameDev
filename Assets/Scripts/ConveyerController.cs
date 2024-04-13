using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyerController : MonoBehaviour
{
    public GameObject player;
    public float speed = 0.1f;
    private bool isPlayerOnConveyer = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerOnConveyer)
        {
            MovePlayer();
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the game object the conveyer is colliding with is the player
        if (collision.gameObject == player)
        {
            isPlayerOnConveyer = true;
            // The conveyer is colliding with the player
            Debug.Log("The conveyer is colliding with the player");
        }
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        // Check if the game object the conveyer is no longer colliding with is the player
        if (collision.gameObject == player)
        {
            isPlayerOnConveyer = false;
            // The conveyer is no longer colliding with the player
            Debug.Log("The conveyer is no longer colliding with the player");
        }
    }
    
    // function to move the player on the platform
    private void MovePlayer()
    {
        // Move the player
        player.transform.position = new Vector3(player.transform.position.x + speed, player.transform.position.y, player.transform.position.z);
    }
}
