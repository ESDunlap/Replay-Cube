using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reverseAttack : MonoBehaviour
{
    public Transform player;
    public float distanceActivation;
    public float reverseSpeed = 5000f;
    public Rigidbody rb;
    private bool activated = false;
    private Vector3 startingLocation;
    private Quaternion startingRotaton;

    private void OnEnable()
    {
        EventBus.Subscribe(EventBusTypes.REPLAY, Replay);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe(EventBusTypes.REPLAY, Replay);
    }

    void Start()
    {
        startingLocation = transform.position;
        startingRotaton = transform.rotation;
    }

    void Update()
    {
        if (player.position.z > distanceActivation)
        {
            activated = true;
            GetComponent<BoxCollider>().enabled = true;
        }

        if(activated && !FindObjectOfType<GameManager>().gameHasEnded)
        {
            rb.AddForce(0, 0, reverseSpeed * Time.deltaTime);
        }
    }

    void Replay()
    {
        transform.position = startingLocation;
        transform.rotation = startingRotaton;
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        activated = false;
        GetComponent<BoxCollider>().enabled = false;
    }
}
