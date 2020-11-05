using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using UnityEngine;

public class boost : MonoBehaviour
{

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
        ProcessInput();
    }

    void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {            
            rigidbody.AddRelativeForce(Vector3.up);
            if (!china.isPlaying)
            {
                china.Play();
            }

        } else
        {
            china.Stop();
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward);
        }



    }

}
