using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 4f;

    public ParticleSystem bubbleEffect;

//Heath & Invincibility
    
    public int health = 5;

    private bool invincibleEnabled = false;
    [SerializeField]
    private float invincCooldown = 3.0f;

    Vector3 forward, right;
    // Start is called before the first frame update
    void Start()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.anyKey)
        {
            Move();
        }
        
    }

    void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis("HorizontalKey"), 0, Input.GetAxis("VerticalKey"));
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("PickUp"))
        {
            collision.gameObject.SetActive(false);
            ParticleSystem Bubble = Instantiate(bubbleEffect, transform.position + Vector3.forward * 0.5f, Quaternion.identity);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (invincibleEnabled == false)
            {

            }
            health -= 1;
        }
    }

    public void InvincEnabled()
    {
        invincibleEnabled = true;
        StartCoroutine(InvincDisableRoutine());
    }

    IEnumerator InvincDisableRoutine()
    {
        yield return new WaitForSeconds(invincCooldown);
        invincibleEnabled = false;
    }

    }

