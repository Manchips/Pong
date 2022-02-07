using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Goals : MonoBehaviour
{
    static int rightScore; // these have to be static otherwise the score isn't shared between the two goals. 

    static int leftScore;
    // Start is called before the first frame update
    void Start()
    {
        rightScore = 0;
        leftScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GetComponent<Collider>().CompareTag("leftGoal"))
        {
            leftScore = addPoints(leftScore);
            Debug.Log("Left paddle scored!" + " Score is " + leftScore + ":" + rightScore);
            if (leftScore == 11)
            {
                Debug.Log("Game Over, Player 1 Wins");
                rightScore = 0;
                leftScore = 0;
            }
        } 
        else if (GetComponent<Collider>().CompareTag("rightGoal"))
        {
            rightScore = addPoints(rightScore);
            Debug.Log("Right paddle scored!" + " Score is " + leftScore + ":" + rightScore);
            if (rightScore == 11)
            {
                Debug.Log("Game Over, Player 2 Wins");
                rightScore = 0;
                leftScore = 0;
            }
        }
    }

    int addPoints(int score)
    {
        score += 1;
        return score; 
    }
}
