using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    [SerializeField] private LayerMask jumpableGround;
    private float dirX = 0f;
    [SerializeField]private float moveSpeed = 7f;
    [SerializeField]private float jumpForce = 14f;
    
    public int bulletCount = 0;
    [SerializeField] private GameObject bulletPrefab; // The bullet prefab
    private bool isFacingRight = true;
    private Vector2 bulletOffset = new Vector2(0.3f, 0f);

    private enum MovementState { idle, running, jumping, falling }

    [SerializeField]private AudioSource jumpSoundEffect;  
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        
        if (dirX > 0f)
        {
            isFacingRight = true;
        }
        else if (dirX < 0f)
        {
            isFacingRight = false;
        }

        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (Input.GetKeyDown(KeyCode.U) && bulletCount > 0)
        {
            FireBullet();
            bulletCount--;
        }

        UpdateAnimationState();
    }

    private void FireBullet()
    {
        Vector2 spawnPosition = (Vector2)transform.position + (isFacingRight ? bulletOffset : -bulletOffset);
        // Instantiate a bullet at the player's position
        GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);

        // Get the BulletController component of the bullet
        BulletController bulletController = bullet.GetComponent<BulletController>();

        // Set the direction of the bullet based on the direction the player is facing
        bulletController.direction = isFacingRight ? Vector2.right : Vector2.left;
    }
    private void UpdateAnimationState()
    {
        MovementState state;
         if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }
        if (rb.velocity.y > 0.1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }
        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
       
    }
    
}
