using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSound : MonoBehaviour
{


    public float topSpeed = 100; // km per hour
    private float currentSpeed = 0;
    private float pitch = 0;

    void Update()
    {
        currentSpeed = transform.GetComponent<Rigidbody>
        ().velocity.magnitude * 3.6f;
        pitch = currentSpeed / topSpeed;

        transform.GetComponent<AudioSource>().pitch =
        pitch;
    }

}