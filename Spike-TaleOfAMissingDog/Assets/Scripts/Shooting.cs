using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    private Camera cam;
    private Vector3 mousePos;

    public Transform bulletTransform;
    private GameObject BulletPrefab;
    
    
    private bool canFire = true;
    private float timer;
    public float timeBetweenFiring;
    private GameManager gameManager;

    void Start(){
        BulletPrefab = Resources.Load<GameObject>("Weapons/StoneBullet");
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    void Update()
    {

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y,rotation.x) * Mathf.Rad2Deg -90f;
        transform.rotation = Quaternion.Euler(0,0,rotZ);

        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }
        if(Input.GetKeyDown(KeyCode.Space) && canFire)
        {
            Shoot();
            GetComponent<AudioSource>().Play();
        }

        if (gameManager.creatures_tamed == 5)
        {
            BulletPrefab = Resources.Load<GameObject>("Weapons/ArrowBullet");
        }

    }


    private void Shoot()
    {
        canFire = false;
        GameObject bullet = Instantiate(BulletPrefab, bulletTransform.position, gameObject.transform.rotation);
        

        Destroy(bullet,2.0f);
    }


}
