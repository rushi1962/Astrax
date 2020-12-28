using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteSavedData : MonoBehaviour
{
    // Start is called before the first frame update
    void OnMouseDown()
    {
        PlayerPrefManager.ResetAllData();
    }
    void OnTriggerEnter(Collider newCollider)
    {
        PlayerPrefManager.ResetAllData();
    }
}
