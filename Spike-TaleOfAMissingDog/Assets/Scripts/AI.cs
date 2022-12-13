using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using System.Timers;
using UnityEngine;
using Random = UnityEngine.Random;

public class AI : MonoBehaviour
{

    private GameObject player;
    [SerializeField] public float speed = 2f;
    private float distance;
    // Start is called before the first frame update

    private float attackRange = 15f;

    private GameObject bulletPrefab;
    public float shootSpeed = 2;
    public float fireRate = 0.5f;
    private bool canFire = true;
    private float timeBetweenFiring;
    private float timer;
    private GameObject BulletSpawners;




    void Start()
    {
        
        timeBetweenFiring = Random.Range(5f, 8f);
        player = GameObject.FindGameObjectWithTag("Player");
        //bulletPrefab = Resources.Load<GameObject>("Weapons/EnemyBullet");

    }

    // Update is called once per frame
    void Update()
    {
        if (!canFire && speed != 0)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }
        if (player != null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        EngagePlayer(player);

        //distance = Vector2.Distance(transform.position, player.transform.position);
        //transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void EngagePlayer(GameObject player)
    {
        var creaturePos = gameObject.transform.position;

        // look if player is in range
        // if player is in range MoveTowards the player. 
        // else just stand still or move in a pattern? 

        distance = Vector2.Distance(creaturePos, player.transform.position);


        if (distance > attackRange)
            return;
        else
        {
            transform.position =
                Vector2.MoveTowards(creaturePos, player.transform.position, speed * Time.deltaTime);
            if (canFire)
            {
                shootBullet();
            }
        }


    }

    void shootBullet()
    {
        if (gameObject.tag == "Boss")
        {
            var BulletSpawners = GameObject.FindGameObjectsWithTag("BulletSpawner");
            bulletPrefab = Resources.Load<GameObject>("Weapons/BossBullet");
            foreach (var spawner in BulletSpawners)
            {
                canFire = false;
                //StartCoroutine(FiringRounds(spawner, bulletPrefab));
                var projectileround1 = Instantiate(bulletPrefab, spawner.transform.position, spawner.transform.rotation);
                Destroy(projectileround1, 3.0f);
                //WaitForSeconds(1);
                //var projectileround2 = Instantiate(bulletPrefab, spawner.transform.position, spawner.transform.rotation);
                //Destroy(projectileround2, 3.0f);
                //WaitForSeconds(1);
                //var projectileround3 = Instantiate(bulletPrefab, spawner.transform.position, spawner.transform.rotation);
                //Destroy(projectileround3, 3.0f);

            }
        }
        else
        {
            bulletPrefab = Resources.Load<GameObject>("Weapons/EnemyBullet");
            canFire = false;
            var projectile = Instantiate(bulletPrefab, transform.position, transform.rotation);

            Destroy(projectile, 4.0f);
        }
    }

    //IEnumerator FiringRounds(GameObject spawner, bulletPrefab)
    //{
    //    var projectileround1 = Instantiate(bulletPrefab, spawner.transform.position, spawner.transform.rotation);
    //    Destroy(projectileround1, 3.0f);
    //    yield return new waitforseconds(1);
    //    var projectileround2 = instantiate(bulletprefab, spawner.transform.position, spawner.transform.rotation);
    //    destroy(projectileround2, 3.0f);
    //    yield return new waitforseconds(1);
    //    var projectileround3 = instantiate(bulletprefab, spawner.transform.position, spawner.transform.rotation);
    //    destroy(projectileround3, 3.0f);
    //}
}
