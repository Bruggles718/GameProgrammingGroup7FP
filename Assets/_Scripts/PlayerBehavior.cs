using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public GameObject sword;
    public GameObject swordPrefab;
    public GameObject bow;

    public GameObject bowPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Set the player's current weapon
    public void SetWeapon(string weaponName)
    {
        switch (weaponName)
        {
            case "SF_Wep_Human_Bow_01":
                bow.SetActive(true);
                //GameObject newSword = 
                  //  Instantiate(swordPrefab, transform.position, transform.rotation) as GameObject;
                sword.SetActive(false);
                break;
            
            case "SF_Wep_Human_Longsword_01":
                sword.SetActive(true);
                //GameObject newBow = 
                  //  Instantiate(bowPrefab, transform.position, transform.rotation) as GameObject;
                bow.SetActive(false);
                break;
        }
    }

    // Set the damageType of the current weapon
    public void SetDamageType(string damageType)
    {
        switch (damageType)
        {
            case "":
                // Child of weapon type set enabled
                break;
            
            case "sword":
                // Child of weapon type set enabled
                break;
        }
    }
    


}
