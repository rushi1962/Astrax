using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class InputManager : MonoBehaviour
{
    public static InputManager input;
    public float Horizontal, Vertical;
    public Vector3 MousePosition;
    
    void Awake()
    {
        input = gameObject.GetComponent<InputManager>();
    }
    void Update()
    {
        Horizontal = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        Vertical = CrossPlatformInputManager.GetAxisRaw("Vertical");
        MousePosition = CrossPlatformInputManager.mousePosition;    
        
        
    }
}
