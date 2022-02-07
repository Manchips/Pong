using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    public float force = 200.0f;

    public int hitCount; //will use this for the 5th hit and onwards

    public int scoreCount;

    public bool whoScored;

    private Rigidbody _rigidbody;
    
    public Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        direction = vectorDegree(45); 
        Invoke("GoBall", 0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 vectorDegree(float degrees)
    {
        var angle = degrees * Mathf.Deg2Rad;
        var x = Mathf.Cos(angle);
        var y = Mathf.Sin(angle);
        var z = Mathf.Tan(angle);
        return new Vector3(x, y, z);
    }

    void GoBall()
    {
        if (scoreCount == 0)
        {
            float randomNumber = Random.Range(0, 10);
            //On start we want the ball to go in a random direction so maybe we make a random number and get the module of it
            if (randomNumber % 2 == 1)
            {
                _rigidbody.AddForce(transform.forward * -force); //goes to the left 
            }
            else
            {
                GetComponent<Rigidbody>().AddForce(transform.forward * force); //goes to the right 
            }
        }
        else
        {
            if (whoScored)
            {
                GetComponent<Rigidbody>().AddForce(transform.forward * -force);
            }
            else
            {
                GetComponent<Rigidbody>().AddForce(transform.forward * force);
            }
            
        }

    }
    
    private void OnCollisionEnter(Collision coll)
    {
        //Vector3 normal = coll.contacts[0].normal;
        if (coll.collider.CompareTag("Paddles"))
        {
           GetComponent<Rigidbody>().AddForce(transform.forward * (force +10f));
           force += 10.0f;
           hitCount++;
        }else if (coll.collider.CompareTag("Wall"))
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * force); //This is just to make it so the ball doesnt slow down when hitting a wall 
        }

        //Vector3 reflection = Vector3.Reflect(direction, normal); // should reflect it back in a realistic way(?)
        //_rigidbody.velocity = reflection;
    }

    private void OnTriggerEnter(Collider other)
    {
        scoreCount++;
        if (GetComponent<Collider>().CompareTag("rightGoal"))
        {
            whoScored = true; 
        }

        force = 200f;
        this.transform.position = new Vector3(0,1,0);
        Invoke("GoBall",180.0f);
    }
    
}
