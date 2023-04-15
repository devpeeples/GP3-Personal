using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting2 : MonoBehaviour
{

    public GameObject superShot;
    public GameObject normalShot; 
    public float shotSpeed;
    public float chargeTime; 




    private GameObject shotInstance; 
    private GameObject superShotInstance;
    //[SerializedField]
    private float chargeTimer = 0 ;
    
    //private bool OneShot;
    //private Vector3 startingScale; 




    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetButtonDown("Shoot"))
        {
            MakeShot();
            StartCoroutine(Coroutine());
        }

        if (Input.GetButtonUp("Shoot"))
        {
            SuperPlayerShoot();
            OneShot = true; 

        }
        */

        if (Input.GetButton("Shoot"))
        {
            chargeTimer += Time.deltaTime;
        }
        if (Input.GetButtonUp("Shoot") && (chargeTimer >= chargeTime))
        {
            SuperPlayerShoot();
            //OneShot = true;
            chargeTimer = 0;

        }
        else if(Input.GetButtonUp("Shoot") && (chargeTimer < chargeTime)){
            playerShoot();
            chargeTimer = 0;
        }


    }


    /*
    void MakeShot()
    {
        superShotInstance = Instantiate(superShot, transform.position, transform.rotation) as GameObject;

    }

    void Charge()
    {
        if(OneShot = true)
        {
            
            startingScale = superShot.transform.localScale;
            superShotInstance.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
            superShotInstance.transform.position = this.gameObject.transform.position;

            
            

        }
        
        

    }
    */

    void SuperPlayerShoot()
    {
        superShotInstance = Instantiate(superShot, transform.position, transform.rotation) as GameObject;
        if (superShotInstance != null)
        {
            superShotInstance.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * shotSpeed);
        }
    }


    void playerShoot()
    {
        shotInstance = Instantiate(normalShot, transform.position, transform.rotation) as GameObject;
        if (shotInstance != null)
        {
            shotInstance.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * shotSpeed);
        }
    }
}
