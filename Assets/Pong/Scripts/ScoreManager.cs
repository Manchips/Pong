using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI leftScore;

    public TextMeshProUGUI rightScore;

    private int _left = 0;

    private int _right = 0;
    
    public void AddLeft()
    {
        _left++;
        if (_left == 9)
        {
            leftScore.color = Color.red;
        }
        leftScore.text = $"{_left}";
    }
    
    public void AddRight()
    {
        _right++;
        if (_right == 9)
        {
            rightScore.color = Color.red;
        }
        rightScore.text = $"{_right}";

    }

    public void reSet()
    {
        _right = 0;
        _left = 0;
        leftScore.text = $"{_left}";
        rightScore.text = $"{_right}";
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 
    }
}
