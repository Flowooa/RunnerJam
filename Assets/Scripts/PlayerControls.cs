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
    [SerializeField] private GameObject PauseMenuUI;

    Rigidbody rb;
    AudioSource audioSource;
    public float Speed = 5f, Force = 300f;
    float AxisX, AxisY;
    private static bool gamePaused = false;
    bool PlayerJump = false;
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

    public void OnPause()
    {
        if (gamePaused)
        {
            Resume();
        }
        else
        {
            Paused();
        }
    }

    public void OnSUICIDE()
    {
        cube = (GameObject)Instantiate(cube, Player.transform.position, Quaternion.identity);
        Player.transform.position = respawn.position;
    }

    private void Paused()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        gamePaused = true;
    }

    private void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        gamePaused = false;
    }
}
