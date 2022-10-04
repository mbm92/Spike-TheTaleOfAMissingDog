using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform firePoint;
    public GameObject stoneBulletPrefab;
    //public Rigidbody2D rigidbody;

    public float bulletForce = 20f;

    public Camera cam;

    //private Vector2 movement;
    private Vector2 mousePos;

    private Vector2 shootingDir;


    // Update is called once per frame
    void Update()
    {

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    void FixedUpdate()
    {
        //RotateFirePoint();
        shootingDir = Aim();
    }

    //void RotateFirePoint()
    //{
    //    //Vector2 fireDir = mousePos - rigidbody.position;
    //    Vector2 firePointPos = new Vector2(firePoint.position.x, firePoint.position.y);
    //    Vector2 fireDir = mousePos - firePointPos;
    //    float angle = (Mathf.Atan2(fireDir.y, fireDir.x) * Mathf.Rad2Deg - 90f);
    //    firePoint.rotation = angle;
    //}

    Vector2 Aim()
    {
        //firePoint.localPosition = mousePos - new Vector2(firePoint.position.x, firePoint.position.y);
        return mousePos - new Vector2(firePoint.position.x, firePoint.position.y);
    }

    private void Shoot()
    {
        //Vector2 shootingDir = firePoint.localPosition;
        shootingDir.Normalize();

        // create bullet
        GameObject bullet = Instantiate(stoneBulletPrefab, firePoint.position, Quaternion.identity);

        // add force to bullet
        //Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
        //rigidbody.AddForce(firePoint.localPosition * bulletForce, ForceMode2D.Impulse);


        bullet.GetComponent<Rigidbody2D>().velocity = shootingDir * bulletForce;
        bullet.transform.Rotate(0,0, Mathf.Atan2(shootingDir.y, shootingDir.x) * Mathf.Rad2Deg);
        Destroy(bullet, 2.0f);
    }



}
