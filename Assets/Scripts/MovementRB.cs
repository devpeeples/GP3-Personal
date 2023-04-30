using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRB : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    
    public float rotationSpeed;


    private float xMove;
    private float zMove;
    private Vector3 movementDirection;
    public float setSpeed;
    public float setRotationSpeed;
    private float horizontal; 
    private float vertical;
    private Vector3 forward, right, heading; 
    [Header("References")]
    public BubbleDash bD;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Animator anim;
    //public AudioManager am; 

    // Start is called before the first frame update
    void Start()
    {
        setSpeed = speed;
        setRotationSpeed = rotationSpeed; 
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        
        //camera stuff
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;

    }

    public void SetGrappleAnimTrue()
    {
        anim.SetBool("isGrappling", true);
    }
    public void SetGrappleAnimFalse()
    {
        anim.SetBool("isGrappling", false);
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        Vector3 rightMovement = right * speed * Time.deltaTime * horizontal;
        Vector3 upMovement = forward * speed * Time.deltaTime * vertical;

        Vector3 inputDirection = Vector3.Normalize(rightMovement + upMovement);

        if (inputDirection != Vector3.zero)
        {
            anim.SetBool("isMoving", true);

            heading = Vector3.Lerp(heading, inputDirection, Time.deltaTime * rotationSpeed);

            Quaternion toRotation = Quaternion.LookRotation(heading, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed);
        }
        else
        {
            anim.SetBool("isMoving", false);
            heading = Vector3.zero;
        }
    }

    void FixedUpdate()
    {
        if (!bD.isDashing)
        {
            rb.velocity = heading * speed;
        }
    }
    public void resetSpeed()
    {
        speed = setSpeed;
    }
}
