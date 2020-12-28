using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    public float YBound = 10f;
    public float XBound = 17.7f;
    bool check;
    void Update()
    {
        Quaternion _rotation = transform.rotation;
        if (transform.position.x>XBound)
        {

            transform.position = Vector3.right*17.6f*-1+ Vector3.up*transform.position.y;
            transform.rotation = _rotation;
            if(gameObject.tag=="Bullet")
            {
                if (!gameObject.GetComponent<ScreenWrappedCheck>().screenWrapped)
                {
                    gameObject.GetComponent<ScreenWrappedCheck>().screenWrapped = true;
                    
                }
            }
        }
        if(transform.position.x < -XBound)
        {
            transform.position = Vector3.right * 17.6f + Vector3.up * transform.position.y;
            transform.rotation = _rotation;
            if (gameObject.tag == "Bullet")
            {
                if (!gameObject.GetComponent<ScreenWrappedCheck>().screenWrapped)
                {
                    gameObject.GetComponent<ScreenWrappedCheck>().screenWrapped = true;
                   
                }
            }
        }
        if (transform.position.y > YBound )
        {
            transform.position = Vector3.right * transform.position.x + Vector3.up * 9.9f*-1;
            transform.rotation = _rotation;
            if (gameObject.tag == "Bullet")
            {
                if (!gameObject.GetComponent<ScreenWrappedCheck>().screenWrapped)
                {
                    gameObject.GetComponent<ScreenWrappedCheck>().screenWrapped = true;
                   
                }
            }
        }
        if(transform.position.y < -YBound)
        {
            transform.position = Vector3.right * transform.position.x + Vector3.up * 9.9f;
            transform.rotation = _rotation;
            if (gameObject.tag == "Bullet")
            {
                if (!gameObject.GetComponent<ScreenWrappedCheck>().screenWrapped)
                {
                    gameObject.GetComponent<ScreenWrappedCheck>().screenWrapped = true;
                    
                }
            }
        }
        
        
    }
}
