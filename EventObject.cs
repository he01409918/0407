using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventObject : MonoBehaviour
{
    public string tagName;
    public GameObject effect;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(tagName))
        {
            GameObject fx = Instantiate(effect, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(fx, 5);
        }
    }
}
