using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager lm;
    
    

    int score;
    // Start is called before the first frame update
    void Start()
    {

        score = 0;
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadScene( string scene )
    {
        print("loading scene " + scene);
        SceneManager.LoadScene(scene);
    }



    void Awake()
    {
        // if instance is null, store a reference to this instance
        if (lm == null)
        {
            // a reference does not exist, so store it
            lm = this;
            DontDestroyOnLoad(gameObject);
            print("dont destroy");
        }
        else
        {      
            // Another instance of this gameobject has been made so destroy it
            // as we already have one
            print("do destroy");
            Destroy(gameObject);
        }
    }

}
