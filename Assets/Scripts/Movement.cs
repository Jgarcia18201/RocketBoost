using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 100;
    [SerializeField] float rotationThrust = 1f;
    [SerializeField] AudioClip mainEngine;
    Rigidbody rbody;
    AudioSource audioSource;

    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rbody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngine);
            }
        }
        else
        {
            audioSource.Stop();
        }
    }


    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.D))
        {
            applyRotation(rotationThrust);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            applyRotation(-rotationThrust);
        }
    }

    void applyRotation(float rotationThisFrame)
    {
        rbody.freezeRotation = true; //freezing rotation for manual rotate
        transform.Rotate(Vector3.back * rotationThisFrame * Time.deltaTime);
        rbody.freezeRotation = false; //unfreezing rotation so physics takes over
    }
}