using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{

    //grapple will casta  ray from the position that your grapple object faces which is determined by your mouse 
    // it will casta  ray and if the hit target is a grapple hook layer then it will force the player in that direction 
  
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

    //public AudioManager am;
    public GameObject audioManagerObject;

    string[] joystick;

    void Start()
    {
        startTime = Time.time;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetJoystickNames().Length >= 1){
            if (Input.GetJoystickNames()[0] == "Controller (Xbox One For Windows)")
        {
            //Debug.Log("controller perhaps");
            withController = true; 
            joyVec.y = Input.GetAxis("JoystickGunX")  * Time.fixedDeltaTime;


            joyVec.x = 0;
            transform.Rotate(joyVec * 750f);
        }

        }

        else
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out target))
            {
                Debug.DrawRay(ray.origin, ray.direction * 300, Color.yellow);
                Vector3 targetHit = target.point;
                targetHit.y = transform.position.y;
                transform.LookAt(targetHit);
            }

        }

        //this is the raycast for mouse to test if you want to grapple
        if (Input.GetButton("Grapple"))
        {
            audioManagerObject.GetComponent<AudioManager>().Play("GrapplingHook");
            //am.Play("GrapplingHook");
            if (Physics.Raycast(transform.position, transform.forward, out objectHit, 40, grapple))
            {



                Debug.DrawRay(transform.position, transform.forward, Color.green);
                vectorHit = objectHit.point;
                canGrapple = true;


            }
            else if (Physics.Raycast(transform.position, transform.forward, out objectHit, 40, enemy))
            {
                //am.Play("GrapplingHook");
                audioManagerObject.GetComponent<AudioManager>().Play("GrapplingHook");

                this.GetComponentInParent<BubbleDash>().Invincibility(stunInvincibility);


                Debug.DrawRay(transform.position, transform.forward, Color.green);
                EnemyStun enemyStun = objectHit.transform.GetComponent<EnemyStun>();
                if (enemyStun != null)
                {

                    enemyStun.Stun();

                }


                vectorHit = objectHit.point;
                canGrapple = true;


            }

        }
        if (Input.GetAxisRaw("Joystick Grapple") > 0)
        {
            //am.Play("GrapplingHook");
            audioManagerObject.GetComponent<AudioManager>().Play("GrapplingHook");

            if (Physics.Raycast(transform.position, transform.forward, out objectHit, 40, grapple))
            {


                Debug.DrawRay(transform.position, transform.forward, Color.green);

                vectorHit = objectHit.point;
                canGrapple = true;


            }
        }

        if (canGrapple == true)
        {
            
            GrappleProcess(vectorHit);
        }
        

    }


    public void GrappleProcess(Vector3 vectorHit)
    {
        
        //potential issue here with the time delta time not being muiltiplied creating speed inconsistencies 
        journeyLength = Vector3.Distance(this.transform.position, vectorHit);

        fractionOfJourney = speed/ journeyLength;
        player.transform.position = Vector3.Lerp(player.transform.position, vectorHit, fractionOfJourney);

        if (player.transform.position == vectorHit)
        {
            canGrapple = false; 
        }
    }


}
