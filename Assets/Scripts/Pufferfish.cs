using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pufferfish : MonoBehaviour
{
    public GameObject pufferfish;
    //public GameObject explosion;
    public AudioSource source;
    private Collider collider; 
    public Animator anim;
    public ParticleSystem explosion; 
    public float destroyTime;
    public float delayUpTime; 

    [SerializeField]
    private float range;
    private bool isGoUp = false;
    public float upSpeed; 
    // Start is called before the first frame update
    private void Awake()
    {
        pufferfish.SetActive(true);
        //explosion.SetActive(false);
        collider = GetComponent<Collider>();
        anim = GetComponent<Animator>();
    }

    public void Explode()
    {
        //disable collider not object so that it can do animation 
        collider.enabled = !collider.enabled;
        //explosion.SetActive(true);
        if (explosion != null)
        {
            Debug.Log("Explode");
            explosion.gameObject.SetActive(true);
            explosion.Play();
        }
        if (anim != null)
        {

            anim.SetBool("isExplode", true);
            //anim play isnt working idk why 
        }

        Collider[] enemies = Physics.OverlapSphere(transform.position, range);

        foreach (Collider enemy in enemies)
        {
            if (enemy.GetComponent<EnemyHealth>() != null)
            {
                enemy.GetComponent<EnemyHealth>().KillEnemy();
            }

        }
        //enabled = false;
        Invoke("turnOnGoUp", delayUpTime);
        Invoke("DestroyObject", destroyTime);
        

    }
    void Update()
    {
        if (isGoUp == true)
        {
            GoUp();
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            source.Play();
            Explode();
        }
    }
    private void turnOnGoUp()
    {
        isGoUp = true; 
    }
    private void GoUp()
    {
        transform.position += Vector3.up * upSpeed * Time.deltaTime;
    }
    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}