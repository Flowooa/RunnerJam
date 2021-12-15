using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TESTEUR : MonoBehaviour
{
    
    [SerializeField] private AudioClip audioSaute = null;
    [SerializeField] Transform respawn;


    private Controls controls;
    private Rigidbody Rigidbody;
    private AudioSource audioSource;

    private void OnEnable()
    {
        controls = new Controls();
        controls.Enable();
        controls.Main.test.performed += testPerformed;
    }

    private void testPerformed(InputAction.CallbackContext obj)
    {
        audioSource.PlayOneShot(audioSaute);

    }

    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
