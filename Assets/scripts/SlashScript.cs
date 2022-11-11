using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("KillSlash", 0.2f);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void KillSlash()
    {
        Destroy(gameObject);
    }
}
