using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    private Camera cam;
    private Vector3 mousePos;

    public Transform bulletTransform;
    public GameObject stoneBulletPrefab;
    
    
    private bool canFire = true;
    private float timer;
    public float timeBetweenFiring;

    void Start(){
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    void Update()
    {

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y,rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler (0,0,rotZ);

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
        }
     }


    private void Shoot()
    {
        canFire = false;
        GameObject bullet = Instantiate(stoneBulletPrefab, bulletTransform.position,Quaternion.identity);
        

        Destroy(bullet,2.0f);
    }


}
