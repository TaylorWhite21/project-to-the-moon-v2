using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody playerBody;
    [SerializeField] float thrustForceUp = 50f;
    [SerializeField] float rotationThrust = 50f;


    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust() 
    {
        

        if (Input.GetKey(KeyCode.Space))
        {
            playerBody.AddRelativeForce(Vector3.up * thrustForceUp * Time.deltaTime);
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            AddRotationForce(rotationThrust);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            AddRotationForce(-rotationThrust);
        }
    }

    void AddRotationForce(float rotateThisFrame)
    {
        transform.Rotate(Vector3.forward * rotateThisFrame * Time.deltaTime);
    }
}
