using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupRotate : MonoBehaviour
{
    public float speed = 2f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,90 * speed * Time.deltaTime, 0));
    }
}