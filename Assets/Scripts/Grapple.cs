using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{

    //grapple will casta  ray from the position that your grapple object faces which is determined by your mouse 
    // it will casta  ray and if the hit target is a grapple hook layer then it will force the player in that direction 
    public int grappleCharge;
    public LayerMask grapple;
    public LayerMask enemy;
    private Vector3 joyVec;
    RaycastHit objectHit;
    RaycastHit target;
    public float speed;
    public float stunInvincibility;
    public int maxDistance;
    public float rotationSpeed;


    private float startTime;
    private float journeyLength;
    private float distCovered;
    private float fractionOfJourney;

    public Transform player;
    private bool canGrapple = false;
    private Vector3 vectorHit;
    private Vector3 mouseWorldPosition;

    private bool withController = false;

    private PlayerHealth playerHealth;
    private bool chargeCheck;
    private bool grappled;
    private LineRenderer lineRenderer;

    //public AudioManager am;
    public AudioSource source;

    //stun time is what to save
    public float stunTime;

    string[] joystick;


    void OnEnable()
    {
        //get component for the player health
        canGrapple = false;
        playerHealth = GetComponentInParent<PlayerHealth>();
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Start()
    {
        startTime = Time.time;
        if (Input.GetJoystickNames().Length >= 1)
        {
            if (Input.GetJoystickNames()[0] == "Controller (Xbox One For Windows)")
            {
                withController = true;
            }
        }

        else
        {
            withController = false;
        }

    }

    public void IncreaseStun(float amount)
    {
        stunTime += amount;
    }

    // this is going to make sure that both vcontroller and non controller grapple points where it should 
    void FixedUpdate()
    {
        /*
        if (Input.GetJoystickNames().Length >= 1)
        {
            if (Input.GetJoystickNames()[0] == "Controller (Xbox One For Windows)")
            {
                withController = true;
            }
        }

        else
        {
            withController = false;
        }
        */



        if (withController)
        {
            //Debug.Log(withController);
            joyVec.x = Input.GetAxis("JoystickGunX");
            joyVec.y = -(Input.GetAxis("JoystickGunY"));

            if (joyVec.sqrMagnitude > 0.1f)
            {
                transform.rotation = Quaternion.LookRotation(new Vector3(joyVec.x, 0, joyVec.y), Vector3.up);
            }
        }
        else if (!withController)
        {
            Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
            Vector3 mousePos = Input.mousePosition - screenCenter;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            int floorLayerMask = 1 << LayerMask.NameToLayer("Floor"); // Only hit objects on the Floor layer
            RaycastHit target;
            if (Physics.Raycast(ray, out target, Mathf.Infinity, floorLayerMask))
            {
                Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);
                Vector3 targetHit = target.point;
                targetHit.y = transform.position.y;
                Vector3 direction = (targetHit - transform.position);
                Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
                transform.rotation = targetRotation;
            }
        }







        if (Input.GetButton("Grapple") || Input.GetAxisRaw("Joystick Grapple") > 0)
        {
            //if (!grappled)
            //{

                chargeCheck = playerHealth.ChargeCheck(grappleCharge);
               // playerHealth.UseCharge(grappleCharge);
                if (chargeCheck)
                {

                    if (Physics.Raycast(transform.position, transform.forward, out objectHit, maxDistance, enemy))
                    {
                        Debug.Log("Enemy hit");
                        this.GetComponentInParent<BubbleDash>().Invincibility(stunInvincibility);

                        Debug.DrawRay(transform.position, transform.forward, Color.green);
                        EnemyStun enemyStun = objectHit.transform.GetComponent<EnemyStun>();
                        vectorHit = objectHit.point;
                        canGrapple = true;
                        GrappleProcess(vectorHit);
                        if (enemyStun != null)
                        {
                            enemyStun.Stun(stunTime);
                        }
                    }
                    else if (Physics.Raycast(transform.position, transform.forward, out objectHit, maxDistance, grapple))
                    {
                        Debug.Log("Grapple hit");
                        Debug.DrawRay(transform.position, transform.forward, Color.green);

                        vectorHit = objectHit.point;
                        canGrapple = true;

                        GrappleProcess(vectorHit);
                    }

                }
                //grappled = true; 
           // }
            

        }
       
        /*
        if (Input.GetAxisRaw("Joystick Grapple") > 0)
        {
            chargeCheck = playerHealth.ChargeCheck(grappleCharge);
            if (chargeCheck)
            {
                if (Physics.Raycast(transform.position, transform.forward, out objectHit, 500, enemy))
                {

                    Debug.DrawRay(transform.position, transform.forward, Color.green);

                    vectorHit = objectHit.point;
                    canGrapple = true;

                    GrappleProcess(vectorHit);


                }
                else if (Physics.Raycast(transform.position, transform.forward, out objectHit, 200, grapple))
                {
                    this.GetComponentInParent<BubbleDash>().Invincibility(stunInvincibility);

                    Debug.DrawRay(transform.position, transform.forward, Color.green);
                    EnemyStun enemyStun = objectHit.transform.GetComponent<EnemyStun>();
                    vectorHit = objectHit.point;
                    canGrapple = true;
                    GrappleProcess(vectorHit);
                    if (enemyStun != null)
                    {

                        enemyStun.Stun(stunTime);

                    }

                }
            }
        }
        */

    }


    public void GrappleProcess(Vector3 vectorHit)
    {
        journeyLength = Vector3.Distance(this.transform.position, vectorHit);
        fractionOfJourney = speed / journeyLength;

        player.transform.position = Vector3.Lerp(player.transform.position, vectorHit, fractionOfJourney);

        // Get the direction that the player needs to face
        Vector3 direction = (vectorHit - player.transform.position).normalized;

        // Create a rotation that looks in the direction
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        // Smoothly rotate the player towards the target rotation
        player.transform.rotation = Quaternion.Lerp(player.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        lineRenderer.SetPosition(0, player.transform.position);
        lineRenderer.SetPosition(1, vectorHit);
        float distanceToGrapplePoint = Vector3.Distance(player.transform.position, vectorHit);

        if (distanceToGrapplePoint > 0.2f)
        {
            
            canGrapple = false;
            
        }
    }
}


