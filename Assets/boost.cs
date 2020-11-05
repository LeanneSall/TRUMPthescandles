using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using UnityEngine;

public class boost : MonoBehaviour
{
    [SerializeField] float rcsRotate = 100f;
    [SerializeField] float rcsThrust = 1000f;
    Rigidbody rigidbody;
    AudioSource china;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        china = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Thrust();
        Rotate();
    }

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                print("OK");
                break;
            default:
                print("dead"); 
                break;
        }
    }

    void Rotate()
    {
        rigidbody.freezeRotation = true;
       
        float rotationThisFrame = rcsRotate * Time.deltaTime;
        

        if (Input.GetKey(KeyCode.A))
        {
            
            transform.Rotate(-Vector3.forward * rotationThisFrame);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }

        rigidbody.freezeRotation = false;

    }

    private void Thrust()
    {
        
        float forwardThisFrame = rcsThrust * Time.deltaTime;
        if (Input.GetKey(KeyCode.Space))
        {
            rigidbody.AddRelativeForce(Vector3.up * forwardThisFrame);
            if (!china.isPlaying)
            {
                china.Play();
            }

        }
        else
        {
            china.Stop();
        }
    }
}
