using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class StartTextScript : MonoBehaviour
{
    void OnMouseDown()
    {
        GameManager.gm.LoadNextScene();
    }
    
    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag=="Bullet")
        {
            GameManager.gm.LoadNextScene();
        }
        
    }
}
