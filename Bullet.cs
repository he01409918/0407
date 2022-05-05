using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("爆炸特效")]
    public GameObject effect;
    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(effect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
