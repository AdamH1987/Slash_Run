using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
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
            LevelManager.lm.LoadScene("frontend");
        }

        if( Input.GetKey("2"))
        {
            LevelManager.lm.LoadScene("Level 2");
        }

    }
}
