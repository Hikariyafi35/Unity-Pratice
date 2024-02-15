using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{   
    [SerializeField] float ThrustSpeed = 100f;
    [SerializeField] float RotateThrust = 100f;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }
    void ProcessThrust(){
        if (Input.GetKey(KeyCode.Space)){
            rb.AddRelativeForce(Vector3.up *ThrustSpeed * Time.deltaTime);
        }
        
    }
    void ProcessRotation(){
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(RotateThrust);
        }
        else if (Input.GetKey(KeyCode.D)){
            ApplyRotation(-RotateThrust);
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; //freezing rotation agar bisa manual rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
         rb.freezeRotation = false; //unfreez agar physic rotation dapat bekerja
    }
}
