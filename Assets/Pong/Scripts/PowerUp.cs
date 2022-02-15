using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public int minTravelHeight = 3;
    public int maxTravelHeight = 3;
    public float speed = 5f;
    public float speedBoost = 2.5f;

    private Vector3 pos; 
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Rigidbody>().velocity = 
            other.GetComponent<Rigidbody>().velocity * speedBoost * Time.deltaTime; 
    }

    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        pos.z = Mathf.Clamp(pos.z, minTravelHeight, maxTravelHeight);
        transform.position = new Vector3(pos.z, minTravelHeight, maxTravelHeight);
    }
}
