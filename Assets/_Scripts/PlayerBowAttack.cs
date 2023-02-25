using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBowAttack : MonoBehaviour
{
    [SerializeField] private float animationLength;
    [SerializeField] private float arrowReleaseTime;
    [SerializeField] private GameObject arrowInHand;
    [SerializeField] private GameObject arrowProjectilePrefab;
    [SerializeField] private float arrowSpeed = 10f;
    private Animator animator;
    private float finishTime;
    private float arrowReleaseFinishTime;
    private PlayerController playerController;
    private bool releasedArrow = false;

    private bool resetAnim;

    // Start is called before the first frame update
    void Start()
    {
        this.playerController = GetComponent<PlayerController>();

        this.animator = GetComponent<Animator>();
        this.finishTime = 0;
        this.arrowReleaseFinishTime = 0;
        this.releasedArrow = true;

        this.animator.SetBool("Static_b", true);
        this.animator.SetInteger("WeaponType_int", 0);
        this.animator.SetInteger("MeleeType_int", 0);

        this.resetAnim = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time < this.arrowReleaseFinishTime)
        {
            return;
        }
        this.arrowInHand.SetActive(false);
        if (!this.releasedArrow && Time.time < this.finishTime)
        {
            Rigidbody rb = Instantiate(this.arrowProjectilePrefab, this.arrowInHand.transform.position, this.arrowInHand.transform.rotation).GetComponent<Rigidbody>();
            rb.gameObject.transform.up = -this.transform.forward;
            rb.AddForce((this.transform.forward) * this.arrowSpeed, ForceMode.Impulse);
            this.releasedArrow = true;
            Destroy(rb.gameObject, 5f);
        }
        if (Time.time < this.finishTime)
        {
            return;
        }
        else
        {
            if (this.resetAnim)
            {
                this.playerController.enabled = true;
                this.animator.SetBool("Static_b", true);
                this.animator.SetInteger("WeaponType_int", 0);
                this.animator.SetInteger("MeleeType_int", 0);
                this.releasedArrow = true;

                this.animator.SetBool("Shoot_b", false);
                this.resetAnim = false;
            }
        }
        if (Input.GetButtonDown("Fire1") && Time.time > this.finishTime)
        {
            this.playerController.enabled = false;
            var mousePos = Helpers.GetMousePosition3D(new Plane(Vector3.up, this.transform.position));
            this.transform.LookAt(mousePos);
            this.animator.SetBool("Static_b", true);
            this.animator.SetFloat("Speed_f", 0);
            this.animator.SetInteger("WeaponType_int", 11);
            this.animator.SetInteger("MeleeType_int", 0);
            this.animator.SetBool("Shoot_b", true);
            this.resetAnim = true;
            this.finishTime = Time.time + this.animationLength;
            this.arrowReleaseFinishTime = Time.time + this.arrowReleaseTime;
            this.releasedArrow = false;
            this.arrowInHand.SetActive(true);
        }
    }
}
