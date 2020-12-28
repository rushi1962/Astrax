using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRotator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Vector3 _lookAtPosition;

    // Update is called once per frame
    void Update()
    {
        _lookAtPosition= Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _lookAtPosition.z = 0f;
        Quaternion _rotation = Quaternion.LookRotation(_lookAtPosition - transform.position,transform.up);
        transform.rotation = _rotation;
    }
}
