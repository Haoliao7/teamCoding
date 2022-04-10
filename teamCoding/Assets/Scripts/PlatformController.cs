using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{

    public float moveAmount = 1.0f;

    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.x<-9.5f) //left boundary
        {
            gameObject.transform.position = new Vector3( -9.5f, gameObject.transform.position.y, gameObject.transform.position.z);
        }

        if (gameObject.transform.position.x > 9.2f) //right boundary
        {
            gameObject.transform.position = new Vector3(9.2f, gameObject.transform.position.y, gameObject.transform.position.z);
        }

        if (gameObject.transform.position.y < -5.23f) //bottom boundary
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, -5.23f, gameObject.transform.position.z);
        }

        // move up
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, moveAmount);
        }
        // move down
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, -moveAmount);
        }
        // move left
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-moveAmount, rb.velocity.y);
        }
        // move right
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(moveAmount, rb.velocity.y);
        }

        //stop moving if release the key
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            rb.velocity = Vector2.zero;
        }



    }
}

