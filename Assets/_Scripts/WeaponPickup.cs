using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public KeyCode pickupKey;

    public PlayerBehavior playerBehavior;

    private Boolean doPickup = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(pickupKey) && doPickup)
        {
            playerBehavior.SetWeapon(gameObject.name);
            // playerBehavior.SetDamageType("");
            doPickup = false;
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
            doPickup = true;
        }
        else
        {
            doPickup = false;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        doPickup = false;
    }
}
