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

    


    [Header("References")]
    public BubbleDash bD;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Animator anim;
    public AudioManager am; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
 
        
    }

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");
        movementDirection = new Vector3(xMove, 0, zMove);

        //rotate character to movement direction- it is a transform not a rb movement
        if (movementDirection != Vector3.zero)
        {
            //animate run state 
            anim.SetBool("isMoving", true);
            //sound of walking
            
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed);
        }
        else
        {
            am.Play("SandStep");
            //am.Stop("SandStep");
            anim.SetBool("isMoving", false);
            //animate idle state
            //no sound of walking
        }
        
    }

    void FixedUpdate()
    {
        // this code will apply force to the rb based on the movement direction 


        //if script is not dashing, dash 
        if (!bD.isDashing)
        {
            rb.velocity = movementDirection * speed;
        }
            

    }
}
