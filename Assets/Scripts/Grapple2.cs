using UnityEngine;
using System.Collections;

public class Grapple2 : MonoBehaviour
{
    public float grappleDistance = 100f;
    public float grappleSpeed = 10f;
    public float grappleResetTime = 2f;
    public LayerMask grapple;

    private bool isGrappling = false;
    private bool isResetting = false;

    private Rigidbody playerRigidbody;
    private Vector3 grapplePoint;
    private LineRenderer lineRenderer;

    void Start()
    {
        playerRigidbody = GetComponentInParent<Rigidbody>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.enabled = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Grapple") || Input.GetAxisRaw("Joystick Grapple") > 0 )
        {
            
            isGrappling = true;
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, grappleDistance, grapple))
               
            {
               
                grapplePoint = hit.point;
                StartCoroutine(Grapple());
            }
            else
            {
                isGrappling = false;
            }
        }
    }

    IEnumerator Grapple()
    {
        playerRigidbody.useGravity = false;
        lineRenderer.enabled = true;
        float distanceToGrapplePoint = Vector3.Distance(transform.position, grapplePoint);
        while (distanceToGrapplePoint > 0.2f)
        {
            
            distanceToGrapplePoint = Vector3.Distance(transform.position, grapplePoint);
            playerRigidbody.velocity = (grapplePoint - transform.position).normalized * grappleSpeed;
            Debug.Log(playerRigidbody.velocity);
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, grapplePoint);
            yield return null;
        }
        playerRigidbody.velocity = Vector3.zero;
        isGrappling = false;
        isResetting = true;
        lineRenderer.enabled = false;
        yield return new WaitForSeconds(grappleResetTime);
        isResetting = false;
    }

    void FixedUpdate()
    {
        if (isResetting)
        {
            playerRigidbody.useGravity = true;
            playerRigidbody.velocity = Vector3.zero;
        }
    }
}
