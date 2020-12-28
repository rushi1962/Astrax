using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentShipParts : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] turretPart;
    public GameObject[] bodyPart;
    public int turret, body;
    void Start()
    {
        turret = PlayerPrefManager.GetTurret();
        body = PlayerPrefManager.GetBody();
        for(int i=0;i<turretPart.Length;i++)
        {
            if(i==turret)
            {
                turretPart[i].SetActive(true);
            }
            else
            {
                turretPart[i].SetActive(false);
            }
        }
        for (int i = 0; i < bodyPart.Length; i++)
        {
            if (i == body)
            {
                bodyPart[i].SetActive(true);
            }
            else
            {
                bodyPart[i].SetActive(false);
            }
        }
    }
    public void SetBodyPart(int bodyInt)
    {
        PlayerPrefManager.SetBody(bodyInt);
        GameManager.gm.body = bodyInt;
        for (int i = 0; i < bodyPart.Length; i++)
        {
            if (i == bodyInt)
            {
                bodyPart[i].SetActive(true);
            }
            else
            {
                bodyPart[i].SetActive(false);
            }
        }
    }
    public void SetTurretPart(int turretInt)
    {
        PlayerPrefManager.SetTurret(turretInt);
        GameManager.gm.turret = turretInt;
        for (int i = 0; i < turretPart.Length; i++)
        {
            if (i == turretInt)
            {
                turretPart[i].SetActive(true);
            }
            else
            {
                turretPart[i].SetActive(false);
            }
        }
    }

    
}
