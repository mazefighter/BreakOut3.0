using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    public int points ;
    
    private void OnEnable()
    {
        Block.HealthOnImpact += BlockOnHealthOnImpact;
        points = 0;
    }

    private void OnDisable()
    {
        Block.HealthOnImpact -= BlockOnHealthOnImpact;
    }

    private void BlockOnHealthOnImpact(int health)
    {
        switch (health)
        {
            case 1:
                points += 50;
                _text.SetText(""+points);
                break;
            case 2:
                points += 100;
                _text.SetText(""+points);
                break;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
