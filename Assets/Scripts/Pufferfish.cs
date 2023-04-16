using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pufferfish : MonoBehaviour
{
    public GameObject pufferfish;
    public GameObject explosion;
    private AudioSource source;
    public GameObject playerBullet;
    public Animation anim;

    [SerializeField]
    private float range;
    // Start is called before the first frame update
    private void Awake()
    {
        pufferfish.SetActive(true);
        explosion.SetActive(false);

        source = GetComponent<AudioSource>();
    }

    public void Explode()
    {
        pufferfish.SetActive(false);
        explosion.SetActive(true);

        source.Play();

        Collider[] enemies = Physics.OverlapSphere(transform.position, range);

        foreach (Collider enemy in enemies)
        {
            if (enemy.GetComponent<EnemyHealth>() != null)
            {
                enemy.GetComponent<EnemyHealth>().KillEnemy();
            }

        }
        enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Explode();
        }

    }
}