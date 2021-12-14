using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    Rigidbody rb;
    public float Speed = 5f, Force = 300f;
    bool PlayerJump = false;
    float AxisX, AxisY;
    bool StopDblleJump = false;

    void Start()    
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        transform.Translate(Vector3.right * Speed * AxisX * Time.deltaTime);
        transform.Translate(Vector3.forward * Speed * AxisY * Time.deltaTime);

    }
    private void FixedUpdate()
    {
        if ((PlayerJump) && StopDblleJump)
        {
            PlayerJump = false;
            rb.AddForce(Vector3.up * Force);
            StopDblleJump = false;
        }
    }

    public void OnHorizontal(InputValue val)
    {
        AxisX = val.Get<float>();     
    }
    public void OnVertical(InputValue val) 
    {
        AxisY = val.Get<float>();   
    }

    public void OnJump()
    {
        PlayerJump = true; 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject)
        {
            StopDblleJump = true;
        }
    }
}
