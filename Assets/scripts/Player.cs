using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public int speed;
    private Animator anim;
    float inputHorizontal;
    float inputVertical;
    HelperScript helper;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 2;
        anim = GetComponent<Animator>();
        helper = gameObject.AddComponent<HelperScript>();
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

    }
}
