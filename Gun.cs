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
    public float fireTime;

    [Header("子彈速度")]
    public float bulletSpeed;

    private float currentFireTime;

    private bool isFire;

    void Start()
    {
        
    }

    private void Update()
    {
        isFire = Input.GetKey(KeyCode.Space);


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
        GameObject newMuzzleFlashes = Instantiate(bullet, firePoint.position, firePoint.rotation);
        newMuzzleFlashes.GetComponent<Rigidbody>().AddForce(firePoint.forward * bulletSpeed, ForceMode.Impulse);
        Destroy(newMuzzleFlashes, 3f);
    }
}
