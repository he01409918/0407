using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent nav;
    [Header("血量")]
    public float hp = 100;
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Movement();
        CheckAnimator();
    }

    private void Movement()
    {
        if (hp > 0)
        {
            nav.SetDestination(GameCore.Instance.player.position);
        }
    }
    private void CheckAnimator()
    {
        float distance = Vector3.Distance(transform.position, GameCore.Instance.player.position);
        if (distance <= nav.stoppingDistance)
        {
            animator.SetBool("Attack", true);
        }
    }
    public void GetHit(float value)
    {
        if (hp > 0)
        {
            hp -= value;
            if (hp <= 0)
            {
                nav.speed = 0;
                animator.Play("Die");
                Destroy(GetComponent<Collider>());
                Destroy(gameObject, 5);
            }
        }
    }
}
