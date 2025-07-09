using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove2 : MonoBehaviour
{
    public Rigidbody rb;

    public float accelForward = 6f;
    public float accelBackward = 3f;
    public float maxSpeed = 25f;
    public float turnSpeed = 60f;
    public float gravityForce = 10f;
    public float dragOnGround = 3f;

    private float speedInput;
    private float turnInput;

    private bool onGround;

    public LayerMask groundLayer;
    public int layer = 7;
    public float groundDistance = 1f;
    public Transform groundRayPoint;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        speedInput = 0f;

        if(Input.GetAxis("Vertical") > 0)
        {
            speedInput = Input.GetAxis("Vertical") * accelForward * 100f;
        }
        else if(Input.GetAxis("Vertical") < 0)
        {
            speedInput = Input.GetAxis("Vertical") * accelBackward * 100f;
        }

        turnInput = Input.GetAxis("Horizontal");

        if(onGround)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnSpeed * Time.deltaTime * Input.GetAxis("Vertical"), 0f));
        }

        transform.position = rb.transform.position;
    }

    void FixedUpdate()
    {
        onGround = false;
        RaycastHit hit;

        if(Physics.Raycast(groundRayPoint.position, -transform.up, out hit, groundDistance, groundLayer))
        {
            onGround = true;

            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        }

        if(onGround)
        {
            rb.drag = dragOnGround;

            if(Mathf.Abs(speedInput) > 0)
            {
                rb.AddForce(transform.forward * speedInput);
            }
        }
        else
        {
            rb.drag = 0.1f;

            rb.AddForce(Vector3.down * gravityForce * 15f);
        }
    }
}
