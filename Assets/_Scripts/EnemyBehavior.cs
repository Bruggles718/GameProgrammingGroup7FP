using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5;
    public float minDistance = 2;

    private Animator animator;

    private bool dead = false;


    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float step = moveSpeed * Time.deltaTime;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > minDistance && !dead)
        {
            animator.SetFloat("Speed_f", moveSpeed);
            transform.LookAt(player);
            transform.position = Vector3.MoveTowards(transform.position, player.position, step);
        }
        else
        {
            animator.SetFloat("Speed_f", 0);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("PlayerWeapon") && this.player.GetComponent<Animator>().GetInteger("WeaponType_int") > 0) {
            dead = true;
            this.animator.SetBool("Death_b", true);
            Destroy(gameObject,2);
        }
    }
}
