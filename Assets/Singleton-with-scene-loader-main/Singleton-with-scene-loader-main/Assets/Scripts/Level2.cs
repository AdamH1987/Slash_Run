using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKey("q"))
        {
            LevelManager.lm.LoadScene("Frontend");
        }

        if( Input.GetKey("1"))
        {
            LevelManager.lm.LoadScene("1");
        }


        
    }
}
