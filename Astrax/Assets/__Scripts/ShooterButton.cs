using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterButton : MonoBehaviour
{
    public GameObject shooter;
    

    // Update is called once per frame
    public void OnClickShoot()
    {
        shooter = GameObject.FindGameObjectWithTag("Shooter");
        if(shooter)
        {
            if (shooter.GetComponent<Shooter>())
            {
                shooter.GetComponent<Shooter>().Shoot();
            }
        }
        
    }
}
