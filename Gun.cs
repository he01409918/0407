using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("子彈物件")]
    public GameObject bullet;
    [Header("發射位置")]
    public Transform firePoint;

    [Header("射擊間隔")]
    public float fireTime = 0.2f;

    [Header("子彈速度")]
    public float bulletSpeed = 20f;

    private float currentFireTime;

    private bool isFire;

    void Start()
    {
        
    }

    private void Update()
    {
        if (Application.isEditor)
        {
            isFire = Input.GetKey(KeyCode.Space);
        }

        if (isFire)
        {
            currentFireTime -= Time.deltaTime;
            if (currentFireTime <= 0)
            {
                OnFire();
                currentFireTime = fireTime;
            }
        }
    }

    public void OnInput(bool b)
    {
        isFire = b;
    }

    public void OnFire()
    {
        GameObject newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
        newBullet.GetComponent<Rigidbody>().AddForce(firePoint.forward * bulletSpeed, ForceMode.Impulse);
    }
}
