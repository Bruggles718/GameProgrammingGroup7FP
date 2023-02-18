using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    [SerializeField] private float animationLength;
    private Animator animator;
    private Rigidbody rb;
    private float finishTime;

    private bool resetAnim;

    // Start is called before the first frame update
    void Start()
    {
        
        this.animator = GetComponent<Animator>();
        this.rb = GetComponent<Rigidbody>();
        this.finishTime = 0;

        this.animator.SetBool("Static_b", true);
        this.animator.SetInteger("WeaponType_int", 0);
        this.animator.SetInteger("MeleeType_int", 1);

        this.resetAnim = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time < this.finishTime)
        {
            return;
        }
        else
        {
            if (this.resetAnim)
            {
                this.animator.SetBool("Static_b", true);
                this.animator.SetInteger("WeaponType_int", 0);
                this.animator.SetInteger("MeleeType_int", 1);
                this.resetAnim = false;
            }
        }
        if (Input.GetButtonDown("Fire1") && Time.time > this.finishTime)
        {
            var mousePos = Helpers.GetMousePosition3D(new Plane(Vector3.up, this.transform.position));
            this.rb.velocity = Vector3.zero;
            this.transform.LookAt(mousePos);
            this.animator.SetBool("Static_b", true);
            this.animator.SetFloat("Speed_f", 0);
            this.animator.SetInteger("WeaponType_int", 12);
            this.animator.SetInteger("MeleeType_int", 1);
            this.resetAnim = true;
            this.finishTime = Time.time + this.animationLength;
        }
    }
}
