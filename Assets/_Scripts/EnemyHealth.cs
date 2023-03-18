using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 5;
    //public AudioClip deadSFX;
    public AudioClip hitSFX;
    int currentHealth;


    void Start()
    {
        currentHealth = startingHealth;
     }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damageAmount)
    {
        if (LevelManager.isGameOver) return;
        if (currentHealth > 0)
        {
            currentHealth -= damageAmount;
            AudioSource.PlayClipAtPoint(hitSFX, this.transform.position);

        }
        if (currentHealth <= 0)
        {
           EnemyDies();
        }
        Debug.Log("Current health: " + currentHealth);
    }

    void EnemyDies()
    {
        if (LevelManager.isGameOver) return;
        Debug.Log("Enemy dies");
        //AudioSource.PlayClipAtPoint(deadSFX, transform.position);
        //Destroy(gameObject);
        this.GetComponent<EnemyBehavior>().Die();
        this.GetComponent<Animator>().SetBool("Death_b", true);
        Destroy(gameObject, 2);
    }

 


}
