using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UIElements;
using System;

public class HelperScript : MonoBehaviour
{
    LayerMask groundLayerMask;


    public void FlipObject(bool flip)
    {
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();

        if (flip == true)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }

    void Start()
    {
        groundLayerMask = LayerMask.GetMask("Platform");
    }


    public void DoRayCollisionCheck()
    {
        float rayLength = 1.0f;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, rayLength, groundLayerMask);

        Color hitColor = Color.white;


        if (hit.collider.tag == "Platform")
        {
            print("Player has collided with Ground");
            hitColor = Color.green;
        }


        Debug.DrawRay(transform.position, -Vector2.up * rayLength, hitColor);
    }


}