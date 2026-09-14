using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    private Vector3 startingLocation;
    private Quaternion startingRotaton;

    private void OnEnable()
    {
        EventBus.Subscribe(EventBusTypes.REPLAY, Replay);
        startingLocation = transform.position;
        startingRotaton = transform.rotation;
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe(EventBusTypes.REPLAY, Replay);
    }

    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime); //Add a variable on the z axis
        if (rb.position.y < -1 || rb.position.y > 2)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    public void Move(string input)
    {
        if (input == "d")
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (input == "a")
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
    }

    void Replay()
    {
        transform.position = startingLocation;
        transform.rotation = startingRotaton;
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
