using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent nav;

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
        nav.SetDestination(GameCore.Instance.player.position);
    }
    private void CheckAnimator()
    {
        float distance = Vector3.Distance(transform.position, GameCore.Instance.player.position);
        if (distance <= nav.stoppingDistance)
        {
            animator.SetBool("Attack", true);
        }
    }
}
