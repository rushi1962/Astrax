using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizationButton : MonoBehaviour
{
    // Start is called before the first frame update
    public CurrentShipParts shipParts;
    public int shipPartNumber;
    void Start()
    {
        shipParts = GameObject.FindGameObjectWithTag("Player").GetComponent<CurrentShipParts>();
    }

    // Update is called once per frame
    public void ClikedForBody()
    {
        shipParts.SetBodyPart(shipPartNumber);
    }
    public void ClikedForTurret()
    {
        shipParts.SetTurretPart(shipPartNumber);
    }
}
