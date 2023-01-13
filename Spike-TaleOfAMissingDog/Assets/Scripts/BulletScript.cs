using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
//ing System.Media;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class BulletScript : MonoBehaviour
{
    private GameObject player;
    private GameObject boss;
    private Vector3 mousePos;
    private Camera MainCamera;
    private Rigidbody2D rb;
    public float force;
    public string tagToDamage;

    public AudioClip HitSound;

    // Start is called before the first frame update
    void Start()
    {
        if (tagToDamage == null)
        {
            tagToDamage = "Monsters";
        }
        if (tagToDamage == "Monsters")
        {
            MainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            rb = GetComponent<Rigidbody2D>();
            mousePos = MainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = mousePos - transform.position;
            // Vector3 rotation = transform.position - mousePos;
            rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        }

        if (tagToDamage == "Player")
        {
            player = GameObject.FindGameObjectWithTag("Player");
            rb = GetComponent<Rigidbody2D>();
            //rb.velocity = player.transform. * force;
            Vector2 direction = player.transform.position - gameObject.transform.position;
            rb.velocity = direction.normalized * force;

        }

        if (tagToDamage == "PlayerBoss")
        {
            boss = GameObject.FindGameObjectWithTag("Boss");
            rb = GetComponent<Rigidbody2D>();
            Vector2 direction = -(boss.transform.position - gameObject.transform.position);
            rb.velocity = direction.normalized * 3;
        }
    
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.CompareTag("Monsters") || other.gameObject.CompareTag("Boss")) && tagToDamage == "Monsters")
        {

            other.gameObject.GetComponent<Enemyhealth>().health -= force;
            AudioSource.PlayClipAtPoint(HitSound, transform.position, volume: 200.0f);
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Player") && (tagToDamage == "Player" || tagToDamage == "PlayerBoss"))
        {

            other.gameObject.GetComponent<PlayerHealth>().currenthealth -= force;
            AudioSource.PlayClipAtPoint(HitSound, transform.position, volume: 200.0f);
            Destroy(gameObject);
        }
        // get collide object
        // check if otherObject is monster Tag
        // if it is
        // get otherObjects.EnemyHealth and subtract the health prop with the damage. 

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
    }


}

