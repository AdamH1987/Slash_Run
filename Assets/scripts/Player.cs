using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
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
    float playerJumpVelocity = 6.4f;
    HelperScript helper;
    bool isJumping;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    public GameObject Slash;
    public int health;
    public static int score, oldScore, oldhealth;
    public Transform restartPoint;
    GameObject clone;
    public bool GunFlip = false;
    



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 3;
        anim = GetComponent<Animator>();
        helper = gameObject.AddComponent<HelperScript>();
        isJumping = false;

        health = 4;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {

        UpdateScore();
        ShootWeapon();

        anim.SetBool("Walk", false);
        anim.SetBool("Duck", false);
        anim.SetBool("Death", false);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
            anim.SetBool("Walk", true);
            helper.FlipObject(false);
            GunFlip = false;        
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector2(transform.position.x - (speed * Time.deltaTime), transform.position.y);
            anim.SetBool("Walk", true);
            helper.FlipObject(true);
            GunFlip = true;
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
        if ((isJumping == true) && touchingPlatform)
        {
            print("yv=" + rb.velocity.y);
            if (rb.velocity.y <= 0)
            {
                isJumping = false;
                anim.SetBool("Jump", false);
            }
        }

        void ShootWeapon()
        {
            int moveDirection = 1;
            if (Input.GetKeyDown("z"))
            {

                clone = Instantiate(Slash, transform.position, transform.rotation);

                Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();

                rb.velocity = new Vector3(15 * moveDirection, 0, 0);

                rb.transform.position = new Vector3(transform.position.x, transform.position.y + 0, transform.position.z + 1);

              
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

        if (score == 200f)
        {
           
            Invoke("EzWin", 0.004f);
        }

        healthText.text = "LIVES: " + health.ToString();

        oldhealth = health;
        oldScore = score;
    }



    public bool Alive => health > 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health -= 1;
            transform.position = restartPoint.position;
        }
        if (!Alive)
        {
            Invoke("Gameover", 0.1f);
        }
    }



    void Gameover()
    {
        SceneManager.LoadScene("GameOver");
    }

    void EzWin()
    {
        SceneManager.LoadScene("Winner");
    }


}
     





