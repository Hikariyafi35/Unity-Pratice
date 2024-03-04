using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{   
    //PARAMETER for tuning,typically set in editor
    // Cache references for readability or speed
    //State private instance (member) variabel
    [SerializeField] float ThrustSpeed = 100f;
    [SerializeField] float RotateThrust = 100f;
    [SerializeField] AudioClip MainEngine;

    [SerializeField] ParticleSystem MainThrusterParticles;
    [SerializeField] ParticleSystem LeftThrusterParticles;
    [SerializeField] ParticleSystem RightThrusterParticles;

    Rigidbody rb;
    AudioSource audiosource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audiosource = GetComponent<AudioSource>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }
    void ProcessThrust(){
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }

    }
    void ProcessRotation(){
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            StopRotating();
        }
    }

    void StopThrusting()
    {
        audiosource.Stop();
        MainThrusterParticles.Stop();
    }

    void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * ThrustSpeed * Time.deltaTime);
        if (!audiosource.isPlaying)
        {
            audiosource.PlayOneShot(MainEngine);
        }
        if (!MainThrusterParticles.isPlaying)
        {
            MainThrusterParticles.Play();
        }
    }

    void StopRotating()
    {
        RightThrusterParticles.Stop();
        LeftThrusterParticles.Stop();
    }

    void RotateRight()
    {
        ApplyRotation(-RotateThrust);
        if (!LeftThrusterParticles.isPlaying)
        {
            LeftThrusterParticles.Play();
        }
    }

    void RotateLeft()
    {
        ApplyRotation(RotateThrust);
        if (!RightThrusterParticles.isPlaying)
        {
            RightThrusterParticles.Play();
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; //freezing rotation agar bisa manual rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
         rb.freezeRotation = false; //unfreez agar physic rotation dapat bekerja
    }
}
