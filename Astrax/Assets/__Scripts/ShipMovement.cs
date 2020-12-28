using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    
    public Rigidbody rb;
    [SerializeField]
    private float _speed=10f;
    [SerializeField]
    private Vector3 _moveBody;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _moveBody = InputManager.input.Horizontal * transform.right+ InputManager.input.Vertical*transform.up;
        if(_moveBody.magnitude>0.1f)
        {
            
            rb.MovePosition(transform.position+_moveBody.normalized * Time.fixedDeltaTime * _speed);
        }
       
    }
}
