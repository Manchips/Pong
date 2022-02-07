using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Paddles : MonoBehaviour
{
    public float movementPerSecond = 1f;

    public GameObject paddleRight;

    public GameObject paddleLeft;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Paddles"; //Will use this to increase the movement for each collusion the ball does against a given paddle. 
    }

    // Update is called once per frame
    void Update()
    {
        
        float movementAxisLeft = Input.GetAxis("Horizontal"); // left paddle movement keys

        float movementAxisRight = Input.GetAxis("Vertical"); // right paddle movement keys 
        
        Vector3 forceLeft =  movementAxisLeft * movementPerSecond * Time.deltaTime * Vector3.right;

        Vector3 forceRight = movementAxisRight * movementPerSecond * Time.deltaTime * Vector3.left;
        
        if (paddleRight)
        {
            Rigidbody rgbody = GetComponent<Rigidbody>();
            rgbody.AddForce(forceRight,ForceMode.VelocityChange);
        }

        if (paddleLeft)
        {
            Rigidbody rgbody = GetComponent<Rigidbody>();
            rgbody.AddForce(forceLeft,ForceMode.VelocityChange);
        }
    }
}
