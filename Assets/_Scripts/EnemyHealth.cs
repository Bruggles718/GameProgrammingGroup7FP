using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 5;
    public AudioClip deadSFX;
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
        if (currentHealth > 0)
        {
            currentHealth -= damageAmount;
            
        }
        if (currentHealth <= 0)
        {
           EnemyDies();
        }
        Debug.Log("Current health: " + currentHealth);
    }

    void EnemyDies()
    {
        Debug.Log("Enemy dies");
        AudioSource.PlayClipAtPoint(deadSFX, transform.position);
        Destroy(gameObject);
    }

 


}
