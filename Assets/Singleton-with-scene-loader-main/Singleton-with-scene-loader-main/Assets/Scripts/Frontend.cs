using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frontend : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if( Input.GetKey("1"))
        {
            LevelManager.lm.LoadScene("Level 1");
        }

        if( Input.GetKey("2"))
        {
            LevelManager.lm.LoadScene("Level 2");
        }

        
    }
}
