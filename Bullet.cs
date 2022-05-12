using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("爆炸特效")]
    public GameObject effect;
    [Header("傷害")]
    public float damage = 50;
    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(effect, transform.position, transform.rotation);
        Destroy(gameObject);
        if (collision.collider.CompareTag("Zombie"))
        {
            collision.collider.GetComponent<Zombie>().GetHit(damage);
        }
    }
}
