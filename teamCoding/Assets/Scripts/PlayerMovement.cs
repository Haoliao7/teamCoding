using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private CircleCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField]
    private LayerMask jumpableGround;

    private float dirX = 0f;

    
    public float moveSpeed = 7f;

    public float jumpForce = 14f;

    private enum MovementState { idle, running, jump, fall } //finite value set

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CircleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        dirX = 1; //left: -1, right: +1
    }

    // Update is called once per frame
    private void Update()
    {
        //Debug.Log("Hello, world!");

        
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);




        if ( IsGrounded()) //GBD vs GKD, uses input system
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); //call rigidbody + add speed
        }

        UpdateAnimationState(); //call method
    }

    

    private void UpdateAnimationState() //no results returned, exclusive execution
    {
        MovementState state; //local variable, values assigned below

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false; //flip sprite, match to right movement

        }
        else if (dirX < 0)
        {
            state = MovementState.running;
            sprite.flipX = true; //flip sprite, match to left movement
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f) //player is in air, execute jumping animation
        {
            state = MovementState.jump;
        }
        else if (rb.velocity.y < -1f) //execute falling animation
        {
            state = MovementState.fall;
        }

        anim.SetInteger("state", (int)state); //turn enum into corresponding integer rep
    }

    private bool IsGrounded() //check if player is grounded
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround); //create box around player, offset downwards, check for overlap with jumpableGround
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            dirX *= -1; //switch its direction
        }
    }

}