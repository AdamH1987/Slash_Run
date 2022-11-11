using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class SlashScript : MonoBehaviour
{

    Player GunFlip;
    HelperScript helper;


    void Start()
    {
        helper = gameObject.AddComponent<HelperScript>();

        GunFlip = gameObject.GetComponent<Player>();

    }


    void Update()
    {
        
        if (GunFlip == true)
        {
            helper.FlipObject(true);
        }
        else if (GunFlip == false)
        {
            helper.FlipObject(false);
        }
        Invoke("KillSlash", 0.2f);
    }

    void KillSlash()
    {
        Destroy(gameObject);
    }
}
