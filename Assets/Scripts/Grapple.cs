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
    }

    void Start()
    {
        startTime = Time.time;

    }

    public void IncreaseStun(float amount)
    {
        stunTime += amount;

    }

    // Update is called once per frame
    void FixedUpdate()
    {

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
            // Debug.Log(withController);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out target))
            {
                Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);
                Vector3 targetHit = target.point;
                targetHit.y = transform.position.y;
                transform.LookAt(targetHit);
            }
        }



        if (Input.GetButton("Grapple"))
        {
            chargeCheck = playerHealth.ChargeCheck(grappleCharge);
            if (chargeCheck)
            {
                if (Physics.Raycast(transform.position, transform.forward, out objectHit, 500, grapple))
                {

                    Debug.DrawRay(transform.position, transform.forward, Color.green);
                    vectorHit = objectHit.point;
                    canGrapple = true;

                    GrappleProcess(vectorHit);


                }

            }

        }
        if (Input.GetAxisRaw("Joystick Grapple") > 0)
        {
            chargeCheck = playerHealth.ChargeCheck(grappleCharge);
            if (chargeCheck)
            {
                if (Physics.Raycast(transform.position, transform.forward, out objectHit, 500, grapple))
                {

                    Debug.DrawRay(transform.position, transform.forward, Color.green);

                    vectorHit = objectHit.point;
                    canGrapple = true;

                    GrappleProcess(vectorHit);


                }
            }
        }
        /*
        if (canGrapple == true)
        {

            GrappleProcess(vectorHit);
        }
        */


    }


    public void GrappleProcess(Vector3 vectorHit)
    {


        journeyLength = Vector3.Distance(this.transform.position, vectorHit);

        fractionOfJourney = speed / journeyLength;
        player.transform.position = Vector3.Lerp(player.transform.position, vectorHit, fractionOfJourney);

        if (player.transform.position == vectorHit)
        {
            canGrapple = false;
        }
    }
    /*

    public void GrappleAction()
    {

       
        //am.Play("GrapplingHook");
        if (Physics.Raycast(transform.position, transform.forward, out objectHit, 200, grapple))
        {

            Debug.Log("can grapple");

            Debug.DrawRay(transform.position, transform.forward, Color.green);
            vectorHit = objectHit.point;
            canGrapple = true;
            GrappleProcess();
            if (source != null)
            {
                source.Play();
            }


        }
        else if (Physics.Raycast(transform.position, transform.forward, out objectHit, 200, enemy))
        {



            //am.Play("GrapplingHook");


            this.GetComponentInParent<BubbleDash>().Invincibility(stunInvincibility);


            Debug.DrawRay(transform.position, transform.forward, Color.green);
            EnemyStun enemyStun = objectHit.transform.GetComponent<EnemyStun>();
            canGrapple = true;
            GrappleProcess();
            if (enemyStun != null)
            {

                enemyStun.Stun(stunTime);

            }


            vectorHit = objectHit.point;
            canGrapple = true;
            if (source != null)
            {
                source.Play();
            }


        }

    }*/


}
