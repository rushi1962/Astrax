using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Shooter : MonoBehaviour
{
    public float Force = 20f;
    public GameObject bullet;
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    public void Shoot()
    {
        GameObject newBullet= Instantiate(bullet, transform.position, transform.rotation) as GameObject;
        if (!newBullet.GetComponent<Rigidbody>())
        {
            newBullet.AddComponent<Rigidbody>();
        }
        // Apply force to the newProjectile's Rigidbody component if it has one
        newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * Force, ForceMode.VelocityChange);
        AchievementsManager.achievements.shotsFired++;
        
    }
}
