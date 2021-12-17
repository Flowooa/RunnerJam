using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private AudioClip audioSaute = null;
    [SerializeField] Transform respawn;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject cube;

    Rigidbody rb;
    AudioSource audioSource;
    public float Speed = 5f, Force = 300f;
    float AxisX, AxisY;
    bool PlayerJump = false;
    bool StopDblleJump = false;
    public float maxSpeed = 20f;

    void Start()    
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {

        if ((PlayerJump) && StopDblleJump)
        {
            PlayerJump = false;
            rb.AddForce(Vector3.up * Force);
            StopDblleJump = false;
        }
        if (Speed < maxSpeed)
        {
            transform.Translate(Vector3.right * Speed * AxisX * Time.deltaTime);
            transform.Translate(Vector3.forward * Speed * AxisY * Time.deltaTime);

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
