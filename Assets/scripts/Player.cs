using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public int speed;
    private Animator anim;
    float inputHorizontal;
    float inputVertical;
    public bool touchingPlatform;
    float playerJumpVelocity = 7;
    HelperScript helper;
    bool isJumping;
    public Text scoreText;
    public static int score, oldScore;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 2;
        anim = GetComponent<Animator>();
        helper = gameObject.AddComponent<HelperScript>();
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        anim.SetBool("Walk", false);
        anim.SetBool("Duck", false);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
            anim.SetBool("Walk", true);
            helper.FlipObject(false);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector2(transform.position.x - (speed * Time.deltaTime), transform.position.y);
            anim.SetBool("Walk", true);
            helper.FlipObject(true);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool("Duck", true);
        }

        //check for initiate jump
        if (Input.GetKeyDown(KeyCode.Space) && touchingPlatform)
        {
            rb.velocity = new Vector2(rb.velocity.x, playerJumpVelocity);
            anim.SetBool("Jump", true);
            isJumping = true;
        }

        // check for landing
        if( (isJumping==true) && touchingPlatform )
        {
            print("yv=" + rb.velocity.y);
            if (rb.velocity.y <= 0)
            {
                isJumping = false;
                anim.SetBool("Jump", false);
            }
        }


    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            touchingPlatform = true;
            
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            touchingPlatform = false;
        }
    }


    void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
        scoreText.text += "\n";

        oldScore = score;
    }
}
