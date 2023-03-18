using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public AudioClip hitSFX;
    public Slider healthSlider;


    int currentHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
        healthSlider.value = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damageAmount) {
        if (currentHealth > 0) {
            currentHealth -= damageAmount;
            healthSlider.value = currentHealth;
            AudioSource.PlayClipAtPoint(hitSFX, this.transform.position);
        }  
        
        if (currentHealth == 0) {
            PlayerDies();
        }

        //Debug.Log(currentHealth);
    }

    void PlayerDies() {
        Debug.Log("Player is dead");
        var animator = GetComponent<Animator>();
        animator.SetFloat("Speed_f", 0);
        animator.SetBool("Death_b", true);
        animator.SetInteger("DeathType_int", 1);
        GetComponent<PlayerController>().enabled = false;
        GetComponent<PlayerMeleeAttack>().enabled = false;
        GetComponent<PlayerBowAttack>().enabled = false;
        FindObjectOfType<LevelManager>().LevelLost();
        //AudioSource.PlayClipAtPoint(deadSFX, transform.position);
        //transform.Rotate(-90, 0, 0, Space.Self);
    }

     public void TakeHealth(int healthAmount) {
        if (currentHealth < 100) {
            currentHealth += healthAmount;
            healthSlider.value = Mathf.Clamp(currentHealth, 0, 100);
        }  
        
    } 
}
